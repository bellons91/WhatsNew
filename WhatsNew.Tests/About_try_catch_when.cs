namespace WhatsNew.Tests
{
    public class About_try_catch_when
    {
        [Test]
        [DotNetCore3]
        public void catch_exception_by_condition()
        {
            string Do(int value)
            {
                try
                {
                    if (value == 0) return "ok";
                    throw new MyException() { ExceptionType = value };
                }
                catch (MyException ex) when (ex.ExceptionType % 2 == 0)
                {
                    return "even";
                }
                catch (MyException ex)
                {
                    return "odd";
                }
                catch (Exception)
                {
                    return "unknown";
                }
            }

            Assert.That(Do(0), Is.EqualTo("ok"));
            Assert.That(Do(5), Is.EqualTo("odd"));
            Assert.That(Do(30), Is.EqualTo("even"));
        }

        [Serializable]
        public class MyException : Exception
        {
            public int ExceptionType { get; set; }

            public MyException()
            { }
        }
    }
}