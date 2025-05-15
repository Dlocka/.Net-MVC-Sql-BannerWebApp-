using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MVCWork.Web.Filters
{
    public class UserLoginFilter:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute),true))
            {
                return;
            }
            HttpSessionStateBase session =
               filterContext.HttpContext.Session;
            if (session["LogedUser"] == null)
            {
                //跳转回登录页面
                filterContext.Result = new RedirectResult("~/Users/login");
            }
            
        }
    }
}