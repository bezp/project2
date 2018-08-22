using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BeckonedPath.Data.Models
{
    public class DataHelper
    {
        //public DataHelper()
        //{ }

        private readonly Project2Context _context;

        public DataHelper(Project2Context context)
        {
            _context = context;
        }



        //private static Project2Context context = new Project2Context();

        public List<Users> GetUsers()
        {


            return _context.Users.ToList();
        }

    }
}
