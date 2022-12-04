namespace AdventOfCode.Solutions
{
    public class Day04 : ISolution<int>
    {
        public int PartOne()
        {
            var input = File.ReadAllLines(@"Input/Day04_Real.txt");

            return input
                .Select(ParseLine)
                .Count(pairs => IsFullPairOverlapping(pairs.firstPair, pairs.secondPair));
        }

        public int PartTwo()
        {
            var input = File.ReadAllLines(@"Input/Day04_Real.txt");

            return input
                .Select(ParseLine)
                .Count(pairs => IsPartOfPairOverlapping(pairs.firstPair, pairs.secondPair));
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

        public bool IsFullPairOverlapping(Pair firstPair, Pair secondPair)
            => (firstPair.Start >= secondPair.Start && firstPair.End <= secondPair.End) ||
               (secondPair.Start >= firstPair.Start && secondPair.End <= firstPair.End);

        public bool IsPartOfPairOverlapping(Pair firstPair, Pair secondPair)
            => (firstPair.Start >= secondPair.Start && firstPair.Start <= secondPair.End) ||
               (firstPair.End >= secondPair.Start && firstPair.End <= secondPair.End) ||
               (secondPair.Start >= firstPair.Start && secondPair.Start <= firstPair.End) ||
               (secondPair.End >= firstPair.Start && secondPair.End <= firstPair.End);

        public record Pair(int Start, int End);
    }
}