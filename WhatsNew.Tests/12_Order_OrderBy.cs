namespace WhatsNew.Tests
{
    public class About_Order_OrderBy
    {
        public static List<User> _users = new List<User> {
            new User(35, "Foo"),
            new User(11, "Bar"),
            new User(64, "Baz"),
            };

        [Test]
        public void order_by_field()
        {
            var sortedUsers = _users.OrderBy(x => x.Id);

            Assert.That(sortedUsers.First().Id, Is.EqualTo(11));
            Assert.That(sortedUsers.Last().Id, Is.EqualTo(64));
        }

        [Test]
        public void order_by_default()
        {
            List<OrderedUser> users = _users.Select(u => new OrderedUser { Id = u.Id, Name = u.Name }).ToList();

            var sortedUsers = users.Order();
            Assert.That(sortedUsers.First().Id, Is.EqualTo(11));
            Assert.That(sortedUsers.Last().Id, Is.EqualTo(64));
        }

        public class OrderedUser : IComparable<OrderedUser>
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public int CompareTo(OrderedUser? other)
            {
                return Id.CompareTo(other.Id);
            }
        }

        public record User(int Id, string Name);
    }
}