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
                FileNo = "F-12312.123" + Random.Shared.Next(1, 9).ToString(),
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
    }
}

