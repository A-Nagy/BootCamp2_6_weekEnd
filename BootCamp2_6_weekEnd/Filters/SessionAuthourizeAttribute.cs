using Microsoft.AspNetCore.Mvc.Filters;

namespace BootCamp2_6_weekEnd.Filters
{
    public class SessionAuthourizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var username = context.HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(username))
            {
                context.HttpContext.Response.Redirect("/Accounts/Login");
            }
            base.OnActionExecuting(context);
        }
    }
}
