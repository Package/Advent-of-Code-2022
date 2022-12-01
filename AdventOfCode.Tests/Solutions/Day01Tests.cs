using AdventOfCode.Solutions;

namespace AdventOfCode.Tests.Solutions
{
    public class Day01Tests
    {
        [Test]
        [TestCase(1, 24_000)]
        [TestCase(3, 45_000)]
        public void GetElfCarryingMostCaloriesInFile_ReturnsTheCorrectCalories_ForTheExampleCases(int numElfs, int expectedCalories)
        {
            // Arrange
            var solution = new Day01();

            // Act
            var mostCals = solution.GetElfCarryingMostCaloriesInFile(@"Input/Day01_Example.txt", numElfs);

            // Assert
            Assert.That(mostCals, Is.EqualTo(expectedCalories));
        }

        [Test]
        public void PartOne_ReturnsCorrectAnswer()
        {
            // Arrange
            var solution = new Day01();

            // Act
            var result = solution.PartOne();

            // Assert
            Assert.That(result, Is.EqualTo(67_016));
        }

        [Test]
        public void PartTwo_ReturnsCorrectAnswer()
        {
            // Arrange
            var solution = new Day01();

            // Act
            var result = solution.PartTwo();

            // Assert
            Assert.That(result, Is.EqualTo(200_116));
        }
    }
}
