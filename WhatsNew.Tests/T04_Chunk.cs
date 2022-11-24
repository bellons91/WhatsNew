namespace WhatsNew.Tests
{
    public class T04_Chunk
    {
        [Test]
        public void chunk_creates_parts()
        {
            var items = Enumerable.Range(0, 20);

            IEnumerable<int[]> chunks = items.Chunk(2);

            Assert.That(chunks.Count, Is.EqualTo(10));
            Assert.That(chunks.First(), Is.EquivalentTo(new[] { 0, 1 }));
        }

        [Test]
        public void chunk_creates_parts_odd_length()
        {
            var items = Enumerable.Range(0, 5);

            IEnumerable<int[]> chunks = items.Chunk(2);

            Assert.That(chunks.Count, Is.EqualTo(3));
            Assert.That(chunks.Last(), Is.EquivalentTo(new[] { 4 }));
        }
    }
}