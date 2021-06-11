using NUnit.Framework;
using BerylCalendar.Controllers;
using System;
using BerylCalendar.Utilities;

namespace BerylCalendar.Tests.Tests
{
    class TestDayInView
    {
        [SetUp]
        public void SetUp() 
        { 
        }

        [Test]
        public void TestDayInView_IsSetDayCorrect()
        {
            int y = 2021;
            int m = 6;
            int d = 11;

            DateTime day = DateTimeUtilities.GetDayByDate(y, m, d);

            Assert.That(day, Is.EqualTo(DateTime.Parse("06/11/2021 00:00:00")));
        }
    }
}
