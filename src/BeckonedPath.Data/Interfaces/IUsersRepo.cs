using BeckonedPath.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeckonedPath.Data.Interfaces
{
    public interface IUsersRepo
    {

        IEnumerable<Users> ListAll();
        void GetOne<Users>(int id);
        void Add(Users users);

    }
}
