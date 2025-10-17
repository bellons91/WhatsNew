namespace WhatsNew.Tests
{
	public class About_SpreadOperatorOnCollections
	{
		[Test]
		[DotNet8]
		public void Can_UseSpreadOperator_ToJoinCollections()
		{
			int[] first = new int[] { 1, 2, 3 };
			List<int> second = new List<int> { 4, 5, 6 };

			int[] third = [.. first, .. second];

			Assert.That(third.Length, Is.EqualTo(6));

			Assert.That(first, Is.SubsetOf(third));
			Assert.That(second, Is.SubsetOf(third));

		}
	}
}