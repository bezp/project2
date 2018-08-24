using BeckonedPath.Data.Interfaces;
using BeckonedPath.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeckonedPath.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class EventCommentsController : Controller
    {
        private readonly IEventCommentsRepo _eventCommentsRepo;
        public EventCommentsController(IEventCommentsRepo eventCommentsRepo)
        {
            _eventCommentsRepo = eventCommentsRepo;
        }


        [HttpGet("{id:int?}")]
        public IActionResult EventComments(int? id)
        {
            if (id > 0)
            {
                return Ok(_eventCommentsRepo.GetAllForEvent<EventComments>(id));
            }
            else
            {
                return Ok(_eventCommentsRepo.ListAll());
            }
        }


    }
}
