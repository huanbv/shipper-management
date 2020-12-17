using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace App.Infrastructure
{
    public class InterceptionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var user = context.HttpContext.User;
        }
    }
}
