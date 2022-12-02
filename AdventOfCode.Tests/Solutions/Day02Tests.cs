using AdventOfCode.Solutions;
using static AdventOfCode.Solutions.Day02;

namespace AdventOfCode.Tests.Solutions
{
    public class Day02Tests
    {
        [Test]
        [TestCase(RockPaperScissors.Rock, GameOutcome.Draw, RockPaperScissors.Rock)]
        [TestCase(RockPaperScissors.Rock, GameOutcome.Won, RockPaperScissors.Paper)]
        [TestCase(RockPaperScissors.Rock, GameOutcome.Lost, RockPaperScissors.Scissors)]
        [TestCase(RockPaperScissors.Paper, GameOutcome.Draw, RockPaperScissors.Paper)]
        [TestCase(RockPaperScissors.Paper, GameOutcome.Won, RockPaperScissors.Scissors)]
        [TestCase(RockPaperScissors.Paper, GameOutcome.Lost, RockPaperScissors.Rock)]
        [TestCase(RockPaperScissors.Scissors, GameOutcome.Draw, RockPaperScissors.Scissors)]
        [TestCase(RockPaperScissors.Scissors, GameOutcome.Won, RockPaperScissors.Rock)]
        [TestCase(RockPaperScissors.Scissors, GameOutcome.Lost, RockPaperScissors.Paper)]
        public void GetExpectedPlayerTurn_ReturnsTheCorrectMoveToPlay(RockPaperScissors opponent, GameOutcome expectedOutcome, RockPaperScissors moveToPlay)
        {
            // Arrange
            var solution = new Day02();

            // Act
            var result = solution.GetExpectedPlayerTurn(opponent, expectedOutcome);

            // Assert
            Assert.That(result, Is.EqualTo(moveToPlay));
        }

        [Test]
        [TestCase(RockPaperScissors.Rock, RockPaperScissors.Rock, GameOutcome.Draw)]
        [TestCase(RockPaperScissors.Rock, RockPaperScissors.Paper, GameOutcome.Won)]
        [TestCase(RockPaperScissors.Rock, RockPaperScissors.Scissors, GameOutcome.Lost)]
        [TestCase(RockPaperScissors.Paper, RockPaperScissors.Paper, GameOutcome.Draw)]
        [TestCase(RockPaperScissors.Paper, RockPaperScissors.Scissors, GameOutcome.Won)]
        [TestCase(RockPaperScissors.Paper, RockPaperScissors.Rock, GameOutcome.Lost)]
        [TestCase(RockPaperScissors.Scissors, RockPaperScissors.Scissors, GameOutcome.Draw)]
        [TestCase(RockPaperScissors.Scissors, RockPaperScissors.Rock, GameOutcome.Won)]
        [TestCase(RockPaperScissors.Scissors, RockPaperScissors.Paper, GameOutcome.Lost)]

        public void GetPlayersOutcomeForTurn_ReturnsTheCorrectGameOutcomeForThePlayer(RockPaperScissors opponent, RockPaperScissors player, GameOutcome expectedOutcome)
        {
            // Arrange
            var solution = new Day02();

            // Act
            var result = solution.GetPlayersOutcomeForTurn(opponent, player);

            // Assert
            Assert.That(result, Is.EqualTo(expectedOutcome));
        }

        [Test]
        [TestCase("A", RockPaperScissors.Rock)]
        [TestCase("B", RockPaperScissors.Paper)]
        [TestCase("C", RockPaperScissors.Scissors)]
        [TestCase("X", RockPaperScissors.Rock)]
        [TestCase("Y", RockPaperScissors.Paper)]
        [TestCase("Z", RockPaperScissors.Scissors)]
        public void ConvertValueToRockPaperScissors_ReturnsTheCorrectRockPaperScissorsValue(string value, RockPaperScissors expectedValue)
        {
            // Arrange
            var solution = new Day02();

            // Act
            var result = solution.ConvertValueToRockPaperScissors(value);

            // Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase("X", GameOutcome.Lost)]
        [TestCase("Y", GameOutcome.Draw)]
        [TestCase("Z", GameOutcome.Won)]
        public void GetExpectedOutcome_ReturnsTheCorrectExpectedGameOutcome(string value, GameOutcome expectedOutcome)
        {
            // Arrange
            var solution = new Day02();

            // Act
            var result = solution.GetExpectedOutcome(value);

            // Assert
            Assert.That(result, Is.EqualTo(expectedOutcome));
        }


        [Test]
        [TestCase(GameOutcome.Lost, 0)]
        [TestCase(GameOutcome.Draw, 3)]
        [TestCase(GameOutcome.Won, 6)]
        public void GetScoreForOutcome_ReturnsTheCorrectScoreForTheGameOutcome(GameOutcome gameOutcome, int expectedScore)
        {
            // Arrange
            var solution = new Day02();

            // Act
            var result = solution.GetScoreForOutcome(gameOutcome);

            // Assert
            Assert.That(result, Is.EqualTo(expectedScore));
        }

        [Test]
        [TestCase(RockPaperScissors.Rock, 1)]
        [TestCase(RockPaperScissors.Paper, 2)]
        [TestCase(RockPaperScissors.Scissors, 3)]
        public void GetRockPaperScissorsValue_ReturnsTheCorrectRockPaperScissorsValue(RockPaperScissors rockPaperScissors, int expectedValue)
        {
            // Arrange
            var solution = new Day02();

            // Act
            var result = solution.GetRockPaperScissorsValue(rockPaperScissors);

            // Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [Test]
        public void PartOne_ReturnsCorrectAnswer()
        {
            // Arrange
            var solution = new Day02();

            // Act
            var result = solution.PartOne();

            // Assert
            Assert.That(result, Is.EqualTo(9_241));
        }

        [Test]
        public void PartTwo_ReturnsCorrectAnswer()
        {
            // Arrange
            var solution = new Day02();

            // Act
            var result = solution.PartTwo();

            // Assert
            Assert.That(result, Is.EqualTo(14_610));
        }
    }
}
