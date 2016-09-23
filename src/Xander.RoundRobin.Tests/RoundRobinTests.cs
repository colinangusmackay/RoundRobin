using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace Xander.RoundRobin.Tests
{
    [TestFixture]
    public class RoundRobinTests
    {
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

        [Test]
        public void Returns_Equal_Numbers_Of_Each_Item_When_Called_From_Multiple_Threads()
        {
            var sequence = new[] {10, 20, 30};
            const int rounds = 5000;
            var cut = new RoundRobin<int>(sequence);

            ConcurrentBag<int> items = new ConcurrentBag<int>();

            Parallel.For(
                0, 
                sequence.Length*rounds,
                (item) => { items.Add(cut.GetNextItem()); });

            items.Count(i => i == 10).ShouldBe(rounds);
            items.Count(i => i == 20).ShouldBe(rounds);
            items.Count(i => i == 30).ShouldBe(rounds);
        }

        [Test]
        public void Round_Robin_Must_Not_Be_Given_An_Empty_Sequence()
        {
            Should.Throw<ArgumentException>( () => new RoundRobin<int>(new int[0]))
                .Message.ShouldBe($"Sequence contains no elements.{Environment.NewLine}Parameter name: sequence");
        }
    }
}
