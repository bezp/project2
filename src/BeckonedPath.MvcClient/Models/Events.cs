using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeckonedPath.MvcClient.Models
{
    public class Events
    {
        public int EventId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        public int UserId { get; set; }

        public Users User { get; set; }
        public ICollection<EventComments> EventComments { get; set; }
    }
}
