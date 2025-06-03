using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NewsManagementSystemMVC.Filters
{
    public class AuthorizeUserAttribute : ActionFilterAttribute
    {
        private readonly string[] _roles;

        public AuthorizeUserAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var email = context.HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email))
            {
                context.Result = new RedirectToActionResult("Login", "Login", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
