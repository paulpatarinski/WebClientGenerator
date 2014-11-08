using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiClient;

namespace ClientTest
{
  [TestClass]
  public class StudentManagerTest
  {
    [TestMethod]
    public async Task GetStudent_ShouldReturnAStudentModel()
    {
      var manager = new StudentManager();

      var student = await manager.GetStudent();

      Assert.IsNotNull(student);
      Assert.AreEqual(student.FirstName, "John");
      Assert.AreEqual(student.LastName, "Doe");
    }
  }
}