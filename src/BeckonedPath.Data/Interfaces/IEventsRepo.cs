using BeckonedPath.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckonedPath.Data.Interfaces
{
    public interface IEventsRepo
    {
        IEnumerable<Events> ListAll();
        IQueryable<Events> GetOne<T>(int? id);
        void Add(Events events);

    }
}
