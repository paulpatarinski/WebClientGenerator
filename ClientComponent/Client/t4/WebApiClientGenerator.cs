
	using System;
	using System.Collections.Generic;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Threading.Tasks;
	using Newtonsoft.Json;

	namespace WebApiClient
	{
		public class HttpClientService
		{
      private const string BASE_URL = "http://localhost:49515/api/";

			public static async Task<string> GetAsync(string controllerName, string actionName)
			{
				var result = string.Empty;

				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri(string.Format(BASE_URL + "{0}/", controllerName));
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
						
						var stringResult = await HttpClientService.GetAsync("Account", "GetManageInfo");

						return JsonConvert.DeserializeObject<ManageInfoViewModel>(stringResult);
						

											}		
								public async Task<string> ChangePassword(ChangePasswordBindingModel model)
					{
						
						var stringResult = await HttpClientService.GetAsync("Account", "ChangePassword");

						return JsonConvert.DeserializeObject<string>(stringResult);
						

											}		
								public async Task<string> SetPassword(SetPasswordBindingModel model)
					{
						
						var stringResult = await HttpClientService.GetAsync("Account", "SetPassword");

						return JsonConvert.DeserializeObject<string>(stringResult);
						

											}		
								public async Task<string> AddExternalLogin(AddExternalLoginBindingModel model)
					{
						
						var stringResult = await HttpClientService.GetAsync("Account", "AddExternalLogin");

						return JsonConvert.DeserializeObject<string>(stringResult);
						

											}		
								public async Task<string> RemoveLogin(RemoveLoginBindingModel model)
					{
						
						var stringResult = await HttpClientService.GetAsync("Account", "RemoveLogin");

						return JsonConvert.DeserializeObject<string>(stringResult);
						

											}		
								public async Task<string> GetExternalLogin(string provider,string error)
					{
						
						var stringResult = await HttpClientService.GetAsync("Account", "GetExternalLogin");

						return JsonConvert.DeserializeObject<string>(stringResult);
						

											}		
								public async Task<IEnumerable<ExternalLoginViewModel>> GetExternalLogins(string returnUrl,bool generateState)
					{
						
						var stringResult = await HttpClientService.GetAsync("Account", "GetExternalLogins");

						return JsonConvert.DeserializeObject<IEnumerable<ExternalLoginViewModel>>(stringResult);
						

											}		
								public async Task<string> Register(RegisterBindingModel model)
					{
						
						var stringResult = await HttpClientService.GetAsync("Account", "Register");

						return JsonConvert.DeserializeObject<string>(stringResult);
						

											}		
								public async Task<string> RegisterExternal(RegisterExternalBindingModel model)
					{
						
						var stringResult = await HttpClientService.GetAsync("Account", "RegisterExternal");

						return JsonConvert.DeserializeObject<string>(stringResult);
						

											}		
				
		}

			public class StudentManager
		{

								public async Task<Student> GetStudent()
					{
						
						var stringResult = await HttpClientService.GetAsync("Student", "GetStudent");

						return JsonConvert.DeserializeObject<Student>(stringResult);
						

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
						
						var stringResult = await HttpClientService.GetAsync("Values", "Get");

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

						public class Student
				{

				
				public string FirstName { get; set; }


				
				public string LastName { get; set; }


								}

		}

