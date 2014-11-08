using System;
using System.Collections.Generic;

namespace WebApi.Models
{
  public class UserViewModel
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Salary { get; set; }
    public DateTime HireDate{ get; set; }
    public int TotalDaysEmployeed { get; set; }
    public bool IsRetired{ get; set; }
    public char PayGrade{ get; set; }
    
    public UserDetailViewModel UserDetail { get; set; }
    public IEnumerable<DepartmentViewModel> Departments { get; set; }
    public List<string> Codes { get; set; } 
  }

  public class UserDetailViewModel
  {
    public string Address { get; set; }
    public string Notes { get; set; }
  }

  public class DepartmentViewModel
  {
    public string DepartmentCode { get; set; }
  }
}
