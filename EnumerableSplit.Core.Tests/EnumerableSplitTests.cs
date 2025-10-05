using System;
using System.Collections.Generic;
using System.Linq;
using SawNaw.LinqExtensions.EnumerableSplit;
using Xunit;

namespace SawNaw.LinqExtensions.EnumerableSplit.Tests
{
    public class EnumerableSplitTests
    {
        [Fact]
        public void Split_WithSeparatorPredicate_SplitsCorrectly()
        {
            // Arrange
            var input = new[] { "pie", "apple", "cake", "mud-pie", "nuts", "plum", "mud-spread", "milk", "butter" };
            // Act
            var result = input.Split(s => s.StartsWith("mud")).ToList();

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(new[] { "pie", "apple", "cake" }, result[0]);
            Assert.Equal(new[] { "nuts", "plum" }, result[1]);
            Assert.Equal(new[] { "milk", "butter" }, result[2]);
        }

        [Fact]
        public void Split_WithSeparatorPredicate_EmptySource_ReturnsEmpty()
        {
            // Arrange
            var input = Array.Empty<string>();

            // Act
            var result = input.Split(s => s == "x").ToList();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Split_WithSeparatorPredicate_NoSeparators_ReturnsWholeCollection()
        {
            // Arrange
            var input = new[] { 1, 2, 3 };

            // Act
            var result = input.Split(i => false).ToList();

            // Assert
            Assert.Single(result);
            Assert.Equal(new[] { 1, 2, 3 }, result[0]);
        }

        [Fact]
        public void Split_WithSeparatorPredicate_AllSeparators_ReturnsEmpty()
        {
            // Arrange
            var input = new[] { 1, 2, 3 };

            // Act
            var result = input.Split(i => true).ToList();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Split_WithSeparatorPredicate_ThrowsOnNullSource()
        {
            // Arrange
            IEnumerable<int> input = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => input.Split(i => i == 0).ToList());
        }

        [Fact]
        public void Split_WithSeparatorPredicate_ThrowsOnNullPredicate()
        {
            // Arrange
            var input = new[] { 1, 2, 3 };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => input.Split(null).ToList());
        }

        [Fact]
        public void Split_WithSeparatorElements_SplitsCorrectly()
        {
            // Arrange
            var input = new[] { 1, 2, 0, 3, 4, 0, 5 };
            // Act
            var result = input.Split(0).ToList();

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(new[] { 1, 2 }, result[0]);
            Assert.Equal(new[] { 3, 4 }, result[1]);
            Assert.Equal(new[] { 5 }, result[2]);
        }

        [Fact]
        public void Split_WithSeparatorElements_MultipleSeparators()
        {
            // Arrange
            var input = new[] { 1, 2, 0, 3, 4, 9, 5 };
            // Act
            var result = input.Split(0, 9).ToList();

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(new[] { 1, 2 }, result[0]);
            Assert.Equal(new[] { 3, 4 }, result[1]);
            Assert.Equal(new[] { 5 }, result[2]);
        }

        [Fact]
        public void Split_WithSeparatorElements_ThrowsOnNullSource()
        {
            // Arrange
            IEnumerable<int> input = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => input.Split(0).ToList());
        }

        [Fact]
        public void Split_WithSeparatorElements_ThrowsOnNullSeparators()
        {
            // Arrange
            var input = new[] { 1, 2, 3 };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => input.Split(null).ToList());
        }
    }
}