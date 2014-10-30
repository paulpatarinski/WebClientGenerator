using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using WebClientAutomator.Models;

namespace WebClientAutomator
{
    public class WebApiSchemaReader
    {
      public WebApiModel GetWebApiSchema(Assembly assembly)
      {
        var controllers =
          assembly.GetTypes()
            .Where(type => type != typeof (ApiController) && !type.Name.Equals("WebApiSchemaController") &&
                           typeof (ApiController).IsAssignableFrom(type)).ToList();

        var result = new WebApiModel {Controllers = new List<Controller>()};

        foreach (var controller in controllers)
        {
          var controllerModel = new Controller
          {
            Name = controller.Name,
            Methods = new List<Method>()
          };

          foreach (
            var methodInfo in
              controller.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(x => !x.IsSpecialName)
                .ToList())
          {
            var methodModel = new Method {Name = methodInfo.Name};

            var returnType = methodInfo.ReturnType;

            var methodReturnType = GetMethodReturnType(returnType);
            methodModel.ReturnType = methodReturnType;

            if (methodReturnType != MethodReturnType.Void)
            {
              var primitiveType = GetPrimitiveTypeByMethodReturnType(methodReturnType, returnType);
              methodModel.PrimitiveType = primitiveType;

              if (primitiveType == null)
              {
                if (methodReturnType == MethodReturnType.TaskT || methodReturnType == MethodReturnType.IEnumerableT)
                {
                  var taskTType = returnType.GenericTypeArguments.First();

                  if (taskTType.IsPrimitiveType())
                    methodModel.PrimitiveType = GetPrimitiveType(taskTType.Name);
                  else if (taskTType.IsHttpResult())
                    methodModel.PrimitiveType = PrimitiveType.String;
                  else
                    methodModel.ComplexType = GetComplexType(taskTType);
                }
                else
                {
                  methodModel.ComplexType = GetComplexType(returnType);
                }
              }
            }

            controllerModel.Methods.Add(methodModel);
          }

          result.Controllers.Add(controllerModel);
        }

        return result;
      }

      private PrimitiveType? GetPrimitiveTypeByMethodReturnType(MethodReturnType methodReturnType, Type returnType)
      {
        switch (methodReturnType)
        {
          case MethodReturnType.Primitive:
          {
            return GetPrimitiveType(returnType.Name);
          }
            //This is a special case. You would want to deserialize HTTPResult into a string
          case MethodReturnType.HttpResult:
          case MethodReturnType.Task:
          case MethodReturnType.IEnumerable:
          {
            return PrimitiveType.String;
          }
          default:
            return null;
        }
      }

      public MethodReturnType GetMethodReturnType(Type returnType)
      {
        MethodReturnType methodReturnType;

        if (returnType == typeof (void))
        {
          methodReturnType = MethodReturnType.Void;
        }
        else if (returnType.IsHttpResult())
        {
          methodReturnType = MethodReturnType.HttpResult;
        }
        else if (returnType.IsPrimitiveType())
        {
          methodReturnType = MethodReturnType.Primitive;
        }
        else
        {
          if (returnType.IsTask())
          {
            methodReturnType = returnType.GenericTypeArguments.Any() ? MethodReturnType.TaskT : MethodReturnType.Task;
          }
          else if (returnType.IsIEnumerable())
          {
            methodReturnType = returnType.GenericTypeArguments.Any() ? MethodReturnType.IEnumerableT : MethodReturnType.IEnumerable;
          }
          else
          {
            methodReturnType = MethodReturnType.ComplexType;
          }
        }

        return methodReturnType;

      }

      public
    ComplexType GetComplexType(Type type)
      {
        var complexType = new ComplexType{Properties = new List<Property>(), Name = type.Name};

        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var propertyInfo in properties)
        {
          var property = new Property{Name = propertyInfo.Name};

          if (propertyInfo.PropertyType.IsPrimitiveType())
          {
            property.PropertyType = PropertyType.Primitive;
            property.PrimitiveType = GetPrimitiveType(propertyInfo.PropertyType.Name);
          }
          else
          {
            if (propertyInfo.PropertyType.IsIEnumerable())
            {
              property.PropertyType = PropertyType.IEnumerable;
              var tType = propertyInfo.PropertyType.GenericTypeArguments.FirstOrDefault();

              if (tType != null)
              {
                property.PropertyType = PropertyType.IEnumerableT;

                if (tType.IsPrimitiveType())
                {
                  property.PrimitiveType = GetPrimitiveType(tType.Name);
                }
                else
                {
                  property.ComplexType = GetComplexType(tType);
                }
              }
            }
            else
            {
              property.PropertyType = PropertyType.Complex;
              property.ComplexType = GetComplexType(propertyInfo.PropertyType);
            }
          }

          complexType.Properties.Add(property);
        }

        return complexType;
      }

      private PrimitiveType GetPrimitiveType(string propertyType)
      {
        switch (propertyType.ToLower())
        {
          case "string":
            return PrimitiveType.String;
          case "double":
            return PrimitiveType.Double; 
          case "DateTime":
            return PrimitiveType.DateTime;
          case "int":
            return PrimitiveType.Int;
          case "boolean":
            return PrimitiveType.Bool;
          case "char":
            return PrimitiveType.Char;
          default:
            return PrimitiveType.Unsupported;
        }
      }
    }
}
