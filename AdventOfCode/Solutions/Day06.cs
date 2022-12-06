namespace AdventOfCode.Solutions
{
    public class Day06 : ISolution<int>
    {
        public const int StartOfPacketMarkerSize = 4;
        public const int StartOfMessageMarkerSize = 14;
        
        public int PartOne()
        {
            var input = File.ReadAllText(@"Input/Day06_Real.txt");
            return GetStartMarker(input, packetSize: StartOfPacketMarkerSize);
        }

        public int PartTwo()
        {
            var input = File.ReadAllText(@"Input/Day06_Real.txt");
            return GetStartMarker(input, packetSize: StartOfMessageMarkerSize);
        }

        public int GetStartMarker(string packetString, int packetSize)
        {
            for (var index = 0; index < packetString.Length - packetSize; index++)
            {
                var currentRange = packetString.Substring(index, packetSize);
                var uniqueCharacters = currentRange.ToCharArray().Distinct();

                if (uniqueCharacters.Count() == packetSize)
                    return index + packetSize;
            }

            throw new Exception($"Could not find a start marker in the input string: {packetString}");
        }
    }
}