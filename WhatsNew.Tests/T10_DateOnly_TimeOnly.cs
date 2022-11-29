using WhatsNew.Tests.Utils;

namespace WhatsNew.Tests
{
    public class T10_DateOnly_TimeOnly
    {
        [Test]
        [DotNet6]
        public void DateOnly_works()
        {
            DateOnly date = new DateOnly(2022, 5, 9);

            Assert.That(date.Year, Is.EqualTo(2022));
            Assert.That(date.Month, Is.EqualTo(5));
            Assert.That(date.Day, Is.EqualTo(9));
            Assert.That(date.DayOfWeek, Is.EqualTo(DayOfWeek.Monday));
        }

        [Test]
        [DotNet6]
        public void TimeOnly_works()
        {
            TimeOnly time = new TimeOnly(9, 15, 45);

            Assert.That(time.Hour, Is.EqualTo(9));
            Assert.That(time.Minute, Is.EqualTo(15));
            Assert.That(time.Second, Is.EqualTo(45));
        }
    }
}