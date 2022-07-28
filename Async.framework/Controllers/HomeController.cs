using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Async.framework.Models;

namespace Async.framework.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            // Console.WriteLine("b:"+ Request.RequestContext.HttpContext.GetHashCode());
            Console.WriteLine("b:"+ System.Threading.SynchronizationContext.Current.GetHashCode());
            var whatAspNetFrameworkNormal = new WhatAspNetFrameworkNormal();
            // Console.WriteLine("b1:"+ Request.RequestContext.HttpContext.GetHashCode());
            Console.WriteLine("b1:"+ System.Threading.SynchronizationContext.Current.GetHashCode());

            var bothAsync = await whatAspNetFrameworkNormal.GetBothAsync("https://www.google.com", "https://www.google.com");
        
            if (bothAsync.Count.Equals(1))
            {
                Console.WriteLine("oh no");
            }
            
            // Console.WriteLine("a:"+Request.RequestContext.HttpContext.GetHashCode());
            Console.WriteLine("a:"+ System.Threading.SynchronizationContext.Current.GetHashCode());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}