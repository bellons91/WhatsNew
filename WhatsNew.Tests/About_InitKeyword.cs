namespace WhatsNew.Tests
{
	[IncludeRandomSelection("Init-only setters")]
    public class About_InitKeyword
	{
		[Test]
		[DotNet5]
		public void Init_keyword_with_compiler_error()
		{
			var p = new Person { Age = 30, FirstName = "Davide", LastName = "Bellone" };

			//p.FirstName = "";
		}

		[Test]
		[DotNet5]
		public void Init_keyword_with_compiler_error_after_constructor()
		{
			var p = new Person { Age = 30, LastName = "Bellone" };

			//p.FirstName = "";
		}

		public class Person
		{
			public string FirstName { get; init; } = string.Empty;

			public string LastName { get; init; } = string.Empty;

			public int? Age { get; set; }
		}
	}
}