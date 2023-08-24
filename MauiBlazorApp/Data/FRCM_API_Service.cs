using MauiBlazorApp.Model;
using MauiBlazorApp.Model.ViewModels;
using MauiBlazorApp.Services;
using System.Text;



namespace MauiBlazorApp.Data
{
    public class FRCM_API_Service
    {
        private readonly HttpClient _client;
        private readonly string _baseURL = "https://ecptest.uru.gov.bd/frcm";
        public List<InspectionResponseModel> Inspections {  get; private set; }
        private CustomAuthenticationStateProvider _authStateProvider;
        private string _userId {  get; set; }

        public FRCM_API_Service(CustomAuthenticationStateProvider authStateProvider) { 
            _client = new HttpClient();
            _authStateProvider = authStateProvider;
        }
        public async Task<bool> LoginVerify(LoginModel loginModel)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = _client.PostAsync(_baseURL + "/Accounts/token", content);
                if (response.Result.IsSuccessStatusCode)
                {
                    var responseContent = response.Result.Content.ReadAsStringAsync();
                    var tokenResponse = System.Text.Json.JsonSerializer.Deserialize<TokenResponseModel>(responseContent.Result);
                    await _authStateProvider.Login(tokenResponse.token);
                    _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenResponse.token);
                    _userId = tokenResponse.userId;
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
        /*public async Task<List<InspectionResponseModel>> GetInspections()
        {
            _client.DefaultRequestHeaders.Add("inspectorId", _userId);
            HttpResponseMessage response = await _client.GetAsync(_baseURL+ "/Frcm/Inspections").ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                Inspections = JsonConvert.DeserializeObject<List<InspectionResponseModel>>(responseContent);                
            }
            return Inspections;
        }*/
    }
}
