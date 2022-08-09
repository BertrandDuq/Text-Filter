using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TextFilter.Filters;

namespace TextFilter.Tests
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
        public void Should_Filter_Returns_2()
        {
            var wordsLeft = Filter.Filter(SampleWords);

            Assert.That(wordsLeft.Count(), Is.EqualTo(2));
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
