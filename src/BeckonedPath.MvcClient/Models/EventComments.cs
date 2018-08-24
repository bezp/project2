using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeckonedPath.MvcClient.Models
{
    public class EventComments
    {
        public int EventCommentId { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }

        public Events Event { get; set; }
        public Users User { get; set; }
    }
}
