using OTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OTS.Authentication
{
    

    public class AuthenticateAdminSession : ActionFilterAttribute
    {
       
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var session = filterContext.HttpContext.Session;
                var userSession = session["User"] as User;
                if (userSession.ID > 0)
                    return;

                //Redirect to login.
                var redirectTarget = new RouteValueDictionary { { "action", "Login" }, { "controller", "Login" } };
                filterContext.Result = new RedirectToRouteResult(redirectTarget);
            }
            catch (Exception)
            {

                var redirectTarget = new RouteValueDictionary { { "action", "Login" }, { "controller", "Login" } };
                filterContext.Result = new RedirectToRouteResult(redirectTarget);

            }

        }
    }


    
}