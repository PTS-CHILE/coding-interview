using Paytech.CodingInterview.API.Data.Enumerators;
using Paytech.CodingInterview.API.Helpers;
using Paytech.CodingInterview.API.Services.Interfaces;
using System.Collections.Generic;

namespace Paytech.CodingInterview.API.Services
{
    public class CommonService : ICommonService
    {
        public IDictionary<byte, string> GetCustomerStatusValues()
        {
            return new Dictionary<byte, string>()
            {
                { (byte)CustomerStatusType.Active, CustomerStatusType.Active.Description() },
                { (byte)CustomerStatusType.Blocked, CustomerStatusType.Blocked.Description() },
                { (byte)CustomerStatusType.WaitingForApproval, CustomerStatusType.WaitingForApproval.Description() }
            };
        }
    }
}
