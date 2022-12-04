namespace AdventOfCode.Solutions
{
    public class Day04 : ISolution<int>
    {
        public int PartOne()
        {
            var input = File.ReadAllLines(@"Input/Day04_Real.txt");

            return input
                .Select(ParseLine)
                .Count(pairs => IsPairOverlapping(pairs.firstPair, pairs.secondPair));
        }

        public int PartTwo()
        {
            return 0;
        }

        public (Pair firstPair, Pair secondPair) ParseLine(string line)
        {
            var split = line.Split(",");

            var firstPairLine = split[0].Split("-");
            var secondPairLine = split[1].Split("-");

            var firstPair = new Pair(int.Parse(firstPairLine[0]), int.Parse(firstPairLine[1]));
            var secondPair = new Pair(int.Parse(secondPairLine[0]), int.Parse(secondPairLine[1]));

            return (firstPair, secondPair);
        }

        public bool IsPairOverlapping(Pair firstPair, Pair secondPair)
            => (firstPair.Start >= secondPair.Start && firstPair.End <= secondPair.End) ||
               (secondPair.Start >= firstPair.Start && secondPair.End <= firstPair.End);

        public record Pair(int Start, int End);
    }
}