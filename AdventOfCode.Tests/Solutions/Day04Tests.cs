using AdventOfCode.Solutions;

namespace AdventOfCode.Tests.Solutions
{
    public class Day04Tests
    {
        [Test]
        [TestCase("2-4,6-8", 2, 4, 6, 8)]
        [TestCase("2-3,4-5", 2, 3, 4, 5)]
        [TestCase("5-7,7-9", 5, 7, 7, 9)]
        [TestCase("2-8,3-7", 2, 8, 3, 7)]
        [TestCase("6-6,4-6", 6, 6, 4, 6)]
        [TestCase("2-6,4-8", 2, 6, 4, 8)]
        public void ParseLine_ReturnsTwoPairsCorrectly(string line, int firstPairStart, int firstPairEnd,
            int secondPairStart, int secondPairEnd)
        {
            // Arrange
            var solution = new Day04();

            // Act
            var (firstPair, secondPair) = solution.ParseLine(line);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(firstPair.Start, Is.EqualTo(firstPairStart));
                Assert.That(firstPair.End, Is.EqualTo(firstPairEnd));

                Assert.That(secondPair.Start, Is.EqualTo(secondPairStart));
                Assert.That(secondPair.End, Is.EqualTo(secondPairEnd));
            });
        }

        [Test]
        [TestCase("2-4,6-8", false)]
        [TestCase("2-3,4-5", false)]
        [TestCase("5-7,7-9", false)]
        [TestCase("2-8,3-7", true)]
        [TestCase("6-6,4-6", true)]
        [TestCase("2-6,4-8", false)]
        public void PairOverlaps_ReturnsWhetherThePairIsOverlapping(string line, bool expectedOverlapping)
        {
            // Arrange
            var solution = new Day04();
            var (firstPair, secondPair) = solution.ParseLine(line);

            // Act
            var isOverlapping = solution.IsPairOverlapping(firstPair, secondPair);
            
            // Assert
            Assert.That(isOverlapping, Is.EqualTo(expectedOverlapping));
        }
        
        [Test]
        public void PartOne_ReturnsCorrectAnswer()
        {
            // Arrange
            var solution = new Day04();

            // Act
            var result = solution.PartOne();

            // Assert
            Assert.That(result, Is.EqualTo(644));
        }

        [Test]
        public void PartTwo_ReturnsCorrectAnswer()
        {
            // Arrange
            var solution = new Day04();

            // Act
            var result = solution.PartTwo();

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }
    }
}