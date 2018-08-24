using BeckonedPath.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BeckonedPath.Testing.Data
{
    public class EventCommentsTest
    {
        private EventComments sut;

        public EventCommentsTest()
        {
            sut = new EventComments()
            {
                Description = "I would love to attend",                
            };
        }

        [Fact]
        public void Test_DescriptionType()
        {
            Assert.IsType<string>(sut.Description);
        }

        [Fact]
        public void Test_Description()
        {
            Assert.NotNull(sut.Description);
        }
    }
}
