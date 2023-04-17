namespace WhatsNew.Tests
{
    public class T16_Argument_Exception
    {
        [Test]
        [DotNet7]
        public void ShouldThrowIfNull_WithNameof()
        {
            try
            {
                var self = ReturnSelf_ThrowIfNull(null);
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.ParamName, Is.EqualTo("value"));
            }
        }

        [Test]
        [DotNet7]
        public void ShouldThrowIfNull_WithoutNameof()
        {
            try
            {
                var self = ReturnSelf_ThrowIfNullWithoutNameof(null);
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.ParamName, Is.EqualTo("value"));
            }
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [DotNet7]
        public void ShouldThrowIfNullOrEmpty_WithoutNameof(string invalidValue)
        {
            try
            {
                var self = ReturnSelf_ThrowIfNullOrEmpty(invalidValue);
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.ParamName, Is.EqualTo("value"));
            }
        }

        private static string ReturnSelf_ThrowIfNull(string value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            return value;
        }

        private static string ReturnSelf_ThrowIfNullWithoutNameof(string value)
        {
            ArgumentNullException.ThrowIfNull(value);
            return value;
        }

        private static string ReturnSelf_ThrowIfNullOrEmpty(string value)
        {
            ArgumentException.ThrowIfNullOrEmpty(value, nameof(value));
            return value;
        }
    }
}