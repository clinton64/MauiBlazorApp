using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorApp.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var userInfo = await SecureStorage.GetAsync("accountToken");
                if (userInfo != null)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, "ffUser") };
                    identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch(HttpRequestException ex) 
            {
                Console.WriteLine("Request failed : " + ex.ToString());
            }
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
        public async Task Login(string token, string userID)
        {
            await SecureStorage.SetAsync("accountToken", token);
            await SecureStorage.SetAsync ("userID", userID);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
        public async Task Logout()
        {
            SecureStorage.Remove("accountToken");
            SecureStorage.Remove("userID");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
        public async Task<string> userID()
        {
            return await SecureStorage.GetAsync("userID");
        }
        public async Task<string> token()
        {
            return await SecureStorage.GetAsync("accountToken");
        }
    }
}
