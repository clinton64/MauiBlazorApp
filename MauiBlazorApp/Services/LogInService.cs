using System.Text;
using MauiBlazorApp.Model;
using System.Text.Json;

namespace MauiBlazorApp.Services
{
    public class LogInService
    {
        public string _loginURL = "https://ecptest.uru.gov.bd/frcm/Accounts/token";

        public Task<HttpResponseMessage> LoginVerify(LoginModel loginModel)
        {
            var client = new HttpClient();
            var json = JsonSerializer.Serialize(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync(_loginURL, content);
            return response;
        }
    }
}
