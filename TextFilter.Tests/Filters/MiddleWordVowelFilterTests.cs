using System.Linq;
using NUnit.Framework;
using TextFilter.Filters;

namespace TextFilter.Tests.Filters
{
    [TestFixture]
    public class MiddleWordVowelFilterTests : AbstractFilterTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Filter = new MiddleWordVowelFilter();
        }

        [Test]
        public void Should_Filter_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => Filter.Filter(SampleWords));
        }

        [Test]
        public void Should_Filter_Returns_3()
        {
            var wordsLeft = Filter.Filter(SampleWords);

            Assert.That(wordsLeft.Count(), Is.EqualTo(3));
        }

        [Test]
        public void Should_Filter_Does_Not_Contain_Irrelevant_Words()
        {
            var wordsLeft = Filter.Filter(SampleWords).ToList();

            //we're already checking that size = 3, so for the purpose of this exercise, the below should be fine
            Assert.That(wordsLeft.Contains("are"));
            Assert.That(wordsLeft.Contains("Only"));
            Assert.That(wordsLeft.Contains("rather"));
        }
    }
}
