using System;
using System.Collections.Generic;

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
        public string FirstMidName { get; set; }
        public string LastName { get; set; }

        public ICollection<EventComments> EventComments { get; set; }
        public ICollection<Events> Events { get; set; }
    }
}
