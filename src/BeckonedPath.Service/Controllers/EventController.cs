using BeckonedPath.Data.Interfaces;
using BeckonedPath.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BeckonedPath.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class EventController : Controller
    {
        private readonly IEventsRepo _eventsRepo;
        public EventController(IEventsRepo eventsRepo)
        {
            _eventsRepo = eventsRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_eventsRepo.ListAll());
        }

        [HttpGet("{id:int?}")]
        public IActionResult Events(int? id)
        {
            if (id > 0)
            {
                return Ok(_eventsRepo.GetOne<Events>(id));
            }
            else
            {
                return Ok(_eventsRepo.ListAll());
            }
        }

        [HttpPost]
        public void Create()
        {
            Task.WaitAny();
            var x = new StreamReader(Request.Body).ReadToEnd();
            //Console.WriteLine(x);
            //Console.WriteLine(x);
            //Console.WriteLine(x);
            //Console.WriteLine(x);
            //Console.WriteLine(x);
            var eventToAdd = JsonConvert.DeserializeObject<Events>(x);
            Task.WaitAny();

            _eventsRepo.Add(eventToAdd);
        }




    }
}
