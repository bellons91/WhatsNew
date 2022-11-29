﻿using WhatsNew.Tests.Utils;

namespace WhatsNew.Tests
{
    public class T03_TryGetNonEnumerated
    {
        [Test]
        [DotNet6]
        public void can_enumerate_list()
        {
            var range = Enumerable.Range(0, 200);

            Assert.IsTrue(range.TryGetNonEnumeratedCount(out int length));
            Assert.That(length, Is.EqualTo(200));
        }

        [Test]
        [DotNet6]
        public void cannot_enumerate_yelded_items()
        {
            IEnumerable<int> range = Get(200);

            Assert.IsFalse(range.TryGetNonEnumeratedCount(out int length));
        }

        private IEnumerable<int> Get(int lenght)
        {
            for (int i = 0; i < lenght; i++)
            {
                yield return i;
            }
        }
    }
}