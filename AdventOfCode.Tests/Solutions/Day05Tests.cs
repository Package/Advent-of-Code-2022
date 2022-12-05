using AdventOfCode.Solutions;

namespace AdventOfCode.Tests.Solutions
{
    public class Day05Tests
    {
        [Test]
        public void ParseInstructions_ReturnsTheListOfCrateInstructions()
        {
            // Arrange
            var solution = new Day05();

            // Act
            var instructions = solution.ParseInstructions(@"Input/Day05_Example.txt");

            // Assert
            Assert.That(instructions.Count, Is.EqualTo(4));
            Assert.Multiple(() =>
            {
                Assert.That(instructions[0].FromCrate, Is.EqualTo(2));
                Assert.That(instructions[0].ToCreate, Is.EqualTo(1));
                Assert.That(instructions[0].AmountToMove, Is.EqualTo(1));
                
                Assert.That(instructions[1].FromCrate, Is.EqualTo(1));
                Assert.That(instructions[1].ToCreate, Is.EqualTo(3));
                Assert.That(instructions[1].AmountToMove, Is.EqualTo(3));
                
                Assert.That(instructions[2].FromCrate, Is.EqualTo(2));
                Assert.That(instructions[2].ToCreate, Is.EqualTo(1));
                Assert.That(instructions[2].AmountToMove, Is.EqualTo(2));
                
                Assert.That(instructions[3].FromCrate, Is.EqualTo(1));
                Assert.That(instructions[3].ToCreate, Is.EqualTo(2));
                Assert.That(instructions[3].AmountToMove, Is.EqualTo(1));                
            });
        }
        
        [Test]
        public void ParseInitialCrates_ReturnsTheQueueOfInitialStates()
        {
            // Arrange
            var solution = new Day05();

            // Act
            var cratesMap = solution.ParseInitialCrates(@"Input/Day05_Example.txt");

            // Assert
            Assert.That(cratesMap.Keys.Count, Is.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.True(cratesMap[1].Contains("N"));
                Assert.True(cratesMap[1].Contains("Z"));
                
                Assert.True(cratesMap[2].Contains("D"));
                Assert.True(cratesMap[2].Contains("C"));
                Assert.True(cratesMap[2].Contains("M"));
                
                Assert.True(cratesMap[3].Contains("P"));
            });
        }

        [Test]
        public void GetFirstItemInEveryCrate_ReturnsStringWithFirstItemInEveryCrate()
        {
            // Arrange
            var solution = new Day05();
            var crateMap = solution.ParseInitialCrates(@"Input/Day05_Example.txt");

            // Act
            var result = solution.GetFirstItemInEveryCrate(crateMap);

            // Assert
            Assert.That(result, Is.EqualTo("NDP"));
        }
        
        [Test]
        public void PartOne_ReturnsCorrectAnswer()
        {
            // Arrange
            var solution = new Day05();

            // Act
            var result = solution.PartOne();

            // Assert
            Assert.That(result, Is.EqualTo("ZSQVCCJLL"));
        }

        [Test]
        public void PartTwo_ReturnsCorrectAnswer()
        {
            // Arrange
            var solution = new Day05();

            // Act
            var result = solution.PartTwo();

            // Assert
            Assert.That(result, Is.EqualTo("QZFJRWHGS"));
        }
    }
}