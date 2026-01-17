namespace WhatsNew.Tests
{
	[IncludeRandomSelection("LINQ's Chunk method")]
	public class About_Chunk
	{
		[Test]
		[DotNet6]
		public void Chunk_creates_parts()
		{
			var items = Enumerable.Range(0, 6);
			// [0, 1, 2, 3, 4, 5]

			IEnumerable<int[]> chunks = items.Chunk(2);

			Assert.That(chunks.Count, Is.EqualTo(3));
			Assert.That(chunks.ElementAt(0), Is.EquivalentTo(new[] { 0, 1 }));
			Assert.That(chunks.ElementAt(1), Is.EquivalentTo(new[] { 2, 3 }));
			Assert.That(chunks.ElementAt(2), Is.EquivalentTo(new[] { 4, 5 }));
			//[ [0, 1], [2, 3], [4, 5]]
		}

		[Test]
		[DotNet6]
		public void Chunk_creates_parts_odd_length()
		{
			var items = Enumerable.Range(0, 5);
			// [0, 1, 2, 3, 4, 5]

			IEnumerable<int[]> chunks = items.Chunk(2);

			Assert.That(chunks.Count, Is.EqualTo(3));
			Assert.That(chunks.ElementAt(0), Is.EquivalentTo(new[] { 0, 1 }));
			Assert.That(chunks.ElementAt(1), Is.EquivalentTo(new[] { 2, 3 }));
			Assert.That(chunks.ElementAt(2), Is.EquivalentTo(new[] { 4 }));
			//[ [0, 1], [2, 3], [4]]
		}
	}
}