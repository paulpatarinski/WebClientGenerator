using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiClient;

namespace ClientTest
{
  [TestClass]
  public class CompanyManagerTest
  {
    [TestMethod]
    public async Task GetCompanies_ShouldReturnAListOfCompanies()
    {
      var companyManager = new CompanyManager();

      var companies = await companyManager.GetCompanies();

      Assert.IsNotNull(companies);
      Assert.IsTrue(companies.Any());
    }

    [TestMethod]
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
