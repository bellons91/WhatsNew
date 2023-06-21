namespace WhatsNew.Tests
{
    public class About_DistinctyBy
    {
        public record User(int Id, string Name);

        public static List<User> users = new List<User> {
                new User(35, "Foo"),
                new User(11, "Bar"),
                new User(64, "Baz"),
                new User(103, "Quo"),
                new User(64, "Don"),
                new User(19, "Fel"),
                new User(103, "Rax"),
            };

        [Test]
        [DotNet6]
        public void DistinctBy_filter_by_id()
        {
            var distinctUsers = users.DistinctBy(x => x.Id);
            Assert.That(distinctUsers.Count(), Is.EqualTo(5));
        }

        [Test]
        [DotNet6]
        public void DistinctBy_takes_first_occurrence()
        {
            var distinctUsers = users.DistinctBy(x => x.Id);
            var userWithId64 = distinctUsers.First(_ => _.Id == 64);

            Assert.That(userWithId64.Name, Is.EqualTo("Baz"));
        }
    }
}