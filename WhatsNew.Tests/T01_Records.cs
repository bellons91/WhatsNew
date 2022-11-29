using WhatsNew.Tests.Utils;

namespace WhatsNew.Tests
{
    //https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records
    public class T01_Records
    {
        public record User(int Id, string Name);

        [Test]
        [DotNet5]
        public void Records_set_autoproperties()
        {
            User me = new User(1, "Davide");

            Assert.That(me.Id, Is.EqualTo(1));
            Assert.That(me.Name, Is.EqualTo("Davide"));
        }

        [Test]
        [DotNet5]
        public void Records_have_auto_equality()
        {
            User me = new User(1, "Davide");
            User alsoMe = new User(1, "Davide");

            Assert.That(me, Is.EqualTo(alsoMe));
        }

        [Test]
        [DotNet5]
        public void Records_auto_tostring()
        {
            User me = new User(1, "Davide");
            string s = me.ToString();

            Assert.That(s, Is.EqualTo("User { Id = 1, Name = Davide }"));
        }

        [Test]
        [DotNet5]
        public void Records_cannot_be_modified()
        {
            User me = new User(1, "Davide");
            //me.Name = "Mr Davide";

            Assert.That(me.Name, Is.Not.EqualTo("Mr Davide"));
        }

        [Test]
        [DotNet5]
        public void Records_can_create_clones_using_with()
        {
            User me = new User(1, "Davide");
            User anotherMe = me with { Name = "Mr Davide" };

            Assert.That(anotherMe.Name, Is.EqualTo("Mr Davide"));
            Assert.That(anotherMe.Id, Is.EqualTo(1));
        }

        public record Developer(int Id, string Name, List<string> Skills) : User(Id, Name);

        [Test]
        [DotNet5]
        public void Records_can_have_hierarchy()
        {
            Developer me = new Developer(1, "Davide", new List<string> { "C#", ".NET" });

            Assert.That(me, Is.InstanceOf<Developer>());
            Assert.That(me, Is.InstanceOf<User>());
        }

        [Test]
        [DotNet5]
        public void Records_are_not_really_immutable()
        {
            Developer me = new Developer(1, "Davide", new List<string> { "C#", ".NET" });

            me.Skills.Add("Blogging");

            Assert.That(me.Skills.Count, Is.EqualTo(3));
        }

        public record CsharpDeveloper(int Id, string Name, List<string> Skills) : Developer(Id, Name, Skills)
        {
            public string[] KnownCsharpVersions { get; set; }
        }

        [Test]
        [DotNet5]
        public void Records_can_have_explicit_properties()
        {
            CsharpDeveloper me = new CsharpDeveloper(1, "Davide", new List<string> { "Blogging" })
            {
                KnownCsharpVersions = new string[] { "C#8", "C#11" }
            };

            Assert.That(me.KnownCsharpVersions.Count, Is.EqualTo(2));
        }

        [Test]
        [DotNet5]
        public void Records_can_be_abstract()
        {
            var student = new Student("Davide", "Bellone", 28);
            var teacher = new Teacher("Mr Davide", "Bellone");
            //var person = new Person("Davide", "Bellone"); // abstract!

            Assert.That(student, Is.AssignableTo<Person>());
            Assert.That(teacher, Is.AssignableTo<Person>());
        }

        public abstract record Person(string FirstName, string LastName);
        public record Teacher(string FirstName, string LastName)
            : Person(FirstName, LastName);
        public record Student(string FirstName, string LastName, int Grade)
            : Person(FirstName, LastName);

        [Test]
        [DotNet6]
        public void Records_can_be_struct()
        {
            var smartphone = new Smartphone("IPhone");
            Assert.That(smartphone.Model, Is.Not.Null);
        }

        public record struct Smartphone(string Model);
    }
}