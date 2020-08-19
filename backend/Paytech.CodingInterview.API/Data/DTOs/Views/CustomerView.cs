using Paytech.CodingInterview.API.Data.Enumerators;
using Paytech.CodingInterview.API.Helpers;

namespace Paytech.CodingInterview.API.Data.DTOs.Views
{
    public class CustomerView
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public CustomerStatusType Status { get; set; }
        public string StatusDescription => Status.Description();
    }
}