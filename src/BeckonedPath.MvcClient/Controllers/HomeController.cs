using BeckonedPath.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BeckonedPath.MvcClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //HomeController homeController = new HomeController();

            //var result = homeController.Index();

            //var list = JsonConvert.DeserializeObject(result);
            //ViewBag.wot = list; 

            var client = new HttpClient();
            var result = client.GetAsync("http://localhost:50322/api/home/users").GetAwaiter().GetResult();

            if (result.IsSuccessStatusCode)
            {
                var lis = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                ViewBag.wot = lis;
                return View();
            } else
            {
                ViewBag.wot = "asd";
                return View();
            }


        }
    }
}
