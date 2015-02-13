using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Client
{
  public static class ObjectExtensions
  {
    public static Dictionary<string, string> GetQueryStringParameters(this Object obj)
    {
      var queryParams = new Dictionary<string, string>();
      var objType = obj.GetType();

      //if (objType.IsPrimitiveType())
      //{
      //  queryParams.Add(parameterName, obj.ToString());
      //  return queryParams;
      //}

      var propertyInfos = objType.GetProperties();


      foreach (var info in propertyInfos)
      {
        if (!info.PropertyType.IsPrimitiveType())
        {
          var childQueryParams = info.GetValue(obj).GetQueryStringParameters();

          foreach (var childQueryParam in childQueryParams)
          {
            queryParams.Add(info.Name + "." + childQueryParam.Key, childQueryParam.Value);
          }
        }
        else
        {
          var value = info.GetValue(obj, null) ?? "(null)";

          queryParams.Add(info.Name, value.ToString());
        }
      }

      return queryParams;
    }

    public static bool IsComplexType(this Object obj)
    {
      var type = obj.GetType();

      if (obj.HasProperties())
        return type.Namespace != typeof(int).Namespace;
      return false;
    }

    public static bool IsPrimitiveType(this Type type)
    {
      return type.IsPrimitive || type.IsValueType || (type == typeof(string));
    }

    private static bool HasProperties(this Object obj)
    {
      var type = obj.GetType();

      return Enumerable.Any<PropertyInfo>((IEnumerable<PropertyInfo>)type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
    }
  }
}
