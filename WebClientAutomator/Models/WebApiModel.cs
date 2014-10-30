using System.Collections.Generic;

namespace WebClientAutomator.Models
{
  public class WebApiModel
  {
    public List<Controller> Controllers { get; set; }
  }

  public class Controller
  {
    public string Name { get; set; }
    public List<Method> Methods { get; set; }
  }

  public class Method
  {
    public string Name { get; set; }
    public MethodReturnType ReturnType { get; set; }
    public PrimitiveType? PrimitiveType { get; set; }
    public ComplexType ComplexType { get; set; }
  }

  public class ComplexType
  {
    public string Name { get; set; }
    public List<Property> Properties { get; set; }
  }

  public class Property
  {
    public string Name { get; set; }
    public PropertyType? PropertyType { get; set; }
    public PrimitiveType? PrimitiveType { get; set; }
    public ComplexType ComplexType { get; set; }
  }

  public enum PrimitiveType
  {
    String,
    Int,
    Double,
    DateTime,
    Bool,
    Char,
    Unsupported
  }

  public enum PropertyType
  {
    Primitive,
    Complex,
    IEnumerable,
    IEnumerableT
  }

  public enum MethodReturnType
  {
    Void,
    Primitive,
    ComplexType,
    Task,
    TaskT,
    IEnumerable,
    IEnumerableT,
    HttpResult
  }


  public static class SchemaHelper
  {
    public static string GetReturnTypeString(Method method)
    {
      var result = string.Empty;

      switch (method.ReturnType)
      {
        case MethodReturnType.Void:
          return "void";
        case MethodReturnType.Primitive:
        {
          switch (method.PrimitiveType)
          {
            case PrimitiveType.Bool:
              return "bool";
            case PrimitiveType.Char:
              return "char";
            case PrimitiveType.DateTime:
              return "DateTime";
            case PrimitiveType.Double:
              return "double";
            case PrimitiveType.Int:
              return "int";
            case PrimitiveType.String:
              return "string";
            case PrimitiveType.Unsupported:
              return "UNKNOWN";
            default:
              return "UNKNOWN";
          }
        }
        case MethodReturnType.HttpResult:
          return "string";
        case MethodReturnType.IEnumerable:
          return "IEnumerable";
        case MethodReturnType.Task:
          return "async Task";
        case MethodReturnType.IEnumerableT:
        {
          if (method.PrimitiveType != null)
            return string.Format("IEnumerable<{0}>",
              GetReturnTypeString(new Method
              {
                ComplexType = method.ComplexType,
                Name = method.Name,
                PrimitiveType = method.PrimitiveType,
                ReturnType = MethodReturnType.Primitive
              }));

          return string.Format("IEnumerable<{0}>", method.ComplexType.Name);
        }
        case MethodReturnType.TaskT:
        {
          if (method.PrimitiveType != null)
            return string.Format("async Task<{0}>",
              GetReturnTypeString(new Method
              {
                ComplexType = method.ComplexType,
                Name = method.Name,
                PrimitiveType = method.PrimitiveType,
                ReturnType = MethodReturnType.Primitive
              }));

          return string.Format("async Task<{0}>", method.ComplexType.Name);
        }
        case MethodReturnType.ComplexType:
          return method.ComplexType.Name;
        default:
          return "UNKNOWN";
      }

      return result;
    }

    public static string GetClientClassName(string controllerName)
    {
      return controllerName.Replace("Controller", "Manager");
    }
  }
}