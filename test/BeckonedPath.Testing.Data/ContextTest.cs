//using BeckonedPath.Data.Models;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xunit;

//namespace BeckonedPath.Testing.Data
//{
//    public class ContextTest
//    {
//        private MockProject2Context _sut = new MockProject2Context();
//        private Project2Context _sut2 = new Project2Context();

//        private Events _sut3 = new Events();

//        private EventComments _sut4 = new EventComments();

//        [Fact]
//        public void Event_Verify_Mock()
//        {
//            _sut.SaveEvents(_sut3);
//            Assert.Equal(_sut3, _sut.ReadEvents(_sut3.EventId));
//        }

//        [Fact]
//        public void Comment_Verify_Mock()
//        {
//            _sut.SaveComments(_sut4);
//            Assert.Equal(_sut4, _sut.ReadComments(_sut4.EventCommentId));
//        }

//        [Fact]
//        public void Event_Verify_SQL()
//        {
//            _sut3 = new Events()
//            {
//                EventComments = new List<EventComments>(),
//                Description = "Party Rock",
//                EventDate = Convert.ToDateTime("8/22/18"),
//                Location = "Revature",
//                User = new Users()
//                {
//                    FirstMidName = "Litty",
//                    Events = new List<Events>(),
//                    EventComments = new List<EventComments>(),
//                    LastName = "Warren",

//                }
//            };


//            _sut2.SaveEvents(_sut3);
//            Assert.Equal(_sut3, _sut2.ReadEvents(_sut3.EventId));
//        }

//    }
//}
