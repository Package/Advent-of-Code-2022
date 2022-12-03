using AdventOfCode.Solutions;
using static AdventOfCode.Solutions.Day03;

namespace AdventOfCode.Tests.Solutions
{
    public class Day03Tests
    {
        [Test]
        [TestCase("vJrwpWtwJgWrhcsFMMfFFhFp", "vJrwpWtwJgWr", "hcsFMMfFFhFp")]
        [TestCase("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL")]
        [TestCase("PmmdzqPrVvPwwTWBwg", "PmmdzqPrV", "vPwwTWBwg")]
        public void Rucksack_Parse_CreatesRucksackWithCorrectCompartments(string input, string expectedFirstCompartment, string expectedSecondCompartment)
        {
            // Arrange
            var rucksack = new Rucksack(input);

            // Act
            var firstCompartment = rucksack.FirstCompartment;
            var secondCompartment = rucksack.SecondCompartment;

            // Assert
            Assert.That(firstCompartment, Is.EqualTo(expectedFirstCompartment));
            Assert.That(secondCompartment, Is.EqualTo(expectedSecondCompartment));
        }

        [Test]
        [TestCase("vJrwpWtwJgWrhcsFMMfFFhFp", "p")]
        [TestCase("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "L")]
        [TestCase("PmmdzqPrVvPwwTWBwg", "P")]
        public void Rucksack_GetItemsInAllCompartments_ReturnsTheItemsInAllCompartments(string input, string expectedCharacters)
        {
            // Arrange
            var rucksack = new Rucksack(input);
            var expectedItems = expectedCharacters.ToList();

            // Act
            var itemsInAllCompartments = rucksack.GetItemsInAllCompartments();

            // Assert
            Assert.That(itemsInAllCompartments, Is.EqualTo(expectedItems));
        }

        [Test]
        [TestCase('p', 16)]
        [TestCase('L', 38)]
        [TestCase('P', 42)]
        [TestCase('v', 22)]
        [TestCase('t', 20)]
        [TestCase('s', 19)]
        public void ConvertCharacterToScore_ReturnsTheCorrectScoreForACharacter(char character, int expectedScore)
        {
            // Arrange
            var solution = new Day03();

            // Act
            var characterScore = solution.ConvertCharacterToScore(character);

            // Assert
            Assert.That(characterScore, Is.EqualTo(expectedScore));
        }

        [Test]
        public void SumCharacters_ReturnsTheCorrectCharacterSum()
        {
            // Arrange
            var solution = new Day03();
            var charactersToSum = "pLPvts".ToList();

            // Act
            var characterTotal = solution.SumCharacters(charactersToSum);

            // Assert
            Assert.That(characterTotal, Is.EqualTo(157));
        }

        [Test]
        public void ParseRucksackGroups_ReturnsGroupsWithCorrectNumberOfRucksacks()
        {
            // Arrange
            var solution = new Day03();

            // Act
            var rucksackGroups = solution.ParseRucksackGroups(@"Input/Day03_Example.txt");

            // Assert
            Assert.That(rucksackGroups.Count, Is.EqualTo(2));
            foreach (var group in rucksackGroups)
            {
                Assert.That(group.RucksackCount(), Is.EqualTo(NumRucksacksPerGroup));
            }
        }

        [Test]
        public void RucksackGroup_GetBadge_ReturnsTheCorrectBadgeForTheGroup()
        {
            // Arrange
            var rucksackGroup = new RucksackGroup();
            rucksackGroup.AddRucksack(new Rucksack("vJrwpWtwJgWrhcsFMMfFFhFp"));
            rucksackGroup.AddRucksack(new Rucksack("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"));
            rucksackGroup.AddRucksack(new Rucksack("PmmdzqPrVvPwwTWBwg"));

            // Act
            var badgeCharacter = rucksackGroup.GetBadge();

            // Assert
            Assert.That(badgeCharacter, Is.EqualTo('r'));
        }

        [Test]
        public void PartOne_ReturnsCorrectAnswer()
        {
            // Arrange
            var solution = new Day03();

            // Act
            var result = solution.PartOne();

            // Assert
            Assert.That(result, Is.EqualTo(8_243));
        }

        [Test]
        public void PartTwo_ReturnsCorrectAnswer()
        {
            // Arrange
            var solution = new Day03();

            // Act
            var result = solution.PartTwo();

            // Assert
            Assert.That(result, Is.EqualTo(2_631));
        }
    }
}
