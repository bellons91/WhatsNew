namespace WhatsNew.Tests
{
	public class About_LambdasWithDefaultValue
	{


		[Test]
		[DotNet8]
		public void Can_use_default_value()
		{
			var IncrementBy = (int source, int increment = 1) => source + increment;

			Assert.That(IncrementBy(3), Is.EqualTo(4));

			Assert.That(IncrementBy(3, 2), Is.EqualTo(5));

		}
	}
}