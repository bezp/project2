using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeckonedPath.MvcClient.Models
{
    public class Events
    {
        public int EventId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; }
        public int UserId { get; set; }

        public Users User { get; set; }
        public ICollection<EventComments> EventComments { get; set; }
    }
}
