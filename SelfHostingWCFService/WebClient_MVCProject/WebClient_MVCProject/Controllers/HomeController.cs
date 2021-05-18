using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClient_MVCProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public string GetMessage(string name)
        {
            using (HelloService.HelloServiceClient client = new HelloService.HelloServiceClient())
            {
                string message = client.GetMessage(name);
                return message;
            }
        }
    }
}