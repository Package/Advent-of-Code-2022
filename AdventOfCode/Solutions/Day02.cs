namespace AdventOfCode.Solutions
{
    public class Day02 : ISolution<int>
    {
        public int PartOne()
        {
            var input = File.ReadAllLines(@"Input/Day02_Real.txt");

            var playerTotalScore = 0;

            foreach (var line in input)
            {
                var gameLine = line.Split(' ');
                var opponentTurn = ConvertValueToRockPaperScissors(gameLine[0]);
                var playerTurn = ConvertValueToRockPaperScissors(gameLine[1]);

                var outcome = GetPlayersOutcomeForTurn(opponentTurn, playerTurn);
                var outcomeScore = GetScoreForOutcome(outcome);
                var rockPaperScissorsValue = GetRockPaperScissorsValue(playerTurn);

                playerTotalScore += (outcomeScore + rockPaperScissorsValue);
            }

            return playerTotalScore;
        }

        public int PartTwo()
        {
            var input = File.ReadAllLines(@"Input/Day02_Real.txt");

            var playerTotalScore = 0;

            foreach (var line in input)
            {
                var gameLine = line.Split(' ');
                var opponentTurn = ConvertValueToRockPaperScissors(gameLine[0]);
                var expectedOutcome = GetExpectedOutcome(gameLine[1]);
                var playerTurn = GetExpectedPlayerTurn(opponentTurn, expectedOutcome);

                var outcome = GetPlayersOutcomeForTurn(opponentTurn, playerTurn);
                var outcomeScore = GetScoreForOutcome(outcome);
                var rockPaperScissorsValue = GetRockPaperScissorsValue(playerTurn);

                playerTotalScore += (outcomeScore + rockPaperScissorsValue);
            }

            return playerTotalScore;
        }

        public RockPaperScissors GetExpectedPlayerTurn(RockPaperScissors opponent, GameOutcome expectedOutcome)
        {
            if (opponent == RockPaperScissors.Rock)
            {
                if (expectedOutcome == GameOutcome.Draw)
                    return RockPaperScissors.Rock;
                if (expectedOutcome == GameOutcome.Won)
                    return RockPaperScissors.Paper;
                if (expectedOutcome == GameOutcome.Lost)
                    return RockPaperScissors.Scissors;
            }

            if (opponent == RockPaperScissors.Paper)
            {
                if (expectedOutcome == GameOutcome.Draw)
                    return RockPaperScissors.Paper;
                if (expectedOutcome == GameOutcome.Won)
                    return RockPaperScissors.Scissors;
                if (expectedOutcome == GameOutcome.Lost)
                    return RockPaperScissors.Rock;
            }

            if (opponent == RockPaperScissors.Scissors)
            {
                if (expectedOutcome == GameOutcome.Draw)
                    return RockPaperScissors.Scissors;
                if (expectedOutcome == GameOutcome.Won)
                    return RockPaperScissors.Rock;
                if (expectedOutcome == GameOutcome.Lost)
                    return RockPaperScissors.Paper;
            }

            throw new Exception($"Reached Unsupported State in GetExpectedPlayerTurn. ({opponent}) ({expectedOutcome})");
        }

        public GameOutcome GetPlayersOutcomeForTurn(RockPaperScissors opponent, RockPaperScissors player)
        {
            if (opponent == RockPaperScissors.Rock)
            {
                if (player == RockPaperScissors.Rock)
                    return GameOutcome.Draw;
                if (player == RockPaperScissors.Paper)
                    return GameOutcome.Won;
                if (player == RockPaperScissors.Scissors)
                    return GameOutcome.Lost;
            }

            if (opponent == RockPaperScissors.Paper)
            {
                if (player == RockPaperScissors.Rock)
                    return GameOutcome.Lost;
                if (player == RockPaperScissors.Paper)
                    return GameOutcome.Draw;
                if (player == RockPaperScissors.Scissors)
                    return GameOutcome.Won;
            }

            if (opponent == RockPaperScissors.Scissors)
            {
                if (player == RockPaperScissors.Rock)
                    return GameOutcome.Won;
                if (player == RockPaperScissors.Paper)
                    return GameOutcome.Lost;
                if (player == RockPaperScissors.Scissors)
                    return GameOutcome.Draw;
            }

            throw new Exception($"Reached Unsupported State in GetPlayersOutcomeForTurn. ({opponent}) vs ({player})");
        }

        public RockPaperScissors ConvertValueToRockPaperScissors(string value) =>
            value switch
            {
                "A" => RockPaperScissors.Rock,
                "B" => RockPaperScissors.Paper,
                "C" => RockPaperScissors.Scissors,
                "X" => RockPaperScissors.Rock,
                "Y" => RockPaperScissors.Paper,
                "Z" => RockPaperScissors.Scissors,
                _ => throw new Exception($"Unsupported Value: {value}")
            };

        public GameOutcome GetExpectedOutcome(string value) =>
             value switch
             {
                 "X" => GameOutcome.Lost,
                 "Y" => GameOutcome.Draw,
                 "Z" => GameOutcome.Won,
                 _ => throw new Exception($"Unsupported Value: {value}")
             };

        public int GetScoreForOutcome(GameOutcome outcome) =>
            outcome switch
            {
                GameOutcome.Lost => 0,
                GameOutcome.Draw => 3,
                GameOutcome.Won => 6,
                _ => throw new Exception($"Unsupported Outcome: {outcome}")
            };

        public int GetRockPaperScissorsValue(RockPaperScissors rockPaperScissors) =>
            rockPaperScissors switch
            {
                RockPaperScissors.Rock => 1,
                RockPaperScissors.Paper => 2,
                RockPaperScissors.Scissors => 3,
                _ => throw new Exception($"Unsupported RockPaperScissors: ${rockPaperScissors}")
            };

        public enum GameOutcome
        {
            Lost,
            Draw,
            Won
        }

        public enum RockPaperScissors
        {
            Rock,
            Paper,
            Scissors
        }
    }
}
