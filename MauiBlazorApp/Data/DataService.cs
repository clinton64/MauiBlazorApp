
using MauiBlazorApp.Model.ViewModels;

namespace MauiBlazorApp.Data
{
    public class DataService
    {
        private DatabaseLocal _dbLocal;
        private FRCM_API_Service _apiService;
        public DataService(DatabaseLocal dbLocal, FRCM_API_Service service) 
        {
            _dbLocal = dbLocal;
            _apiService = service;
        }
        public async Task<List<InspectionResponseModel>> GetData() 
        {
            List<InspectionResponseModel> data = new ();
            if (_apiService.InternetConnection())
            {
                data = await _apiService.GetInspections();
                foreach(var inspection in data)
                {
                    await _dbLocal.SaveInspectionAsync(inspection);
                }
            }
            else
            {
                data = await _dbLocal.GetInspectionsAsync();
            }
            return data;
        }
    }
}
