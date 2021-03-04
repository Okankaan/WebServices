using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Programming.API.Attributes
{
    public class ApiExceptionAttributes : ExceptionFilterAttribute // This class using for send error response from just one class(Here :). So we don't need write try-catch to all methods of controllers.  
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage errorResponse = new HttpResponseMessage(System.Net.HttpStatusCode.NotImplemented);
            errorResponse.ReasonPhrase = actionExecutedContext.Exception.Message;
            actionExecutedContext.Response = errorResponse;
            base.OnException(actionExecutedContext);
        }
    }
}