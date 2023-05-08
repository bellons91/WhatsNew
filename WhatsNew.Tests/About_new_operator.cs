namespace WhatsNew.Tests
{
    public class About_new_operator
    {
        [Test]
        [DotNet5]
        public void new_operator_creates_empty_instance()
        {
            User user = new();

            Assert.That(user, Is.InstanceOf<User>());
            Assert.That(user, Is.Not.Null);
            Assert.That(user.Id, Is.EqualTo(0));
            Assert.That(user.Name, Is.EqualTo(""));
        }

        [Test]
        [DotNet5]
        public void new_operator_creates_dictionary()
        {
            Dictionary<string, string> dict = new();

            Assert.That(dict, Is.InstanceOf<Dictionary<string, string>>());
            Assert.That(dict, Is.Not.Null);
            Assert.That(dict.Count, Is.EqualTo(0));
        }

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
        }
    }
}