using BeckonedPath.MvcClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BeckonedPath.MvcClient.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var client = new HttpClient();
            var result = client.GetAsync("http://localhost:50320/api/user/users/").GetAwaiter().GetResult();

            if (result.IsSuccessStatusCode)
            {
                var lis = JsonConvert.DeserializeObject<List<Users>>(result.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                ViewBag.wot = lis;
                return View();
            }
            else
            {
                ViewBag.wot = "Sorry it did not work";
                return View();
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Index(int id)
        {
            var client = new HttpClient();
            var result = client.GetAsync($"http://localhost:50320/api/user/users/{id}").GetAwaiter().GetResult();

            if (result.IsSuccessStatusCode)
            {
                var lis = JsonConvert.DeserializeObject<List<Users>>(result.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                ViewBag.wot = lis;
                return View();
            }
            else
            {
                ViewBag.wot = "Sorry it did not work";
                return View();
            }

            //if (id > 0)
            //{
            //    var result = client.GetAsync($"http://localhost:50320/api/user/users/{id}").GetAwaiter().GetResult();

            //    if (result.IsSuccessStatusCode)
            //    {
            //        var lis = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            //        ViewBag.wot = lis;
            //        return View();
            //    }
            //    else
            //    {
            //        ViewBag.wot = "Sorry it did not work";
            //        return View();
            //    }
            //}
            //else
            //{
            //    var result = client.GetAsync("http://localhost:50320/api/user/users/").GetAwaiter().GetResult();

            //    if (result.IsSuccessStatusCode)
            //    {
            //        var lis = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            //        ViewBag.wot = lis;
            //        return View();
            //    }
            //    else
            //    {
            //        ViewBag.wot = "Sorry it did not work";
            //        return View();
            //    }
            //}


        }

    }
}
