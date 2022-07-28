using System;
using System.Web.Mvc;
using Async.framework.Models;

namespace Async.framework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Console.WriteLine("b:"+ System.Web.HttpContext.Current.GetHashCode());
            // Console.WriteLine("b:"+ System.Threading.SynchronizationContext.Current.GetHashCode());
            // Console.WriteLine("b1:"+ System.Web.HttpContext.Current.GetHashCode());
            // Console.WriteLine("b1:"+ System.Threading.SynchronizationContext.Current.GetHashCode());

            var demoClientFramework = new DemoClientFramework();
            var bothAsync = demoClientFramework.GetBothAsync("https://www.google.com", "https://www.google.com").Result;
        
            if (bothAsync.Count.Equals(1))
            {
                throw new Exception("oh no, Thread run together!!!");
            }
            
            // Console.WriteLine("a:"+ HttpContext.Request.Url?.Host.GetHashCode());
            Console.WriteLine("a:"+ System.Web.HttpContext.Current.GetHashCode());
            // Console.WriteLine("a:"+Request.RequestContext.HttpContext.GetHashCode());
            // Console.WriteLine("a:"+ System.Threading.SynchronizationContext.Current.GetHashCode());
            return View();
        }

        public ActionResult Deadlock()
        {
            var demo = new demo();
            var result = demo.DeadlockAsync("https://www.google.com").Result.Substring(0,5);
            ViewBag.Message = "Your application get string from google: " + result;
            return View();
        }

        public ActionResult NoDeadlock()
        {
            var demo = new demo();
            var result = demo.NoDeadlockAsync("https://www.google.com").Result.Substring(0,5);
            ViewBag.Message = "Your application get string from google: " + result;
            return View();
        }
    }
}