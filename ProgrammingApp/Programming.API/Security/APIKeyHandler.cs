using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Programming.API.Security
{
    public class APIKeyHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //var queryString = request.RequestUri.ParseQueryString();
            //var apiKey = queryString["apiKey"];//Get apiKey from URL-> http://localhost:50570/api/languages?apiKey=CF24D6C4-F3CA-4D70-A170-FB242AD996B7

            var apiKey = request.Headers.GetValues("apiKey").FirstOrDefault(); // Get apiKey from Header of request, not URL. -> apiKey: AED63F69-A30E-4AD4-884B-39840C58236B
            UsersDAL userDAL = new UsersDAL();
            var user = userDAL.GetUserByApiKey(apiKey); //GetUserByApiKey from DB
            if (user != null)
            {
                var principal = new ClaimsPrincipal(new GenericIdentity(user.Name, "APIKey"));//Create a principle object 
                HttpContext.Current.User = principal; //and assign the principle object to the user
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}