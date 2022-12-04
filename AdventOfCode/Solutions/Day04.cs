using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions
{
    public class Day04 : ISolution<int>
    {
        private readonly Regex _linePattern = new(@"^([\d]+)-([\d]+),([\d]+)-([\d]+)$", RegexOptions.Compiled);
        
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
            var match = _linePattern.Match(line);

            var firstPair = new Pair(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
            var secondPair = new Pair(int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value));

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