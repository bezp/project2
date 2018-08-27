using BeckonedPath.Data.Models;
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
            var client = new HttpClient();
            var result = client.GetAsync("http://localhost:50322/api/event/events/").GetAwaiter().GetResult();

            if (result.IsSuccessStatusCode)
            {
                var listOfEvents = JsonConvert.DeserializeObject<List<Events>>(result.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                ViewBag.listOfEvents = listOfEvents;
                return View();
            }
            else
            {
                ViewBag.listOfEvents = "Sorry it did not work";
                return View();
            }
        }


    }
}
