using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Project.Utilities.Tests
{
    public class EnumerableExtensionsTest
    {
        [Fact]
        public void RepeatSequence_WhenEmpty_ReturnEmpty()
        {
            var sequence = new List<int>();

            var repeated = sequence.RepeatSequence(4);

            Assert.Empty(repeated);
        }

        [Fact]
        public void RepeatSequence_WhenSequenceExists_ReturnsRepeatedSequence() {
            var sequence = Enumerable.Range(1, 3);

            var repeated = sequence.RepeatSequence(2);

            Assert.Equal(new List<int> { 1, 2, 3, 1, 2, 3 }, repeated);
        }

        [Fact]
        public void RepeatTerms_WhenEmpty_ReturnEmpty()
        {
            var sequence = new List<int>();

            var repeated = sequence.RepeatTerms(5);

            Assert.Empty(repeated);
        }

        [Fact]
        public void RepeatTerms_WhenSequenceExists_ReturnsRepeatedTerms() {
            var sequence = Enumerable.Range(1, 3);

            var repeated = sequence.RepeatTerms(3);

            Assert.Equal(new List<int> { 1, 1, 1, 2, 2, 2, 3, 3, 3 }, repeated);
        }

        [Fact]
        public void DeepClone_WhenEmpty_ReturnEmpty() {
            var items = new List<int>();

            var repeated = items.DeepClone();

            Assert.Empty(repeated);
        }

        [Fact]
        public void DeepClone_WhenEmpty_ReturnClonedItems()
        {
            var items = new List<string> {
                "first",
                "second"
            };

            var cloned = items.DeepClone();

            Assert.Equal(items, cloned);
        }
    }
}
