using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WhatsNew.Tests
{
	public class About_TimeAbstraction
	{


		[Test]
		[DotNet8]
		public void CanUseSystemInjectedTime()
		{

			var builder = WebApplication.CreateBuilder();

			builder.Services.AddSingleton(TimeProvider.System); // THIS!
			builder.Services.AddSingleton<TodayCalendar>();


			var app = builder.Build();
			var calendar = app.Services.GetService<TodayCalendar>();

			Assert.That(calendar.DayName(), Is.EqualTo("Monday"));
		}


		[Test]
		[DotNet8]
		public void CanUseMockedTime()
		{
			var mockTimeProvider = new Moq.Mock<TimeProvider>();

			var datetimeoffset = new DateTimeOffset(2023, 9, 27, 1, 15, 20, TimeSpan.Zero);
			mockTimeProvider.Setup(m => m.GetUtcNow()).Returns(datetimeoffset);

			var calendar = new TodayCalendar(mockTimeProvider.Object);

			Assert.That(calendar.DayName(), Is.EqualTo("Wednesday"));
		}



		public class TodayCalendar
		{
			private readonly TimeProvider _timeProvider;

			public TodayCalendar(TimeProvider timeProvider)
			{
				this._timeProvider = timeProvider;
			}

			public string DayName()
			{

				return _timeProvider.GetUtcNow().DayOfWeek.ToString();
			}
		}
	}
}