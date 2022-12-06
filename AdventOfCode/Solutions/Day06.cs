namespace AdventOfCode.Solutions
{
    public class Day06 : ISolution<int>
    {
        private const int DefaultPacketSize = 4;
        
        public int PartOne()
        {
            var input = File.ReadAllText(@"Input/Day06_Real.txt");
            return GetStartOfPacket(input);
        }

        public int PartTwo()
        {
            return 0;
        }

        public int GetStartOfPacket(string packetString, int packetSize = DefaultPacketSize)
        {
            for (var index = 0; index < packetString.Length - packetSize; index++)
            {
                var currentRange = packetString.Substring(index, 4);
                var uniqueCharacters = currentRange.ToCharArray().Distinct();

                if (uniqueCharacters.Count() == packetSize)
                    return index + packetSize;
            }

            throw new Exception($"Could not find a start of packet marker in the input string: {packetString}");
        }
    }
}