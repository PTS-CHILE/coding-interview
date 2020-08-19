using System;

namespace Paytech.CodingInterview.API.Data.DTOs.Commands
{
    public class CreateUpdateCategoryCommand : BaseCommand
    {
        public string Name { get; set; }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Name);
        }
    }
}
