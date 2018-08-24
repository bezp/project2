using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeckonedPath.Data.Interfaces;
using BeckonedPath.Library.Interfaces;
using BeckonedPath.Library.Models;

namespace BeckonedPath.Data.Models
{
    public class UsersRepo : IUsersRepo
    {

        private readonly Project2Context _db;
        public UsersRepo(Project2Context context)
        {
            _db = context;
        }

        public void Add(Users users)
        {
            _db.Users.Add(users);
            _db.SaveChanges();
        }

        public void Delete(Users users)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Users> GetOne<T>(int? id)
        {
            return _db.Users.Where(u => u.UserId == id);
        }

        public IEnumerable<Users> ListAll()
        {
            return _db.Users.AsEnumerable();
        }

        public void Update(Users users)
        {
            throw new NotImplementedException();
        }
    }
}
