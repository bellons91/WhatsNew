namespace WhatsNew.Tests
{
	[IncludeRandomSelection("LINQ's MinBy and MaxBy methods")]
    public class About_MinBy_MaxBy
	{
		public record User(int Id, string Name);

		public static List<User> users = new List<User> {
			new User(35, "Sandro"),
			new User(11, "Gianni"),
			new User(64, "Carola"),
			};

		[Test]
		[DotNet6]
		public void MaxBy_filter_by_id()
		{
			var maxUser = users.MaxBy(x => x.Id);
			Assert.That(maxUser.Id, Is.EqualTo(64));
		}

		[Test]
		[DotNet6]
		public void MinBy_filter_by_id()
		{
			var maxUser = users.MinBy(x => x.Id);
			Assert.That(maxUser.Id, Is.EqualTo(11));
		}
	}
}