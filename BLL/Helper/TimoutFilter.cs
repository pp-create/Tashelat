using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

public class TimeoutFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var sessionUserId = context.HttpContext.Session.GetString("UserId");

        if (string.IsNullOrEmpty(sessionUserId))
        {
            // User is not authenticated; redirect to login page
            context.Result = new RedirectToActionResult("Index", "Login", null);
        }

        base.OnActionExecuting(context);
    }
}
