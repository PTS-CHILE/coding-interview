using Microsoft.EntityFrameworkCore.Internal;
using Paytech.CodingInterview.API.Services.Interfaces;
using System.Collections.Generic;

namespace Paytech.CodingInterview.API.Services
{
    public class NotificationService : INotificationService
    {
        protected ICollection<string> Validations { get; set; }

        public NotificationService()
        {
            Validations = new List<string>();
        }

        public void AddValidation(string message)
        {
            Validations.Add(message);
        }

        public ICollection<string> GetValidations()
        {
            return Validations;
        }

        public bool HasValidations()
        {
            return Validations.Count > 0;
        }
    }
}
