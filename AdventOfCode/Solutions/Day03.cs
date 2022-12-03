namespace AdventOfCode.Solutions
{
    public class Day03 : ISolution<int>
    {
        private const int UppercaseCharacterOffset = 38;
        private const int LowercaseCharacterOffset = 96;
        public const int NumRucksacksPerGroup = 3;

        public int PartOne()
        {
            var input = File.ReadAllLines(@"Input/Day03_Real.txt");

            return input
                .Select(line => new Rucksack(line))
                .Select(rucksack => rucksack.GetItemsInAllCompartments())
                .Sum(SumCharacters);
        }

        public int PartTwo()
        {
            var rucksackGroups = ParseRucksackGroups(@"Input/Day03_Real.txt");

            return rucksackGroups
                .Select(group => group.GetBadge())
                .Sum(ConvertCharacterToScore);
        }

        public List<RucksackGroup> ParseRucksackGroups(string inputFile)
        {
            var input = File.ReadAllLines(inputFile);

            var rucksackGroups = new List<RucksackGroup>();
            var currentGroup = new RucksackGroup();

            foreach (var line in input)
            {
                var rucksack = new Rucksack(line);

                if (currentGroup.RucksackCount() == NumRucksacksPerGroup)
                {
                    rucksackGroups.Add(currentGroup);
                    currentGroup = new RucksackGroup();
                }

                currentGroup.AddRucksack(rucksack);
            }

            rucksackGroups.Add(currentGroup);

            return rucksackGroups;
        }

        public int SumCharacters(IEnumerable<char> characters) => characters.Sum(ConvertCharacterToScore);

        public int ConvertCharacterToScore(char character)
        {
            var characterOffset = char.IsUpper(character) ? UppercaseCharacterOffset : LowercaseCharacterOffset;
            return character - characterOffset;
        }

        public class RucksackGroup
        {
            private readonly List<Rucksack> _rucksacks = new();

            public void AddRucksack(Rucksack rucksack) => _rucksacks.Add(rucksack);

            public int RucksackCount() => _rucksacks.Count;

            public char GetBadge()
            {
                var firstRucksackValue = _rucksacks.First().Value;

                return firstRucksackValue.First(character => _rucksacks.All(r => r.Value.Contains(character)));
            }
        }

        public class Rucksack
        {
            public string FirstCompartment { get; }
            public string SecondCompartment { get; }
            public string Value { get; }

            public Rucksack(string input)
            {
                var inputLength = input.Length / 2;

                FirstCompartment = input[..inputLength];
                SecondCompartment = input[inputLength..];
                Value = input;
            }

            public List<char> GetItemsInAllCompartments() =>
                FirstCompartment.Intersect(SecondCompartment).ToList();
        }
    }
}