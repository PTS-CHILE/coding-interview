using System.Collections.Generic;

namespace Paytech.CodingInterview.API.Services.Interfaces
{
    public interface ICommonService
    {
        IDictionary<byte, string> GetCustomerStatusValues();
    }
}
