using System;
using System.Collections.Generic;

namespace BeckonedPath.Data.Models
{
    public partial class Events
    {
        public Events()
        {
            EventComments = new HashSet<EventComments>();
        }

        public int EventId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime EventDate { get; set; }
        public int UserId { get; set; }

        public Users User { get; set; }
        public ICollection<EventComments> EventComments { get; set; }
    }
}
