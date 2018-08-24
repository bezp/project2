using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeckonedPath.MvcClient.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }

        public ICollection<EventComments> EventComments { get; set; }
        public ICollection<Events> Events { get; set; }
    }
}
