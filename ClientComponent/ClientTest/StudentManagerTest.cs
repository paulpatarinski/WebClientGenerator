using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tavis.UriTemplates;
using WebApiClient;

namespace ClientTest
{
  [TestClass]
  public class StudentManagerTest
  {
    [TestMethod]
    public async Task GetStudent_ShouldReturnAStudentModel()
    {
      //var studentManager = new StudentManager();


      //var student = await studentManager.GetStudent();

      //Assert.AreEqual(student.FirstName, "John");
      //Assert.AreEqual(student.LastName, "Doe");
    }

    //[TestMethod]
    //public async Task GetStudentById_ShouldReturnAStudentModel()
    //{
    //  var studentManager = new StudentManager();

    //  var student = await studentManager.GetStudentById(123);

    //  Assert.AreEqual(student.FirstName, "Jane");
    //  Assert.AreEqual(student.LastName, "Doe");
    //}

    //[TestMethod]
    //public async Task GetStudentByIds_ShouldReturnAStudentModels()
    //{
    //  var studentManager = new StudentManager();

    //  var ids = new List<int> {123, 2332};

    //  var students = (await studentManager.GetStudentByIds(ids)).ToList();

    //  Assert.AreEqual(students.Count, 2);
    //  Assert.AreEqual(students[0].FirstName, "James");
    //  Assert.AreEqual(students[0].LastName, "Doe");
    //  Assert.AreEqual(students[1].FirstName, "Jane");
    //  Assert.AreEqual(students[1].LastName, "Doe");
    //}
  }
}