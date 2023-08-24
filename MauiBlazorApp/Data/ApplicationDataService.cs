using MauiBlazorApp.Model.ViewModels;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace MauiBlazorApp.Data
{
    public class ApplicationDataService
    {
        public static ApplicationFile[] GetAppFiles(DateTime startDate) 
        {
            return Enumerable.Range(1, 15).Select(index => new ApplicationFile
            {
                FileNo = "F-12312.123" + Random.Shared.Next(1,9).ToString(),
                Name = "PD" + index.ToString(),
                Address = "Mirpur" + index.ToString(),
                AssginedDate = startDate.AddDays(index)
            }).ToArray();
        }

        public static InspectionResponseModel[] GetInspections()
        {
            return Enumerable.Range(1, 15).Select(index => new InspectionResponseModel
            {
                caseID = "F-12312.123" + Random.Shared.Next(1, 9).ToString(),
                caseNo = "Case" + index.ToString(),
                projectNo = "Porject" + index.ToString(),
                plotNo = "Plot" + index.ToString(),
                fullName = "PD" + index.ToString()
            }).ToArray();
        }

/*        public static async Task<InspectionResponseModel[]> LoadDataFromAPIAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string apiUrl = "https://ecptest.uru.gov.bd/frcm/Frcm/Inspections"; // Replace with your API endpoint URL

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIyMzYyQUNGRC1FMkJGLTRENTQtODU5NC1COTI2Q0I3Nzk1NjUiLCJ1bmlxdWVfbmFtZSI6InJhc2VkIiwianRpIjoiYTg0MTg4ZjQtNGUyZi00NTU4LWEzNjQtYTkxNjZlNzU4YTYzIiwiaWF0IjoiOC8yMi8yMDIzIDY6NTA6MTMgQU0iLCJleHAiOjE2OTUyNzkwMTMsImlzcyI6Imh0dHBzOi8vZWNwdGVzdC51cnUuZ292LmJkIiwiYXVkIjoiaHR0cHM6Ly9lY3B0ZXN0LnVydS5nb3YuYmQifQ.izzqAXWWG3G79N_izy2wybdELHTKqmTbv1yXYoIik6k");
                httpClient.DefaultRequestHeaders.Add("inspectorId", "2362ACFD-E2BF-4D54-8594-B926CB779565");
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl).ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    InspectionResponseModel[] inspectionResponses = JsonConvert.DeserializeObject<InspectionResponseModel[]>(responseContent);
                    return inspectionResponses;
                }
                return null;
            }
        }
*/    }
}
