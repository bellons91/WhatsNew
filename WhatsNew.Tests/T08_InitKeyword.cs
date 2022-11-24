namespace WhatsNew.Tests
{
    public class T08_InitKeyword
    {
        [Test]
        public void init_keyword_with_compiler_error()
        {
            var p = new Person { Age = 30, FirstName = "Davide", LastName = "Bellone" };

            //p.FirstName = "";
        }

        public class Person
        {
            public string FirstName { get; init; }
            public string LastName { get; init; }

            public int? Age { get; set; }
        }
    }
}