using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ClientTest
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public async Task TestMethod1()
    {
      var result = string.Empty;

      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri("http://localhost:49515/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // New code:
        var response = await client.GetAsync("api/WebApiSchema/Schema");
        
        if (response.IsSuccessStatusCode)
        {
          result = await response.Content.ReadAsStringAsync();
        }
      }

      Assert.IsNotNull(result);
    }
  }
}
