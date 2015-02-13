using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ClientTest
{
  [TestFixture]
  public class WebApiSchemaTest
  {
    [Test]
    public async Task TestMethod1()
    {
      var result = await GetAsync("WebApiSchema", "Schema");

      Assert.IsNotNull(result);
    }

    public async Task<string> GetAsync(string controllerName, string actionName)
    {
      var result = string.Empty;

      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri(string.Format("http://localhost:49515/api/{0}/", controllerName));
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await client.GetAsync(actionName);

        if (response.IsSuccessStatusCode)
        {
          result = await response.Content.ReadAsStringAsync();
        }
      }

      return result;
    }
  }
}
