using SawNaw.LinqExtensions.EnumerableSplit.Core;

namespace SawNaw.LinqExtensions.EnumerableSplit.UnitTests
{
    public class EnumerableSplitTests
    {
        [Fact]
        public void Split_WithPredicate_SplitsCorrectly()
        {
            var input = new[] { "pie", "apple", "cake", "mud-pie", "nuts", "plum", "mud-spread", "milk", "butter" };
            var result = input.Split(s => s.StartsWith("mud")).ToList();

            Assert.Equal(3, result.Count);
            Assert.Equal(["pie", "apple", "cake"], result[0]);
            Assert.Equal(["nuts", "plum"], result[1]);
            Assert.Equal(["milk", "butter"], result[2]);
        }

        [Fact]
        public void Split_WithPredicate_EmptySource_ReturnsEmpty()
        {
            var input = Array.Empty<string>();
            var result = input.Split(s => s == "x").ToList();
            Assert.Empty(result);
        }

        [Fact]
        public void Split_WithPredicate_NoSeparators_ReturnsWholeCollection()
        {
            var input = new[] { 1, 2, 3 };
            var result = input.Split(i => false).ToList();
            Assert.Single(result);
            Assert.Equal([1, 2, 3], result[0]);
        }

        [Fact]
        public void Split_WithPredicate_AllSeparators_ReturnsEmpty()
        {
            var input = new[] { 1, 2, 3 };
            var result = input.Split(i => true).ToList();
            Assert.Empty(result);
        }

        [Fact]
        public void Split_WithPredicate_ThrowsOnNullSource()
        {
            IEnumerable<int>? input = null;
            Assert.Throws<ArgumentNullException>(() => input!.Split(i => i == 0).ToList());
        }

        [Fact]
        public void Split_WithSeparators_SplitsCorrectly()
        {
            var input = new[] { 1, 2, 0, 3, 4, 0, 5 };
            var result = input.Split(0).ToList();
            Assert.Equal(3, result.Count);
            Assert.Equal([1, 2], result[0]);
            Assert.Equal([3, 4], result[1]);
            Assert.Equal([5], result[2]);
        }

        [Fact]
        public void Split_WithMultipleSeparators_SplitsCorrectly()
        {
            var input = new[] { 1, 2, 0, 3, 4, 9, 5 };
            var result = input.Split(0, 9).ToList();
            Assert.Equal(3, result.Count);
            Assert.Equal([1, 2], result[0]);
            Assert.Equal([3, 4], result[1]);
            Assert.Equal([5], result[2]);
        }

        [Fact]
        public void Split_WithSeparators_ThrowsOnNullSource()
        {
            IEnumerable<int>? input = null;
            Assert.Throws<ArgumentNullException>(() => input!.Split(0).ToList());
        }
    }
}