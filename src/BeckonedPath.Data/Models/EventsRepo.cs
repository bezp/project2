using BeckonedPath.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeckonedPath.Data.Models
{
    public class EventsRepo : IEventsRepo
    {
        private readonly Project2Context _db;
        public EventsRepo(Project2Context context)
        {
            _db = context;
        }

        public void Add(Events events)
        {
            _db.Events.Add(events);
            _db.SaveChanges();
            //throw new NotImplementedException();
        }

        public IQueryable<Events> GetOne<T>(int? id)
        {
            var eventAndComments = _db.Events
                .Where(e => e.EventId == id);

            return eventAndComments;
                //_db.Events.Where(e => e.EventId == id);
            //throw new NotImplementedException();
        }

        public IEnumerable<Events> ListAll()
        {
            return _db.Events.AsEnumerable();
            //throw new NotImplementedException();
        }
    }
}
