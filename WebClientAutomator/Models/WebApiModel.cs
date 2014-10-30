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
    Complex,
    Task,
    TaskT,
    IEnumerable,
    IEnumerableT,
    HttpResult
  }
}
