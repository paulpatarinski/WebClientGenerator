using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using WebApiClient;

namespace ClientTest
{
  [TestFixture]
  public class CompanyManagerTest
  {
    [Test]
    public async Task GetCompanies_ShouldReturnAListOfCompanies()
    {
      var companyManager = new CompanyManager();

      var companies = await companyManager.GetCompanies();

      Assert.IsNotNull(companies);
      Assert.IsTrue(companies.Any());
    }

    [Test]
    public async Task GetCompanyByCompanyCode_ShouldReturnACompany_MatchingTheCompanyCode()
    {
      var companyManager = new CompanyManager();

      const string companyCode = "1234";

      var company = await companyManager.GetCompanyByCompanyCode(companyCode);

      Assert.IsNotNull(company);
      Assert.IsTrue(company.CompanyName.Equals("Company 1"));
    }
  }
}
