using System;
using NUnit.Framework;
using Shouty;

namespace ShoutyTests
{
    [TestFixture]
    public class PersonTest
    {
        [Test]
        public void HasntHeardAnyMessagesAtStart()
        {
           Assert.That(new Person().messagesHeard, Is.Empty);
        }

        [Test]
        public void HeardMessage()
        {
            Person person = new Person();
            person.Hear("Hello");
            Assert.That(person.messagesHeard, Contains.Item("Hello"));
        }

        [Test]
        public void WithinRangeIsTrueIf1000OrLess()
        {
            Person person = new Person();
            Person other = new Person();
            other.location = 1000;
            Assert.True(person.withinRangeOf(other));
        }

        [Test]
        public void OutsideRangeIfGreaterThan1000()
        {
            Person person = new Person();
            Person other = new Person();
            other.location = 1001;
            Assert.False(person.withinRangeOf(other));
        }
    }
}
