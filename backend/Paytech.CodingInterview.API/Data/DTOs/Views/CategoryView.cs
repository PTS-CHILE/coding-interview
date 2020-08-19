using System;

namespace Paytech.CodingInterview.API.Data.DTOs.Views
{
    public class CategoryView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomersCount { get; set; }
        public DateTime CreationDate { get; set; }
        public string FormattedCreationDate => string.Empty;
    }
}
