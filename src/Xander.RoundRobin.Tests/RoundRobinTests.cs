using NUnit.Framework;
using Shouldly;

namespace Xander.RoundRobin.Tests
{
    [TestFixture]
    public class RoundRobinTests
    {
        [Test]
        public void Returns_Null_When_There_Are_No_Items()
        {
            var cut = new RoundRobin<int>(new int[0]);
            cut.GetNextItem().ShouldBe(default(int));
        }

        [Test]
        public void Returns_Repeating_Sequence_When_Called_Repeatedly()
        {
            var sequence = new[] { 10, 20, 30 };
            var cut = new RoundRobin<int>(sequence);

            cut.GetNextItem().ShouldBe(10);
            cut.GetNextItem().ShouldBe(20);
            cut.GetNextItem().ShouldBe(30);
            cut.GetNextItem().ShouldBe(10);
            cut.GetNextItem().ShouldBe(20);
            cut.GetNextItem().ShouldBe(30);
        }
    }
}
