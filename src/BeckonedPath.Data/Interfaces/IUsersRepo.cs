using BeckonedPath.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeckonedPath.Data.Interfaces
{
    public interface IUsersRepo
    {

        IEnumerable<Users> ListAll();
        IQueryable<Users> GetOne<T>(int? id);
        void Add(Users users);
        void Delete(Users users);
        void Update(Users users);
    }
}
