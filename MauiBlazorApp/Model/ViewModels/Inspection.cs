﻿using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorApp.Model.ViewModels
{
    public class InspectionResponseModel
    {
        [PrimaryKey]
        public string caseID { get; set; }
        public string caseNo { get; set; }
        public string projectNo { get; set; }
        public string plotNo { get; set; }
        public string fullName { get; set; }
    }
}
