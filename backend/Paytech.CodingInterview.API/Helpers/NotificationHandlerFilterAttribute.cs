using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Paytech.CodingInterview.API.Services.Interfaces;

namespace Paytech.CodingInterview.API.Helpers
{
    public class NotificationHandlerFilterAttribute : ActionFilterAttribute
    {
        private readonly INotificationService _notificationService;

        public NotificationHandlerFilterAttribute(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (_notificationService.HasValidations())
            {
                context.HttpContext.Response.StatusCode = 400;
                context.Result = new JsonResult(_notificationService.GetValidations());
            }

            base.OnActionExecuted(context);
        }
    }
}
