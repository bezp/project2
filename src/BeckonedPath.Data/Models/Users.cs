using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BeckonedPath.Data.Models;

namespace BeckonedPath.Data.Models
{
    public partial class Users
    {
        public Users()
        {
            EventComments = new HashSet<EventComments>();
            Events = new HashSet<Events>();
        }

        public int UserId { get; set; } 
        
        [StringLength(50, MinimumLength = 1)]
        public string FirstMidName { get; set; }
        
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        public ICollection<EventComments> EventComments { get; set; }
        public ICollection<Events> Events { get; set; }


        public bool CreateEvent()
        {
            try
            {
                Events.Add(new Events());
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public void CancelEvent()
        {
            Events.Remove(Events.Last());
        }

        public ICollection<Events> ViewEventHistory()
        {
            return Events.AsEnumerable().ToList();
        }

        //public Events Create()
        //{
        //    Events.Add(new Events() { Description = "Party Rock" });
        //}

    }
}
