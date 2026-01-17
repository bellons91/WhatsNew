namespace WhatsNew.Tests
{
	[IncludeRandomSelection("New ArgumentException utility methods")]
    public class About_Argument_Exception
	{
		[Test]
		[DotNet7]
		public void ShouldThrowIfNull_WithNameof()
		{
			try
			{
				var self = ReturnSelf_ThrowIfNull(null);
			}
			catch (ArgumentException ex)
			{
				Assert.That(ex.ParamName, Is.EqualTo("value"));
			}
		}

		[Test]
		[DotNet7]
		public void ShouldThrowIfNull_WithoutNameof()
		{
			try
			{
				var self = ReturnSelf_ThrowIfNullWithoutNameof(null);
			}
			catch (ArgumentException ex)
			{
				Assert.That(ex.ParamName, Is.EqualTo("value"));
			}
		}

		[Test]
		[TestCase("")]
		[TestCase(null)]
		[DotNet7]
		public void ShouldThrowIfNullOrEmpty_WithoutNameof(string invalidValue)
		{
			try
			{
				var self = ReturnSelf_ThrowIfNullOrEmpty(invalidValue);
			}
			catch (ArgumentException ex)
			{
				Assert.That(ex.ParamName, Is.EqualTo("input value"));
			}
		}


		[Test]
		[TestCase("")]
		[TestCase(null)]
		[TestCase("                           ")]
		[DotNet8]
		public void ShouldThrowIfNullOrWhitespace(string invalidValue)
		{
			try
			{
				var self = ReturnSelf_ThrowIfNullOrWhitespace(invalidValue);
			}
			catch (ArgumentException ex)
			{
				Assert.That(ex.ParamName, Is.EqualTo("value"));
			}
		}



		[Test]
		[TestCase(-3)]
		[TestCase(0)]
		[DotNet8]
		public void ShouldThrowIfLessThanZero(int invalidValue)
		{
			try
			{
				var self = ReturnSelf_ThrowIfLessThanZero(invalidValue);
			}
			catch (ArgumentException ex)
			{
				Assert.That(ex.ParamName, Is.EqualTo("value"));
			}
		}

		private static int ReturnSelf_ThrowIfLessThanZero(int value)
		{
			ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);

			return value;
		}

		private static string ReturnSelf_ThrowIfNullOrWhitespace(string value)
		{
			ArgumentException.ThrowIfNullOrWhiteSpace(value);

			return value;
		}


		private static string ReturnSelf_ThrowIfNull(string value)
		{
			ArgumentNullException.ThrowIfNull(value, nameof(value));
			return value;
		}

		private static string ReturnSelf_ThrowIfNullWithoutNameof(string value)
		{
			ArgumentNullException.ThrowIfNull(value);
			return value;
		}

		private static string ReturnSelf_ThrowIfNullOrEmpty(string value)
		{
			ArgumentException.ThrowIfNullOrEmpty(value, "input value");
			return value;
		}
	}
}