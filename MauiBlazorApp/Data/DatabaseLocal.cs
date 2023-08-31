using MauiBlazorApp.Model.ViewModels;
using SQLite;

namespace MauiBlazorApp.Data
{
    public class DatabaseLocal
    {
        SQLiteAsyncConnection Database;
        public DatabaseLocal() { }
        async Task Init()
        {
            if (Database is null)
            {
                Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            }
            var tableInspectionExists = Database.TableMappings.Any(x => x.MappedType.Name == typeof(Phase1).Name);
            if (!tableInspectionExists)
            {
                await Database.CreateTableAsync<InspectionResponseModel>();
            }
        }
        public async Task<List<InspectionResponseModel>> GetInspectionsAsync()
        {
            await Init();
            return await Database.Table<InspectionResponseModel>().ToListAsync();
        }
        public async Task<InspectionResponseModel> GetInspectionAsync(string caseID)
        {
            await Init();
            return await Database.Table<InspectionResponseModel>().Where(t => t.caseID == caseID).FirstOrDefaultAsync();
        }
        public async Task<int> SaveInspectionAsync(InspectionResponseModel response)
        {
            await Init();
            if(response != null && response.caseID != null)
            {
                var localObject = await Database.Table<InspectionResponseModel>().FirstOrDefaultAsync(t => t.caseID == response.caseID);
                if(localObject != null)
                {
                    return await Database.UpdateAsync(response);
                }
                return await Database.InsertAsync(response);
            }
            return 0;
            
        }
        public async Task<int> DeleteItemAsync(InspectionResponseModel response)
        {
            await Init();
            return await Database.DeleteAsync(response);
        }
        
    }
}
