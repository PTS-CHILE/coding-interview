using System;
using System.Linq;

namespace Paytech.CodingInterview.API.Helpers
{
    public static class EnumeratorExtensions
    {
        public static string Description(this Enum value)
        {
            // get attributes  
            var field = value.GetType().GetField(value.ToString());
            if (field != null)
            {
                var attributes = field.GetCustomAttributes(false);

                // Description is in a hidden Attribute class called DisplayAttribute
                // Not to be confused with DisplayNameAttribute
                dynamic displayAttribute = null;

                if (attributes.Any())
                    displayAttribute = attributes.ElementAt(0);

                // return description
                return displayAttribute?.Description ?? value.ToString();
            }

            return string.Empty;
        }
    }
}
