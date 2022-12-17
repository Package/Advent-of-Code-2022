namespace AdventOfCode.Solutions
{
    public class Day10 : ISolution<int>
    {
        private readonly int[] _cyclesOfInterest = { 20, 60, 100, 140, 180, 220 };
        private const int MaxCycleNumber = 220;
        private const int NumberOfCyclesToWait = 2;
        
        public int PartOne()
        {
            var instructions = ParseInstructions(@"Input/Day10_Real.txt");

            var signalStrengths = new List<int>();
            var registerValue = 1;
            var currentCycle = 0;
            var cyclesWaiting = 0;
            Instruction? currentInstruction = null;

            while (currentCycle <= MaxCycleNumber)
            {
                currentCycle++;
                currentInstruction ??= instructions.Dequeue();

                switch (currentInstruction.InstructionType)
                {
                    case InstructionType.Add:
                        cyclesWaiting++;
                        break;
                    case InstructionType.Noop:
                        currentInstruction = null;
                        break;
                }
                
                if (cyclesWaiting == NumberOfCyclesToWait)
                {
                    registerValue += currentInstruction!.Value;
                    cyclesWaiting = 0;
                    currentInstruction = null;
                }
                
                if (_cyclesOfInterest.Contains(currentCycle))
                {
                    signalStrengths.Add(currentCycle * registerValue);
                }
            }
            
            return signalStrengths.Sum();
        }

        public int PartTwo()
        {
            return 0;
        }

        private Queue<Instruction> ParseInstructions(string inputFile)
        {
            var instructions = new Queue<Instruction>();

            var input = File.ReadAllLines(inputFile);
            foreach (var line in input)
            {
                if (line.StartsWith("add"))
                {
                    var amount = int.Parse(line.Split(" ")[1]);
                    instructions.Enqueue(new Instruction(InstructionType.Add, amount));
                }
                else if (line.StartsWith("noop"))
                {
                    instructions.Enqueue(new Instruction(InstructionType.Noop));
                }
            }
            
            return instructions;
        }

        private enum InstructionType
        {
            Add,
            Noop
        }

        private record Instruction(InstructionType InstructionType, int Value = 0);
    }
}