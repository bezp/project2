using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeckonedPath.MvcClient.Models
{
    public class Users
    {
        public int UserId { get; set; }
        [Required]
        public string FirstMidName { get; set; }
        [Required]
        public string LastName { get; set; }

        public ICollection<EventComments> EventComments { get; set; }
        public ICollection<Events> Events { get; set; }
    }
}
