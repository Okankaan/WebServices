using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Programming.API.Security
{
    public class APIAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var actionRoles = Roles; // roles of methods is came "A", "U" from -> [APIAuthorize(Roles = "A,U")]
            var userName = HttpContext.Current.User.Identity.Name; // User.Identity.Name is came from apiKey
            UsersDAL userDAL = new UsersDAL();
            var user = userDAL.GetUsersByName(userName);
            if (user != null && actionRoles.Contains(user.Role))
            {

            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}