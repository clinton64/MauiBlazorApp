using SQLite;

namespace MauiBlazorApp.Model.ViewModels
{
    public class Phase1
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
        public DateTime modifiedOn { get; set; }
    }
}
