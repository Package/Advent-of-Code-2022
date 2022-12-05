using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions
{
    public class Day05 : ISolution<string>
    {
        private readonly Regex _charRegex = new(@"[\[(A-Z)\]]+", RegexOptions.Compiled);
        private readonly Regex _moveRegex = new(@"move ([\d]+) from ([\d]+) to ([\d]+)", RegexOptions.Compiled);

        public string PartOne()
        {
            var crateMap = ParseInitialCrates(@"Input/Day05_Real.txt");
            var moveInstructions = ParseInstructions(@"Input/Day05_Real.txt");

            foreach (var instruction in moveInstructions)
            {
                var movingFromCrate = crateMap[instruction.FromCrate];
                var movingToCrate = crateMap[instruction.ToCreate];
                
                for (var amount = 0; amount < instruction.AmountToMove; amount++)
                {
                    movingToCrate.Push(movingFromCrate.Pop());
                }
            }

            var firstItemsInEachStack = string.Empty;
            
            var sortedCrateMap = crateMap.OrderBy(cm => cm.Key).ToList();
            sortedCrateMap.ForEach(stack => firstItemsInEachStack += stack.Value.Peek());

            return firstItemsInEachStack;
        }
        
        public string PartTwo()
        {
            var crateMap = ParseInitialCrates(@"Input/Day05_Real.txt");
            var moveInstructions = ParseInstructions(@"Input/Day05_Real.txt");

            foreach (var instruction in moveInstructions)
            {
                var movingFromCrate = crateMap[instruction.FromCrate];
                var movingToCrate = crateMap[instruction.ToCreate];
                var poppedCrates = new List<string>();
                
                for (var amount = 0; amount < instruction.AmountToMove; amount++)
                {
                    poppedCrates.Add(movingFromCrate.Pop());
                }

                poppedCrates.Reverse();
                poppedCrates.ForEach(crate => movingToCrate.Push(crate));
            }

            var firstItemsInEachStack = string.Empty;
            
            var sortedCrateMap = crateMap.OrderBy(cm => cm.Key).ToList();
            sortedCrateMap.ForEach(stack => firstItemsInEachStack += stack.Value.Peek());

            return firstItemsInEachStack;
        }
        
        public List<CrateInstruction> ParseInstructions(string inputFile)
        {
            var input = File.ReadAllLines(inputFile);
            var crateInstructions = new List<CrateInstruction>();

            foreach (var line in input)
            {
                var moveMatch = _moveRegex.Match(line);
                if (!moveMatch.Success)
                    continue;

                var instruction = new CrateInstruction(int.Parse(moveMatch.Groups[1].Value),
                    int.Parse(moveMatch.Groups[2].Value), int.Parse(moveMatch.Groups[3].Value));
                crateInstructions.Add(instruction);
            }

            return crateInstructions;
        }
        
        public Dictionary<int, Stack<string>> ParseInitialCrates(string inputFile)
        {
            var input = File.ReadAllLines(inputFile);
            var crateMap = new Dictionary<int, Stack<string>>();

            foreach (var line in input)
            {
                var crateMatch = _charRegex.Match(line);
                while (crateMatch.Success)
                {
                    var stackIndex = crateMatch.Index / 4 + 1;
                    var character = crateMatch.Groups[0].Value.Replace("[", "").Replace("]", "");

                    if (!crateMap.ContainsKey(stackIndex))
                        crateMap[stackIndex] = new Stack<string>();

                    crateMap[stackIndex].Push(character);
                    crateMatch = crateMatch.NextMatch();
                }
            }

            foreach (var crateKey in crateMap.Keys)
            {
                // Hacky trick to reverse the stacks
                crateMap[crateKey] = new Stack<string>(crateMap[crateKey]);
            }

            return crateMap;
        }

        public record CrateInstruction(int AmountToMove, int FromCrate, int ToCreate);
    }
}