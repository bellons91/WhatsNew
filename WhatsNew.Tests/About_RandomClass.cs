namespace WhatsNew.Tests
{
	[IncludeRandomSelection("Random class enhancements")]
    public class About_RandomClass
	{
		[Test]
		[DotNet8]
		public void Shuffle()
		{
			var source = Enumerable.Range(0, 10);
			var items = source.ToArray();

			Random.Shared.Shuffle(items); // updates the input collection!

			Console.WriteLine(string.Join('-', items));

			CollectionAssert.AreNotEqual(items, source);
			CollectionAssert.AreEquivalent(items, source);
		}

		[Test]
		[DotNet8]
		public void GetRandomItems()
		{
			var source = Enumerable.Range(0, 10);
			var items = source.ToArray();
			var randomItems = Random.Shared.GetItems(items, 3);

			Console.WriteLine(string.Join('-', randomItems));

			Assert.That(randomItems.Length, Is.EqualTo(3));
			//Note: items can be repeated in the output collection! 

		}
	}
}