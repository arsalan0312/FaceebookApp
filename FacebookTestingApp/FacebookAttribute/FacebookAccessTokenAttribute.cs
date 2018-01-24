using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace FacebookTestingApp.Tests.FacebookAttribute
{
   public class FacebookAccessTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ApplicationUserManager _userMnManager = filterContext.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

            if (_userMnManager != null)
            {
                var claimForUser = _userMnManager.GetClaimsAsync(filterContext.HttpContext.User.Identity.GetUserId());
                var access_token = claimForUser.Result.FirstOrDefault(x => x.Type == "FacebookAccessToken").Value;
                filterContext.HttpContext.Items.Add("access_token",access_token);
            }
            
          base.OnActionExecuting(filterContext);
        }
    }
}
