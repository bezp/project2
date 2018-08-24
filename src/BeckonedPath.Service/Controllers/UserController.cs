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
    public class UserController : Controller
    {

        private readonly IUsersRepo _usersRepo;

        public UserController(IUsersRepo usersRepo)
        {
            _usersRepo = usersRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_usersRepo.ListAll());
        }

        [HttpGet("{id:int?}")]
        public IActionResult Users(int? id)
        {
            if (id > 0)
            {
                return Ok(_usersRepo.GetOne<Users>(id));
            }
            else
            {
                return Ok(_usersRepo.ListAll());
            }
        }

        [HttpPost]
        public void Create()
        {
            Task.WaitAny();
            var x = new StreamReader(Request.Body).ReadToEnd();
            var userToAdd = JsonConvert.DeserializeObject<Users>(x);
            Task.WaitAny();

            _usersRepo.Add(userToAdd);
        }

    }
}
