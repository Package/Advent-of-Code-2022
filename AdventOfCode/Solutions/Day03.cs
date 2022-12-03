namespace AdventOfCode.Solutions
{
    public class Day03 : ISolution<int>
    {
        private const int UppercaseCharacterOffset = 38;
        private const int LowercaseCharacterOffset = 96;

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
            return 0;
        }

        public int SumCharacters(List<char> characters) => characters.Sum(c => ConvertCharacterToScore(c));

        public int ConvertCharacterToScore(char character)
        {
            var characterOffset = char.IsUpper(character) ? UppercaseCharacterOffset : LowercaseCharacterOffset;
            return character - characterOffset;
        }

        public class Rucksack
        {
            private List<List<char>> _compartments = new();

            public Rucksack(string input)
            {
                var inputLength = input.Length / 2;

                var firstCompartment = input[0..inputLength];
                var secondCompartment = input[inputLength..];

                _compartments.Add(firstCompartment.ToList());
                _compartments.Add(secondCompartment.ToList());
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
