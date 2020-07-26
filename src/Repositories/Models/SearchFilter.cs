namespace Repositories.Models
{
    public class SearchFilter
    {
        public string Location { get; set; }

        public int? Period { get; set; }

        public string GetLog() => $"(Location = '{Location}', Period = {Period})";
    }

    public class ExaminationTypeModel
    {
        public string ExaminationType { get; set; }
        public string ExaminationName { get; set; }
        public string ConnectionString { get; set; }
    }
}
