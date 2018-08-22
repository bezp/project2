using BeckonedPath.Data.Models;
using Microsoft.AspNetCore.Mvc;
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

        //DataHelper dataHelper = new DataHelper();


        //public List<Users> GetUsers()
        //{
        //    return dataHelper.GetUsers();
        //}

        public IActionResult Index()
        {
            var asd = _context.Users.ToList();//.GetUsers();
            //var asd = dataHelper.GetUsers();

            ViewBag.x = asd;

            //ViewBag.PageTitle = userViewModel.PageTitle;
            //ViewBag.asd = userViewModel;

            ////var user = from u in _db.Users
            ////               select u;
            //var x = _db.Users.FirstOrDefault();
            //ViewBag.DBStuff = x;

            return View();
        }

    }
}
