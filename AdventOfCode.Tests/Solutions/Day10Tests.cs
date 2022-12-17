using AdventOfCode.Solutions;

namespace AdventOfCode.Tests.Solutions
{
    public class Day10Tests
    {
        [Test]
        public void PartOne_ReturnsCorrectAnswer()
        {
            // Arrange
            var solution = new Day10();

            // Act
            var result = solution.PartOne();

            // Assert
            Assert.That(result, Is.EqualTo(14_240));
        }

        [Test]
        public void PartTwo_ReturnsCorrectAnswer()
        {
            // Arrange
            var solution = new Day10();

            // Act
            var result = solution.PartTwo();

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }
    }
}