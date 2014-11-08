
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Newtonsoft.Json;

	namespace WebApiClients
	{
			public class AccountManager
		{

								public UserInfoViewModel GetUserInfo()
					{
						
						return JsonConvert.DeserializeObject<UserInfoViewModel>("");
						

											}		
								public string Logout()
					{
						
						return JsonConvert.DeserializeObject<string>("");
						

											}		
								public void VoidMethodExample()
					{
											}		
								public ManageInfoViewModel GetManageInfo(string returnUrl,bool generateState)
					{
						
						return JsonConvert.DeserializeObject<ManageInfoViewModel>("");
						

											}		
								public string ChangePassword(ChangePasswordBindingModel model)
					{
						
						return JsonConvert.DeserializeObject<string>("");
						

											}		
								public string SetPassword(SetPasswordBindingModel model)
					{
						
						return JsonConvert.DeserializeObject<string>("");
						

											}		
								public string AddExternalLogin(AddExternalLoginBindingModel model)
					{
						
						return JsonConvert.DeserializeObject<string>("");
						

											}		
								public string RemoveLogin(RemoveLoginBindingModel model)
					{
						
						return JsonConvert.DeserializeObject<string>("");
						

											}		
								public string GetExternalLogin(string provider,string error)
					{
						
						return JsonConvert.DeserializeObject<string>("");
						

											}		
								public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl,bool generateState)
					{
						
						return JsonConvert.DeserializeObject<IEnumerable<ExternalLoginViewModel>>("");
						

											}		
								public string Register(RegisterBindingModel model)
					{
						
						return JsonConvert.DeserializeObject<string>("");
						

											}		
								public string RegisterExternal(RegisterExternalBindingModel model)
					{
						
						return JsonConvert.DeserializeObject<string>("");
						

											}		
				
		}

			public class ValuesManager
		{

								public IEnumerable<string> Get()
					{
						
						return JsonConvert.DeserializeObject<IEnumerable<string>>("");
						

											}		
								public string Get(int id)
					{
						
						return JsonConvert.DeserializeObject<string>("");
						

											}		
								public void Post(string value)
					{
											}		
								public void Put(int id,string value)
					{
											}		
								public void Delete(int id)
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


				
				public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }


				
				public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }


								}

						public class ExternalLoginViewModel
				{

				
				public string Name { get; set; }


				
				public string Url { get; set; }


				
				public string State { get; set; }


								}

		}

