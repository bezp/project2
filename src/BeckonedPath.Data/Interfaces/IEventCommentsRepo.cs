using BeckonedPath.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeckonedPath.Data.Interfaces
{
    public interface IEventCommentsRepo
    {
        IEnumerable<EventComments> ListAll();
        IQueryable<EventComments> GetOne<T>(int? id);
        void Add(EventComments eventComments);

        IQueryable<EventComments> GetAllForEvent<T>(int? id);
    }
}
