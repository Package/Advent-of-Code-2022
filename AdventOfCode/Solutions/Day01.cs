namespace AdventOfCode.Solutions
{
    public class Day01 : ISolution<int>
    {
        public int PartOne()
        {
            return GetElfCarryingMostCaloriesInFile(@"Input/Day01_Real.txt", 1);
        }

        public int PartTwo()
        {
            return GetElfCarryingMostCaloriesInFile(@"Input/Day01_Real.txt", 3);
        }

        public int GetElfCarryingMostCaloriesInFile(string filePath, int numElfsToTake)
        {
            var input = File.ReadAllLines(filePath);

            var elfTotals = new List<int>();
            var currentTotal = 0;

            foreach (var line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    elfTotals.Add(currentTotal);
                    currentTotal = 0;
                }
                else
                {
                    currentTotal += int.Parse(line);
                }
            }

            elfTotals.Add(currentTotal);

            return elfTotals.OrderByDescending(_ => _).Take(numElfsToTake).Sum();
        }
    }
}
