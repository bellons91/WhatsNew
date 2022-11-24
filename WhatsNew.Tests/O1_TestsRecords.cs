namespace WhatsNew
{
    public class O1_TestsRecords
    {
        public record User(int Id, string Name);

        public record Developer(int Id, string Name, List<string> Skills) : User(Id, Name);

        [Test]
        public void Records_set_autoproperties()
        {
            User me = new User(1, "Davide");

            Assert.That(me.Id, Is.EqualTo(1));
            Assert.That(me.Name, Is.EqualTo("Davide"));
        }

        [Test]
        public void Records_have_auto_equality()
        {
            User me = new User(1, "Davide");
            User alsoMe = new User(1, "Davide");

            Assert.That(me, Is.EqualTo(alsoMe));
        }

        [Test]
        public void Records_cannot_be_modified()
        {
            User me = new User(1, "Davide");
            //me.Name = "Mr Davide";

            Assert.That(me.Name, Is.Not.EqualTo("Mr Davide"));
        }

        [Test]
        public void Records_can_create_clones_using_with()
        {
            User me = new User(1, "Davide");
            User anotherMe = me with { Name = "Mr Davide" };

            Assert.That(anotherMe.Name, Is.EqualTo("Mr Davide"));
            Assert.That(anotherMe.Id, Is.EqualTo(1));
        }

        [Test]
        public void Records_can_have_hierarchy()
        {
            Developer me = new Developer(1, "Davide", new List<string> { "C#", ".NET" });

            Assert.That(me, Is.InstanceOf<Developer>());
            Assert.That(me, Is.InstanceOf<User>());
        }

        [Test]
        public void Records_are_not_really_immutable()
        {
            Developer me = new Developer(1, "Davide", new List<string> { "C#", ".NET" });

            me.Skills.Add("Blogging");

            Assert.That(me.Skills.Count, Is.EqualTo(3));
        }
    }
}