using AdventOfCode.Solutions;

namespace AdventOfCode.Tests.Solutions
{
    public class Day06Tests
    {
        [Test]
        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void GetStartOfPacket_ReturnsTheCorrectStartOfPacketIndex(string packetString, int expectedStartOfPacket)
        {
            // Arrange
            var solution = new Day06();

            // Act
            var startOfPacket = solution.GetStartOfPacket(packetString);

            // Assert
            Assert.That(startOfPacket, Is.EqualTo(expectedStartOfPacket));
        }
        
        [Test]
        public void PartOne_ReturnsCorrectAnswer()
        {
            // Arrange
            var solution = new Day06();

            // Act
            var result = solution.PartOne();

            // Assert
            Assert.That(result, Is.EqualTo(1_965));
        }

        [Test]
        public void PartTwo_ReturnsCorrectAnswer()
        {
            // Arrange
            var solution = new Day06();

            // Act
            var result = solution.PartTwo();

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }
    }
}