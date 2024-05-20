using CloneStackOverflow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace CloneStackOverflow.Filters
{
    public class AcesssAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessionUser = context.HttpContext.Session.GetString("sessionUserLogged");
            if (string.IsNullOrEmpty(sessionUser))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                var user = JsonConvert.DeserializeObject<User>(sessionUser);

                if (user == null) 
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }
                if (user.Profile != Enums.ProfileEnum.Admin) 
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Restrict" } });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
