using BeckonedPath.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BeckonedPath.Testing.Data
{
    public class EventTests
    {
        public DateTime EventDate { get; set; }
        public ICollection<EventComments> EventComments { get; set; }
        private Events sut;
        public Users User { get; set; }

        public EventTests()
        {

            sut = new Events()
            {
                User = new Users()
                {
                    FirstMidName = "Raul",
                    LastName = "Ramirez",                    
                },
                Description = "Graduation Party",
                Location = "Revature",
                EventDate = new DateTime(2018, 09, 14),                
            };
        }

        [Fact]
        public void Test_EventHasDescription()
        {
            Assert.NotNull(sut.Description);
        }

        [Fact]
        public void Test_EventDescriptionType()
        {
            Assert.IsType<String>(sut.Description);
        }

        [Fact]
        public void Test_EventHasLocation()
        {
            Assert.NotNull(sut.Location);
        }

        [Fact]
        public void Test_EventLocationType()
        {
            Assert.IsType<String>(sut.Location);
        }

        [Fact]
        public void Test_EventEventDateIsType()
        {
            Assert.IsType<DateTime>(sut.EventDate);            
        }

        [Fact]
        public void Test_EventHasUserName()
        {
            Assert.NotNull(sut.User.FirstMidName);
        }

        [Fact]
        public void Test_EventUserNameIsType()
        {
            Assert.IsType<string>(sut.User.FirstMidName);
        }

        [Fact]
        public void Test_EventHasUserLastName()
        {
            Assert.NotNull(sut.User.LastName);
        }

        [Fact]
        public void Test_EventUserLastNameIsType()
        {
            Assert.IsType<string>(sut.User.LastName);
        }

    }
     
    
}
