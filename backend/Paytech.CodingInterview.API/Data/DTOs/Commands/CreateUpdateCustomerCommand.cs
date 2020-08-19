namespace Paytech.CodingInterview.API.Data.DTOs.Commands
{
    public class CreateUpdateCustomerCommand : BaseCommand
    {
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public int CategoryId { get; set; }

        public override bool IsValid()
        {
            return
                !string.IsNullOrEmpty(Name) &&
                !string.IsNullOrEmpty(DocumentNumber) &&
                CategoryId != default;
        }
    }
}
