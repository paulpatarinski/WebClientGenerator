
	using System.Collections.Generic;
	using System.Threading.Tasks;

	namespace WebApiClients
	{
			public class AccountManager
		{

								public UserInfoViewModel GetUserInfo()
					{
						
					}		
								public string Logout()
					{
						
					}		
								public void VoidMethodExample()
					{
						
					}		
								public async Task<ManageInfoViewModel> GetManageInfo()
					{
						
					}		
								public async Task<string> ChangePassword()
					{
						
					}		
								public async Task<string> SetPassword()
					{
						
					}		
								public async Task<string> AddExternalLogin()
					{
						
					}		
								public async Task<string> RemoveLogin()
					{
						
					}		
								public async Task<string> GetExternalLogin()
					{
						
					}		
								public IEnumerable<ExternalLoginViewModel> GetExternalLogins()
					{
						
					}		
								public async Task<string> Register()
					{
						
					}		
								public async Task<string> RegisterExternal()
					{
						
					}		
				
		}

			public class ValuesManager
		{

								public IEnumerable<string> Get()
					{
						
					}		
								public string Get()
					{
						
					}		
								public void Post()
					{
						
					}		
								public void Put()
					{
						
					}		
								public void Delete()
					{
						
					}		
				
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

