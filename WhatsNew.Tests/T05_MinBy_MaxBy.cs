namespace WhatsNew.Tests
{
    public class T05_MinBy_MaxBy
    {
        public record User(int Id, string Name);

        public static List<User> users = new List<User> {
            new User(35, "Foo"),
            new User(11, "Bar"),
            new User(64, "Baz"),
            };

        [Test]
        public void maxBy_filter_by_id()
        {
            var maxUser = users.MaxBy(x => x.Id);
            Assert.That(maxUser.Id, Is.EqualTo(64));
        }

        [Test]
        public void minBy_filter_by_id()
        {
            var maxUser = users.MinBy(x => x.Id);
            Assert.That(maxUser.Id, Is.EqualTo(11));
        }
    }
}