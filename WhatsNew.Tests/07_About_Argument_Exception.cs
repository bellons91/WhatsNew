namespace WhatsNew.Tests
{
    public class About_Argument_Exception
    {

        [Test]
        [DotNet7]
        public void ShouldThrowIfNull_WithNameof()
        {
            string ReturnSelf_ThrowIfNull(string value)
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                return value;
            }

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

            string ReturnSelf_ThrowIfNullWithoutNameof(string value)
            {
                ArgumentNullException.ThrowIfNull(value);
                return value;
            }
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
            string ReturnSelf_ThrowIfNullOrEmpty(string value)
            {
                ArgumentException.ThrowIfNullOrEmpty(value, "input value");
                return value;
            }

            try
            {
                var self = ReturnSelf_ThrowIfNullOrEmpty(invalidValue);
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.ParamName, Is.EqualTo("input value"));
            }
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("                           ")]
        [DotNet8]
        public void ShouldThrowIfNullOrWhitespace(string invalidValue)
        {
            string ReturnSelf_ThrowIfNullOrWhitespace(string value)
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
                return value;
            }

            try
            {
                var self = ReturnSelf_ThrowIfNullOrWhitespace(invalidValue);
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.ParamName, Is.EqualTo("value"));
            }
        }


        [Test]
        [TestCase(-3)]
        [TestCase(0)]
        [DotNet8]
        public void ShouldThrowIfLessThanZero(int invalidValue)
        {
            int ReturnSelf_ThrowIfLessThanZero(int value)
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);
                return value;
            }
            try
            {
                var self = ReturnSelf_ThrowIfLessThanZero(invalidValue);
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.ParamName, Is.EqualTo("value"));
            }
        }

    }
}