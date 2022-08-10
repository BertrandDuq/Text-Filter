using System.Linq;
using NUnit.Framework;
using TextFilter.Filters;

namespace TextFilter.Tests.Filters
{
    [TestFixture]
    public class WordLengthFilterTests : AbstractFilterTests
    {
        private const int MinLengthToKeep = 3;

        [OneTimeSetUp]
        public void Setup()
        {
            Filter = new WordLengthFilter(MinLengthToKeep);
        }

        [Test]
        public void Should_Filter_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => Filter.Filter(SampleWords));
        }

        [Test]
        public void Should_Filter_Returns_7()
        {
            var wordsLeft = Filter.Filter(SampleWords);
            
            Assert.That(wordsLeft.Count(), Is.EqualTo(7));
        }

        [Test]
        public void Should_Filter_Does_Not_Contain_Irrelevant_Words()
        {
            var wordsLeft = Filter.Filter(SampleWords);

            foreach (var wordLeft in wordsLeft)
            {
                Assert.That(wordLeft.Length >= 3);
            }
        }
    }
}
