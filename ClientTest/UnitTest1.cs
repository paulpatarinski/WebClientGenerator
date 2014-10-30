using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
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
      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri("http://localhost:49515/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // New code:
        var response = await client.GetAsync("api/WebApiSchema/Schema");
        
        if (response.IsSuccessStatusCode)
        {
          var typesAsString = await response.Content.ReadAsStringAsync();

          var types = JsonConvert.DeserializeObject<WebApiModel>(typesAsString);

          var hello = "";
        }
      }
    }
  }

  public class WebApiModel
  {
    public List<Controller> Controllers { get; set; }
  }

  public class Controller
  {
    public string Name { get; set; }
    public List<MethodInfo> Methods { get; set; }
  }
}
