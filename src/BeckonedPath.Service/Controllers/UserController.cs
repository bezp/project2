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
    public class UserController : Controller
    {

        private readonly IUsersRepo _usersRepo;

        public UserController(IUsersRepo usersRepo)
        {
            _usersRepo = usersRepo;
        }

        public IActionResult Index()
        {
            var characters = _usersRepo.ListAll();
            ViewBag.x = characters;
            return View();
            //return View();
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

    }
}
