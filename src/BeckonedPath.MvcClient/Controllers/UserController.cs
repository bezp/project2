﻿using BeckonedPath.MvcClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeckonedPath.MvcClient.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var client = new HttpClient();
            var result = client.GetAsync("http://localhost:50322/api/user/users/").GetAwaiter().GetResult();

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
            var result = client.GetAsync($"http://localhost:50322/api/user/users/{id}").GetAwaiter().GetResult();

            if (result.IsSuccessStatusCode)
            {
                var lis = JsonConvert.DeserializeObject<List<Users>>(result.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                ViewBag.wot = lis;
                ViewBag.wotId = id;
                return View();
            }
            else
            {
                ViewBag.wot = "Sorry it did not work";
                return View();
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstMidName,LastName")] Users user)
        {
            try
            {
                var client = new HttpClient();
                var jsonString = JsonConvert.SerializeObject(user);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:50322/api/user/create/", content);

                return RedirectToAction("/index");
            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
}
