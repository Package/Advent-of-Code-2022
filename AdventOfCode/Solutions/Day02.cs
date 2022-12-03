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

        public RockPaperScissors GetExpectedPlayerTurn(RockPaperScissors opponent, GameOutcome expectedOutcome) =>
            opponent switch
            {
                RockPaperScissors.Rock when expectedOutcome == GameOutcome.Draw => RockPaperScissors.Rock,
                RockPaperScissors.Rock when expectedOutcome == GameOutcome.Won => RockPaperScissors.Paper,
                RockPaperScissors.Rock when expectedOutcome == GameOutcome.Lost => RockPaperScissors.Scissors,
                RockPaperScissors.Paper when expectedOutcome == GameOutcome.Draw => RockPaperScissors.Paper,
                RockPaperScissors.Paper when expectedOutcome == GameOutcome.Won => RockPaperScissors.Scissors,
                RockPaperScissors.Paper when expectedOutcome == GameOutcome.Lost => RockPaperScissors.Rock,
                RockPaperScissors.Scissors when expectedOutcome == GameOutcome.Draw => RockPaperScissors.Scissors,
                RockPaperScissors.Scissors when expectedOutcome == GameOutcome.Won => RockPaperScissors.Rock,
                RockPaperScissors.Scissors when expectedOutcome == GameOutcome.Lost => RockPaperScissors.Paper,
                _ => throw new Exception(
                    $"Reached Unsupported State in GetExpectedPlayerTurn. ({opponent}) ({expectedOutcome})")
            };

        public GameOutcome GetPlayersOutcomeForTurn(RockPaperScissors opponent, RockPaperScissors player) =>
            opponent switch
            {
                RockPaperScissors.Rock when player == RockPaperScissors.Rock => GameOutcome.Draw,
                RockPaperScissors.Rock when player == RockPaperScissors.Paper => GameOutcome.Won,
                RockPaperScissors.Rock when player == RockPaperScissors.Scissors => GameOutcome.Lost,
                RockPaperScissors.Paper when player == RockPaperScissors.Rock => GameOutcome.Lost,
                RockPaperScissors.Paper when player == RockPaperScissors.Paper => GameOutcome.Draw,
                RockPaperScissors.Paper when player == RockPaperScissors.Scissors => GameOutcome.Won,
                RockPaperScissors.Scissors when player == RockPaperScissors.Rock => GameOutcome.Won,
                RockPaperScissors.Scissors when player == RockPaperScissors.Paper => GameOutcome.Lost,
                RockPaperScissors.Scissors when player == RockPaperScissors.Scissors => GameOutcome.Draw,
                _ => throw new Exception(
                    $"Reached Unsupported State in GetPlayersOutcomeForTurn. ({opponent}) vs ({player})")
            };

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
