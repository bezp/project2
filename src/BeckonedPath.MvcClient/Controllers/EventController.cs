using BeckonedPath.Data.Models;
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
    public class EventController : Controller
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

        [HttpGet("{id:int}")]
        public IActionResult Index(int id)
        {
            var client = new HttpClient();
            try
            {
                var result = client.GetAsync($"http://localhost:50322/api/event/events/{id}").GetAwaiter().GetResult();
                //Task.WaitAll();
                if (result.IsSuccessStatusCode)
                {
                    var listOfEvents = JsonConvert.DeserializeObject<List<Events>>(result.Content.ReadAsStringAsync().GetAwaiter().GetResult(),
                        new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                    var eventId = listOfEvents[0].EventId;
                    var eCommentsString = client.GetAsync($"http://localhost:50322/api/eventcomments/eventcomments/{eventId}").GetAwaiter().GetResult();

                    var listOfEComments = JsonConvert.DeserializeObject<List<EventComments>>(eCommentsString.Content.ReadAsStringAsync().GetAwaiter().GetResult(),
                        new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

                    ViewBag.eComments = listOfEComments;

                    ViewBag.listOfEvents = listOfEvents;
                    return View();
                }
                else
                {
                    ViewBag.listOfEvents = "Sorry it did not work";
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Location,EventDate,UserId")] Events newEvent)
        {
            try
            {
                var client = new HttpClient();
                var jsonString = JsonConvert.SerializeObject(newEvent);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:50322/api/event/create/", content);

                return RedirectToAction("/index");
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
