using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApi.Controllers
{
  public class CompanyController : ApiController
  {
    private readonly List<Company> _companies = new List<Company>
    {
      new Company {CompanyCode = "1234", CompanyName = "Company 1"},
      new Company
      {
        CompanyCode = "4321",
        CompanyName = "Company 2"
      }
    };

    public List<Company> GetCompanies()
    {
      return _companies;
    }

    public Company GetCompanyByCompanyCode(string companyCode)
    {
      return
        _companies.FirstOrDefault(x => x.CompanyCode.Equals(companyCode, StringComparison.InvariantCultureIgnoreCase));
    }
  }

  public class Company
  {
    public string CompanyCode { get; set; }
    public string CompanyName { get; set; }
  }
}