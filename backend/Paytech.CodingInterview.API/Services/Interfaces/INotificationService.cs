using System.Collections.Generic;

namespace Paytech.CodingInterview.API.Services.Interfaces
{
    public interface INotificationService
    {
        void AddValidation(string message);
        bool HasValidations();
        ICollection<string> GetValidations();
    }
}