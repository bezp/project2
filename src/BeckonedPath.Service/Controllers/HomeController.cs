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
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
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

        [HttpGet("{id:int?}")]
        public IActionResult Users(int? id)
        {
            if (id > 0)
            {
                return Ok(_context.Users.Where(u=>u.UserId == id));
            }
            else
            {
                return Ok(_context.Users.ToList());
            }
        }
        //[HttpGet("{id:int}")]//
        //public IActionResult Users(int id)
        //{
        //    return Ok(_context.Users.Where(u=> u.UserId == id));
        //}

        [HttpGet("{id:int?}")]
        public IActionResult Events(int? id)
        {
            if (id > 0)
            {
                return Ok(_context.Events.Where(u => u.EventId == id));
            }
            else
            {
                return Ok(_context.Events.ToList());
            }
        }

        [HttpGet("{id:int?}")]
        public IActionResult EComments(int? id)
        {
            if (id > 0)
            {
                return Ok(_context.EventComments.Where(u => u.EventCommentId == id));
            }
            else
            {
                return Ok(_context.EventComments.ToList());
            }
            //return Ok(_context.EventComments.ToList());
        }


    }
}
