using AdventOfCode.Solutions;
using static AdventOfCode.Solutions.Day06;

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
        public void GetStartMarker_ReturnsTheCorrectStartOfPacketIndex(string packetString, int expectedStartOfPacket)
        {
            // Arrange
            var solution = new Day06();

            // Act
            var startOfPacket = solution.GetStartMarker(packetString, StartOfPacketMarkerSize);

            // Assert
            Assert.That(startOfPacket, Is.EqualTo(expectedStartOfPacket));
        }
        
        [Test]
        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void GetStartMarker_ReturnsTheCorrectStartOfMessageIndex(string packetString, int expectedStartOfMessage)
        {
            // Arrange
            var solution = new Day06();

            // Act
            var startOfPacket = solution.GetStartMarker(packetString, StartOfMessageMarkerSize);

            // Assert
            Assert.That(startOfPacket, Is.EqualTo(expectedStartOfMessage));
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
            Assert.That(result, Is.EqualTo(2_773));
        }
    }
}