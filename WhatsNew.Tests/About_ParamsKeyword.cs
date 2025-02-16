namespace WhatsNew.Tests
{
    public class About_ParamsKeyword
	{

        [Test]
        [DotNetCore3]
        public void Params_WorksWithArray()
        {
			int SumAll(params int[] nums) => nums.Sum();

            Assert.That(SumAll(1,2,3), Is.EqualTo(6));
        }

        [Test]
        [DotNet9]
        public void Params_WorksWithIEnumerable()
        {
			int SumAll(params IEnumerable<int> nums) => nums.Sum();

            Assert.That(SumAll(1, 2, 3), Is.EqualTo(6));
        }

        [Test]
        [DotNet9]
        public void Params_WorksWithHashSet()
        {
            int SumAll(params HashSet<int> nums) => nums.Sum();

            Assert.That(SumAll(1, 2, 3), Is.EqualTo(6));
        }

        [Test]
        [DotNet9]
        public void Params_WorksWithList()
        {
            int SumAll(params List<int> nums) => nums.Sum();

            Assert.That(SumAll(1, 2, 3), Is.EqualTo(6));
        }

    }
}