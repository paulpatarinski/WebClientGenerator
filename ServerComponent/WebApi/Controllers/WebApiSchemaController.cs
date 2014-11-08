using System.Reflection;
using System.Web.Http;
using WebClientAutomator;
using WebClientAutomator.Models;

namespace WebApi.Controllers
{
    public class WebApiSchemaController : ApiController
    {
      [HttpGet]
      public WebApiModel GetSchema()
      {
        var schemaReader = new WebApiSchemaReader();

        return schemaReader.GetWebApiSchema(Assembly.GetExecutingAssembly());
      }
    }
}
