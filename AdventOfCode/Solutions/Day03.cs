namespace AdventOfCode.Solutions
{
    public class Day03 : ISolution<int>
    {
        public const int UppercaseCharacterOffset = 38;
        public const int LowercaseCharacterOffset = 96;
        public const int NumRucksacksPerGroup = 3;

        public int PartOne()
        {
            var input = File.ReadAllLines(@"Input/Day03_Real.txt");

            var totalSum = 0;
            foreach (var line in input)
            {
                var rucksack = new Rucksack(line);
                var repeatedItems = rucksack.GetItemsInAllCompartments();
                totalSum += SumCharacters(repeatedItems);
            }

            return totalSum;
        }

        public int PartTwo()
        {
            var totalSum = 0;

            var rucksackGroups = ParseRucksackGroups(@"Input/Day03_Real.txt");
            foreach (var group in rucksackGroups)
            {
                var groupBadge = group.GetBadge();
                totalSum += ConvertCharacterToScore(groupBadge);
            }

            return totalSum;
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

        public int SumCharacters(List<char> characters) => characters.Sum(c => ConvertCharacterToScore(c));

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
                foreach (var character in _rucksacks[0].Value)
                {
                    var foundBadge = true;

                    foreach (var rucksack in _rucksacks)
                    {
                        // This character isn't present in one of the rucksacks so it cannot be the badge.
                        if (!rucksack.Value.Contains(character))
                        {
                            foundBadge = false;
                            break;
                        }
                    }

                    // This character was in every rucksack so must be the badge.
                    if (foundBadge)
                        return character;
                }

                throw new Exception("Could not find a badge for the RucksackGroup.");
            }
        }

        public class Rucksack
        {
            private readonly List<List<char>> _compartments = new();
            public string Value { get; }

            public Rucksack(string input)
            {
                var inputLength = input.Length / 2;

                var firstCompartment = input[0..inputLength];
                var secondCompartment = input[inputLength..];

                _compartments.Add(firstCompartment.ToList());
                _compartments.Add(secondCompartment.ToList());

                Value = input;
            }

            public string GetCompartmentAsString(int compartmentIndex)
            {
                return string.Concat(_compartments[compartmentIndex - 1]);
            }

            public List<char> GetItemsInAllCompartments()
            {
                var repeatedItems = new List<char>();

                foreach (var compartment in _compartments)
                {
                    foreach (var character in compartment)
                    {
                        if (repeatedItems.Contains(character))
                            continue;

                        var otherCompartment = _compartments.FirstOrDefault(c => c.Contains(character) && c != compartment);
                        if (otherCompartment != null)
                        {
                            repeatedItems.Add(character);
                        }
                    }
                }

                return repeatedItems;
            }
        }
    }
}
