using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiClient;

namespace ClientTest
{
  [TestClass]
  public class AccountManagerTest
  {
    [TestMethod]
    public async Task GetUserInfo_ShouldReturnUserInfo()
    {
      var manager = new AccountManager();

      var result = await manager.GetUserInfo();

      Assert.IsNotNull(result);
    }
  }
}
