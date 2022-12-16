using AdventOfCode.Solutions;

namespace AdventOfCode.Tests.Solutions
{
    public class Day08Tests
    {
        [Test]
        public void ParseCells_ReturnsA2DArrayOfCells()
        {
            // Arrange
            var solution = new Day08();

            // Act
            var map = solution.ParseCells(@"Input/Day08_Example.txt");

            // Assert
            Assert.IsNotNull(map);
            Assert.That(map.Width, Is.EqualTo(5));
            Assert.That(map.Height, Is.EqualTo(5));
        }
        
        [Test]
        public void PartOne_ReturnsCorrectAnswer()
        {
            // Arrange
            var solution = new Day08();

            // Act
            var result = solution.PartOne();

            // Assert
            Assert.That(result, Is.EqualTo(1_829));
        }

        [Test]
        public void PartTwo_ReturnsCorrectAnswer()
        {
            // Arrange
            var solution = new Day08();

            // Act
            var result = solution.PartTwo();

            // Assert
            Assert.That(result, Is.EqualTo(291_840));
        }
    }
}