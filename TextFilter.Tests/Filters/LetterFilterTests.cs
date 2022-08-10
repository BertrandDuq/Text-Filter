using System.Linq;
using NUnit.Framework;
using TextFilter.Filters;

namespace TextFilter.Tests.Filters
{
    [TestFixture]
    public class LetterFilterTests : AbstractFilterTests
    {
        private const char LetterFilteredOut = 't';

        [OneTimeSetUp]
        public void Setup()
        {
            Filter = new LetterFilter(LetterFilteredOut);
        }

        [Test]
        public void Should_Filter_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => Filter.Filter(SampleWords));
        }

        [Test]
        public void Should_Filter_Returns_6()
        {
            var wordsLeft = Filter.Filter(SampleWords);

            Assert.That(wordsLeft.Count(), Is.EqualTo(6));
        }

        [Test]
        public void Should_Filter_Does_Not_Contain_Irrelevant_Words()
        {
            var wordsLeft = Filter.Filter(SampleWords);

            foreach (var wordLeft in wordsLeft)
            {
                Assert.That(!wordLeft.Contains(LetterFilteredOut));
            }
        }
    }
}
