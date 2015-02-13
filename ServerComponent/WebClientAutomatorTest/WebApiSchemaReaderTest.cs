using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using WebClientAutomator;
using WebClientAutomator.Models;

namespace WebClientAutomatorTest
{
  [TestFixture]
  public class WebApiSchemaReaderTest
  {
    private Assembly _webApiAssembly;
    private WebApiSchemaReader _webApiSchemaReader;

    [SetUp]
    public void SetUp()
    {
      _webApiAssembly = Assembly.LoadFrom(@"..\..\..\WebApi\bin\WebApi.dll");
      Assert.IsNotNull(_webApiAssembly);
      _webApiSchemaReader = new WebApiSchemaReader();
    }

    [Test]
    public void GetWebApiSchema_ShouldReturnCorrectSchema()
    {
      var webApiSchema = _webApiSchemaReader.GetWebApiSchema(_webApiAssembly);

      webApiSchema.Should().NotBeNull();
      webApiSchema.Controllers.Count.Should().Be(4);
    }

    [Test]
    public void GetWebApiSchema_ShouldReturnCorrectNumberOfMethods()
    {
      var webApiSchema = _webApiSchemaReader.GetWebApiSchema(_webApiAssembly);
      var methods = webApiSchema.Controllers.SelectMany(x => x.Methods).ToList();
      var parameterComplexTypes = methods.SelectMany(x => x.Parameters).Where(x => x.ComplexType != null).Select(x => x.ComplexType).ToList();

      //Account Controller
      var accountController = webApiSchema.Controllers.FirstOrDefault(x => x.Name.Equals("AccountController"));

      accountController.Should().NotBeNull();
      accountController.Methods.Count.Should().Be(12);

      //Values Controller
      var valuesController = webApiSchema.Controllers.FirstOrDefault(x => x.Name.Equals("ValuesController"));

      valuesController.Should().NotBeNull();
      valuesController.Methods.Count.Should().Be(5);
    }

    [Test]
    public void GetComplexType_ShouldReturnAComplexType()
    {
      var type = _webApiAssembly.Types().FirstOrDefault(x => x.Name.Equals("UserViewModel"));
      
      type.Should().NotBeNull();

      var complexType = _webApiSchemaReader.GetComplexType(type);

      complexType.Properties.Count.Should().Be(10);
      complexType.Properties.Count(x => x.PropertyType == PropertyType.Primitive).Should().Be(7);
      complexType.Properties.Count(x => x.PropertyType == PropertyType.IEnumerableT && x.PrimitiveType == PrimitiveType.String).Should().Be(1);

      var childComplexTypes = complexType.Properties.Where(x => x.ComplexType != null).ToList();

      childComplexTypes.Should().NotBeNull();
      childComplexTypes.Count().Should().Be(2);

      var userDetailViewModel = childComplexTypes[0];

      userDetailViewModel.PropertyType.Should().Be(PropertyType.Complex);
      userDetailViewModel.ComplexType.Properties.Count.Should().Be(2);

      var departments = childComplexTypes[1];

      departments.PropertyType.Should().Be(PropertyType.IEnumerableT);
      departments.ComplexType.Properties.Count.Should().Be(1);
    }
  }
}