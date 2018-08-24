using BeckonedPath.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeckonedPath.Data.Models
{
    public class EventCommentsRepo : IEventCommentsRepo
    {
        private readonly Project2Context _db;
        public EventCommentsRepo(Project2Context context)
        {
            _db = context;
        }

        public void Add(EventComments eventComments)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EventComments> GetAllForEvent<T>(int? id)
        {
            return _db.EventComments.Where(ec => ec.EventId == id)
                .AsQueryable();
            //throw new NotImplementedException();
        }

        public IQueryable<EventComments> GetOne<T>(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventComments> ListAll()
        {
            return _db.EventComments.ToList();
            //throw new NotImplementedException();
        }
    }
}
