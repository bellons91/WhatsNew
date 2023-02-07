using WhatsNew.Tests.Utils;

namespace WhatsNew.Tests
{
    public class T15_Pattern_Matching
    {
        [Test]
        [DotNet5]
        public void can_use_keywords()
        {
            bool IsLetterOrSeparator(char c) =>
      c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',';

            Assert.IsTrue(IsLetterOrSeparator(c: 'C'));
            Assert.IsTrue(IsLetterOrSeparator('.'));
            Assert.IsFalse(IsLetterOrSeparator('9'));
        }

        [Test]
        [DotNet5]
        public void can_use_isnull()
        {
            string SelfOrMessage(string s)
            {
                if (s is not null) return s;
                return "error!";
            }

            Assert.That(SelfOrMessage("CIAO"), Is.EqualTo("CIAO"));
            Assert.That(SelfOrMessage(null), Is.EqualTo("error!"));
        }

        [Test]
        [DotNet7]
        public void can_use_list_pattern()
        {
            string SelfOrMessage(int[] s)
            {
                if (s is [1, 2, 3]) return "CIAO";
                return "error!";
            }

            Assert.That(SelfOrMessage(new int[] { 1, 2, 3 }), Is.EqualTo("CIAO"));
            Assert.That(SelfOrMessage(new int[] { 1, 2, 3, 4 }), Is.EqualTo("error!"));
        }

        [Test]
        [DotNet7]
        public void can_use_list_patterns_with_underscore()
        {
            string SelfOrMessage(int[] s)
            {
                if (s is [_, 2, _]) return "CIAO";
                return "error!";
            }

            Assert.That(SelfOrMessage(new int[] { 1, 2, 3 }), Is.EqualTo("CIAO"));
            Assert.That(SelfOrMessage(new int[] { 1, 6, 2, 3 }), Is.EqualTo("error!"));
            Assert.That(SelfOrMessage(new int[] { 6, 3, 8, 4 }), Is.EqualTo("error!"));
        }
    }
}