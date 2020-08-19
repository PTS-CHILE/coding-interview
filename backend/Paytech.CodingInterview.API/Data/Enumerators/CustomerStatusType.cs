using System.ComponentModel;

namespace Paytech.CodingInterview.API.Data.Enumerators
{
    public enum CustomerStatusType : byte
    {
        [Description("Aguardando aprovação")]
        WaitingForApproval = 1,

        [Description("Ativo")]
        Active = 2,

        [Description("Bloqueado")]
        Blocked = 3
    }
}
