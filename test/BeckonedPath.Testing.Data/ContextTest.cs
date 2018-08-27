using beckonedpath.data.models;
using system;
using system.collections.generic;
using system.text;
using xunit;

namespace beckonedpath.testing.data
{
    public class ContextTest
    {
        private mockproject2context _sut = new mockproject2context();
        private project2context _sut2 = new project2context();
        private events _sut3 = new events();

        private eventcomments _sut4 = new eventcomments();

        [Fact]
        public void event_verify_mock()
        {
            _sut.saveevents(_sut3);
            assert.equal(_sut3, _sut.readevents(_sut3.eventid));
        }

        [Fact]
        public void comment_verify_mock()
        {
            _sut.savecomments(_sut4);
            assert.equal(_sut4, _sut.readcomments(_sut4.eventcommentid));
        }

        [Fact]
        public void event_verify_sql()
        {
            _sut3 = new events()
            {
                eventcomments = new list<eventcomments>(),
                description = "party rock",
                eventdate = convert.todatetime("8/22/18"),
                location = "revature",
                user = new users()
                {
                    firstmidname = "litty",
                    events = new list<events>(),
                    eventcomments = new list<eventcomments>(),
                    lastname = "warren"
                }
            };
            _sut2.saveevents(_sut3);
            assert.equal(_sut3, _sut2.readevents(_sut3.eventid));
        }
    }
}
