using MauiBlazorApp.Model;
using MauiBlazorApp.Model.ViewModels;
using MauiBlazorApp.Services;
using System.Net;
using System.Text;
using System.Text.Json;

namespace MauiBlazorApp.Data
{
    public class FRCM_API_Service
    {
        private readonly HttpClient _client;
        private readonly string _baseURL = "https://ecptest.uru.gov.bd/frcm";
        private CustomAuthenticationStateProvider _authStateProvider;
        public List<InspectionResponseModel> Inspections = new();
        public FRCM_API_Service(CustomAuthenticationStateProvider authStateProvider) { 
            _client = new HttpClient();
            _authStateProvider = authStateProvider;
        }
        public async Task<bool> LoginVerify(LoginModel loginModel)
        {
            var json = JsonSerializer.Serialize(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = _client.PostAsync(_baseURL + "/Accounts/token", content);
                if (response.Result.IsSuccessStatusCode)
                {
                    var responseContent = response.Result.Content.ReadAsStringAsync();
                    var tokenResponse = JsonSerializer.Deserialize<TokenResponseModel>(responseContent.Result);                 
                    await _authStateProvider.Login(tokenResponse.token, tokenResponse.userId);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public async Task Logout()
        {
            await _authStateProvider.Logout();
        }
        public async Task<List<InspectionResponseModel>> GetInspections()
        {            
            _client.DefaultRequestHeaders.Add("inspectorId", await SecureStorage.GetAsync("userID"));
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await SecureStorage.GetAsync("accountToken"));
            HttpResponseMessage response = await _client.GetAsync(_baseURL + "/Frcm/Inspections").ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                Inspections = JsonSerializer.Deserialize<List<InspectionResponseModel>>(responseContent);
            }
            return Inspections;
        }
        public bool InternetConnection()
        {
            var currentStatus = Connectivity.NetworkAccess;
            return currentStatus == NetworkAccess.Internet;
        }
    }
}
