
	using System.Collections.Generic;
	using System.Threading.Tasks;

	namespace WebApiClients
	{
			public class AccountManager
		{

								public UserInfoViewModel GetUserInfo()
					{
						
						var result = new UserInfoViewModel();
						
						return result;

											}		
								public string Logout()
					{
						
						var result = new string();
						
						return result;

											}		
								public void VoidMethodExample()
					{
											}		
								public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl,bool generateState)
					{
						
						var result = new async Task<ManageInfoViewModel>();
						
						return result;

											}		
								public async Task<string> ChangePassword(ChangePasswordBindingModel model)
					{
						
						var result = new async Task<string>();
						
						return result;

											}		
								public async Task<string> SetPassword(SetPasswordBindingModel model)
					{
						
						var result = new async Task<string>();
						
						return result;

											}		
								public async Task<string> AddExternalLogin(AddExternalLoginBindingModel model)
					{
						
						var result = new async Task<string>();
						
						return result;

											}		
								public async Task<string> RemoveLogin(RemoveLoginBindingModel model)
					{
						
						var result = new async Task<string>();
						
						return result;

											}		
								public async Task<string> GetExternalLogin(string provider,string error)
					{
						
						var result = new async Task<string>();
						
						return result;

											}		
								public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl,bool generateState)
					{
						
						var result = new IEnumerable<ExternalLoginViewModel>();
						
						return result;

											}		
								public async Task<string> Register(RegisterBindingModel model)
					{
						
						var result = new async Task<string>();
						
						return result;

											}		
								public async Task<string> RegisterExternal(RegisterExternalBindingModel model)
					{
						
						var result = new async Task<string>();
						
						return result;

											}		
				
		}

			public class ValuesManager
		{

								public IEnumerable<string> Get()
					{
						
						var result = new IEnumerable<string>();
						
						return result;

											}		
								public string Get(int id)
					{
						
						var result = new string();
						
						return result;

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

