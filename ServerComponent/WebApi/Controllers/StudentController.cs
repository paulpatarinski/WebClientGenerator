using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class StudentController : ApiController
    {
      public Student GetStudent()
      {
        return new Student
        {
          FirstName = "John",
          LastName = "Doe"
        };
      }
    }
}
