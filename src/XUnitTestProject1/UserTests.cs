using BeckonedPath.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class UserTests
    {
        private Users sut;

        public UserTests()
        {
            sut = new Users()
            {
                FirstMidName = "Ben",
                LastName = "Franklin",          
            };     
        }

        [Fact]
        public void Test_UserFirstMidName()
        {
            Assert.IsType<string>(sut.FirstMidName);
        }

        [Fact]
        public void Test_UserLastName()
        {
            Assert.IsType<string>(sut.LastName);
        }

        [Fact]
        public void Test_UserNameNotNull()
        {
            Assert.NotNull(sut.FirstMidName);
        }

        [Fact]
        public void Test_UsetLastNameNotNull()
        {
            Assert.NotNull(sut.LastName);
        }

        [Fact]
        public void Test_FirstMidNameLength()
        {         
            Assert.True(sut.FirstMidName.Length < 50);            
        }

        [Fact]
        public void Test_LastNameLength()
        {
            Assert.True(sut.LastName.Length < 50);
        }

        [Fact]
        public void Test_UserCreateEvent()
        {
            sut.CreateEvent();
            Assert.True(sut.CreateEvent());            
        }

        [Fact]
        public void Test_UserViewEventHistory()
        {
            sut.CreateEvent();
            Assert.True(1 == sut.ViewEventHistory().Count());
        }

        [Fact]
        public void CancelEvent()
        {
            sut.CreateEvent();
            sut.CancelEvent();
            Assert.True(0 == sut.ViewEventHistory().Count());
        }       
    }
}
