using System;

namespace WebClientAutomator
{
  public static class TypeExtensions
  {
    public static bool IsPrimitiveType(this Type type)
    {
      return type.IsPrimitive || type.IsValueType || (type == typeof(string));
    }

    public static bool IsIEnumerable(this Type type)
    {
      return (type.GetInterface("IEnumerable") != null);
    }

    public static bool IsHttpResult(this Type type)
    {
      return (type.Name.Equals("IHttpActionResult") || type.GetInterface("IHttpActionResult") != null);
    }

    public static bool IsTask(this Type type)
    {
      return (type.Name.Equals("Task`1") || type.Name.Equals("Task"));
    }
  }
}
