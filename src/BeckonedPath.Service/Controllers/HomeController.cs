using BeckonedPath.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeckonedPath.Service.Controllers
{
    public class HomeController : Controller
    {
        private readonly Project2Context _context;

        public HomeController(Project2Context context)
        {
            _context = context;
        }


        public IActionResult Index()
        {


            var userList = _context.Users//.ToList();
                .Include(u => u.Events)
                .ToList();
            ViewBag.xuserList = userList;



            var userJson = JsonConvert.SerializeObject(userList, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            ViewBag.userJson = userJson;


            return View();
        }

    }
}
