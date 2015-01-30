
	using System;
	using System.Collections.Generic;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Threading.Tasks;
	using Newtonsoft.Json;
	using Tavis.UriTemplates;

	namespace WebApiClient
	{

	 public static class ObjectExtensions
	  {
      /// <summary>
      /// http://stackoverflow.com/questions/1749966/c-sharp-how-to-determine-whether-a-type-is-a-number
      /// </summary>
      /// <param name="obj"></param>
      /// <returns></returns>
      public static bool IsNumericType(this object obj)
      {
        switch (Type.GetTypeCode(obj.GetType()))
        {
          case TypeCode.Byte:
          case TypeCode.SByte:
          case TypeCode.UInt16:
          case TypeCode.UInt32:
          case TypeCode.UInt64:
          case TypeCode.Int16:
          case TypeCode.Int32:
          case TypeCode.Int64:
          case TypeCode.Decimal:
          case TypeCode.Double:
          case TypeCode.Single:
            return true;
          default:
            return false;
        }
      }
	  }

		public class HttpClientService
		{
      private const string BASE_URL = "http://localhost:49515/api/";

			public static async Task<string> GetAsync(string controllerName, string actionName, Dictionary<string,object> args = null)
			{
				var result = string.Empty;

				using (var client = new HttpClient())
				{
					UriTemplate uriTemplate;

				  if (args != null)
				  {
            uriTemplate = new UriTemplate(string.Format(BASE_URL + "{0}/{1}{2}", controllerName,actionName, "{?" + String.Join(",",args.Keys) + "}"));

				    foreach (var arg in args)
				    {
				      var value = arg.Value.IsNumericType() ? arg.Value.ToString() : arg.Value;

				      uriTemplate.SetParameter(arg.Key, value);
				    }
				  }
				  else
				  {
				   uriTemplate = new UriTemplate(string.Format(BASE_URL + "{0}", controllerName));
				  }

					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					var response = await client.GetAsync(uriTemplate.Resolve());

					if (response.IsSuccessStatusCode)
					{
						result = await response.Content.ReadAsStringAsync();
					}
				}

				return result;
			}
		}

			public class AaronManager
		{

								public async Task<Monkey> GetMonkeysByQuery(GetMonkeysByNameQuery query)
					{
						
													var args = new Dictionary<string,object>();
							
							
								args.Add("query", query);
							
														
							var stringResult = await HttpClientService.GetAsync("Aaron", "GetMonkeysByQuery", args);
						
						return JsonConvert.DeserializeObject<Monkey>(stringResult);
						

											}		
				
		}

			public class AccountManager
		{

								public async Task<UserInfoViewModel> GetUserInfo()
					{
						
													var stringResult = await HttpClientService.GetAsync("Account", "GetUserInfo");
						
						
						return JsonConvert.DeserializeObject<UserInfoViewModel>(stringResult);
						

											}		
								public async Task<string> Logout()
					{
						
													var stringResult = await HttpClientService.GetAsync("Account", "Logout");
						
						
						return JsonConvert.DeserializeObject<string>(stringResult);
						

											}		
								public async Task VoidMethodExample()
					{
											}		
								public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl,bool generateState)
					{
						
													var args = new Dictionary<string,object>();
							
							
								args.Add("returnUrl", returnUrl);
							
							
								args.Add("generateState", generateState);
							
														
							var stringResult = await HttpClientService.GetAsync("Account", "GetManageInfo", args);
						
						return JsonConvert.DeserializeObject<ManageInfoViewModel>(stringResult);
						

											}		
								public async Task<string> ChangePassword(ChangePasswordBindingModel model)
					{
						
													var args = new Dictionary<string,object>();
							
							
								args.Add("model", model);
							
														
							var stringResult = await HttpClientService.GetAsync("Account", "ChangePassword", args);
						
						return JsonConvert.DeserializeObject<string>(stringResult);
						

											}		
								public async Task<string> SetPassword(SetPasswordBindingModel model)
					{
						
													var args = new Dictionary<string,object>();
							
							
								args.Add("model", model);
							
														
							var stringResult = await HttpClientService.GetAsync("Account", "SetPassword", args);
						
						return JsonConvert.DeserializeObject<string>(stringResult);
						

											}		
								public async Task<string> AddExternalLogin(AddExternalLoginBindingModel model)
					{
						
													var args = new Dictionary<string,object>();
							
							
								args.Add("model", model);
							
														
							var stringResult = await HttpClientService.GetAsync("Account", "AddExternalLogin", args);
						
						return JsonConvert.DeserializeObject<string>(stringResult);
						

											}		
								public async Task<string> RemoveLogin(RemoveLoginBindingModel model)
					{
						
													var args = new Dictionary<string,object>();
							
							
								args.Add("model", model);
							
														
							var stringResult = await HttpClientService.GetAsync("Account", "RemoveLogin", args);
						
						return JsonConvert.DeserializeObject<string>(stringResult);
						

											}		
								public async Task<string> GetExternalLogin(string provider,string error)
					{
						
													var args = new Dictionary<string,object>();
							
							
								args.Add("provider", provider);
							
							
								args.Add("error", error);
							
														
							var stringResult = await HttpClientService.GetAsync("Account", "GetExternalLogin", args);
						
						return JsonConvert.DeserializeObject<string>(stringResult);
						

											}		
								public async Task<IEnumerable<ExternalLoginViewModel>> GetExternalLogins(string returnUrl,bool generateState)
					{
						
													var args = new Dictionary<string,object>();
							
							
								args.Add("returnUrl", returnUrl);
							
							
								args.Add("generateState", generateState);
							
														
							var stringResult = await HttpClientService.GetAsync("Account", "GetExternalLogins", args);
						
						return JsonConvert.DeserializeObject<IEnumerable<ExternalLoginViewModel>>(stringResult);
						

											}		
								public async Task<string> Register(RegisterBindingModel model)
					{
						
													var args = new Dictionary<string,object>();
							
							
								args.Add("model", model);
							
														
							var stringResult = await HttpClientService.GetAsync("Account", "Register", args);
						
						return JsonConvert.DeserializeObject<string>(stringResult);
						

											}		
								public async Task<string> RegisterExternal(RegisterExternalBindingModel model)
					{
						
													var args = new Dictionary<string,object>();
							
							
								args.Add("model", model);
							
														
							var stringResult = await HttpClientService.GetAsync("Account", "RegisterExternal", args);
						
						return JsonConvert.DeserializeObject<string>(stringResult);
						

											}		
				
		}

			public class CompanyManager
		{

								public async Task<IEnumerable<Company>> GetCompanies()
					{
						
													var stringResult = await HttpClientService.GetAsync("Company", "GetCompanies");
						
						
						return JsonConvert.DeserializeObject<IEnumerable<Company>>(stringResult);
						

											}		
								public async Task<Company> GetCompanyByCode(string companyCode)
					{
						
													var args = new Dictionary<string,object>();
							
							
								args.Add("companyCode", companyCode);
							
														
							var stringResult = await HttpClientService.GetAsync("Company", "GetCompanyByCode", args);
						
						return JsonConvert.DeserializeObject<Company>(stringResult);
						

											}		
								public async Task<Company> GetCompanyByQuery(CompanyQuery query)
					{
						
													var args = new Dictionary<string,object>();
							
							
								args.Add("query", query);
							
														
							var stringResult = await HttpClientService.GetAsync("Company", "GetCompanyByQuery", args);
						
						return JsonConvert.DeserializeObject<Company>(stringResult);
						

											}		
				
		}

			public class StudentManager
		{

								public async Task<IEnumerable<Student>> GetStudentByIds(IEnumerable<int> ids)
					{
						
													var args = new Dictionary<string,object>();
							
							
								args.Add("ids", ids);
							
														
							var stringResult = await HttpClientService.GetAsync("Student", "GetStudentByIds", args);
						
						return JsonConvert.DeserializeObject<IEnumerable<Student>>(stringResult);
						

											}		
				
		}

			public class ValuesManager
		{

								public async Task<IEnumerable<string>> Get()
					{
						
													var stringResult = await HttpClientService.GetAsync("Values", "Get");
						
						
						return JsonConvert.DeserializeObject<IEnumerable<string>>(stringResult);
						

											}		
								public async Task<string> Get(int id)
					{
						
													var args = new Dictionary<string,object>();
							
							
								args.Add("id", id);
							
														
							var stringResult = await HttpClientService.GetAsync("Values", "Get", args);
						
						return JsonConvert.DeserializeObject<string>(stringResult);
						

											}		
								public async Task Post(string value)
					{
											}		
								public async Task Put(int id,string value)
					{
											}		
								public async Task Delete(int id)
					{
											}		
				
		}

					public class GetMonkeysByNameQuery
				{

				
				public string Name { get; set; }


				
				public int Type { get; set; }


				
				public Student Student { get; set; }


								}

						public class ChangePasswordBindingModel
				{

				
				public string OldPassword { get; set; }


				
				public string NewPassword { get; set; }


				
				public string ConfirmPassword { get; set; }


								}

						public class SetPasswordBindingModel
				{

				
				public string NewPassword { get; set; }


				
				public string ConfirmPassword { get; set; }


								}

						public class AddExternalLoginBindingModel
				{

				
				public string ExternalAccessToken { get; set; }


								}

						public class RemoveLoginBindingModel
				{

				
				public string LoginProvider { get; set; }


				
				public string ProviderKey { get; set; }


								}

						public class RegisterBindingModel
				{

				
				public string Email { get; set; }


				
				public string Password { get; set; }


				
				public string ConfirmPassword { get; set; }


								}

						public class RegisterExternalBindingModel
				{

				
				public string Email { get; set; }


								}

						public class CompanyQuery
				{

				
				public string Code { get; set; }


				
				public string Name { get; set; }


								}

						public class Monkey
				{

				
				public string Name { get; set; }


				
				public int Type { get; set; }


								}

						public class UserInfoViewModel
				{

				
				public string Email { get; set; }


				
				public bool HasRegistered { get; set; }


				
				public string LoginProvider { get; set; }


								}

						public class ManageInfoViewModel
				{

				
				public string LocalLoginProvider { get; set; }


				
				public string Email { get; set; }


				
				public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }


								}

						public class ExternalLoginViewModel
				{

				
				public string Name { get; set; }


				
				public string Url { get; set; }


				
				public string State { get; set; }


								}

						public class Company
				{

				
				public string CompanyCode { get; set; }


				
				public string CompanyName { get; set; }


								}

						public class Student
				{

				
				public string FirstName { get; set; }


				
				public string LastName { get; set; }


								}

		}

