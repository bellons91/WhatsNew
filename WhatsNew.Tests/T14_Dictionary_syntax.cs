namespace WhatsNew.Tests
{
    public class T14_Dictionary_syntax
    {
        [Test]
        public void old_syntax()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "uno");
            dict.Add(2, "due");
            dict.Add(3, "tre");

            Assert.That(dict.Count, Is.EqualTo(3));
        }

        [Test]
        public void old_syntax_with_brackets()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict[1] = "uno";
            dict[2] = "due";
            dict[3] = "tre";

            Assert.That(dict.Count, Is.EqualTo(3));
        }

        [Test]
        public void new_syntax()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>()
            {
                [1] = "uno",
                [2] = "due",
                [3] = "tre"
            };

            Assert.That(dict.Count, Is.EqualTo(3));
        }
    }
}