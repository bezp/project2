using BeckonedPath.Library.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BeckonedPath.Library.Interfaces
{
    public interface IUserRepo
    {
        IEnumerable ListAll(Users users);

        void Add();

    }
}
