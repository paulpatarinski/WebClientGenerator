using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiClient;

namespace ClientTest
{
  [TestClass]
  public class CompanyManagerTest
  {
    [TestMethod]
    public async Task GetCompanies_ShouldReturnCompanies()
    {
      var companyManager = new CompanyManager();

      var companies = await companyManager.GetCompanies();

      Assert.IsNotNull(companies);
      Assert.IsTrue(companies.Any());
    }

    [TestMethod]
    public async Task GetCompanyByCode_ShouldReturnACompanyMatchingTheCode()
    {
      var companyManager = new CompanyManager();

      var company = await companyManager.GetCompanyByCode("2000");

      Assert.IsNotNull(company);
    }

    [TestMethod]
    public async Task GetCompanyByQuery_ShouldReturnACompanyMatchingTheQuery()
    {
      var companyManager = new CompanyManager();

      var company = await companyManager.GetCompanyByQuery(new CompanyQuery
      {
        Code = "2000",
      });

      Assert.IsNotNull(company);
    }
  }
}
