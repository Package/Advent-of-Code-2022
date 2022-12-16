namespace AdventOfCode.Solutions
{
    public class Day08 : ISolution<int>
    {
        public int PartOne()
        {
            var map = ParseCells(@"Input/Day08_Real.txt");

            var visibleTreeCount = 0;
            
            for (var x = 0; x < map.Width; x++)
            {
                for (var y = 0; y < map.Height; y++)
                {
                    if (map.IsTreeVisible(x, y))
                    {
                        visibleTreeCount++;
                    }
                }
            }
                
            return visibleTreeCount;
        }

        public int PartTwo()
        {
            return 0;
        }

        public Map ParseCells(string inputFile)
        {
            var input = File.ReadAllLines(inputFile);
            
            var cells = new Cell[input.Length, input[0].Length];

            for (var x = 0; x < input.Length; x++)
            {
                for (var y = 0; y < input[x].Length; y++)
                {
                    var height = int.Parse(input[x][y].ToString());
                    cells[x, y] = new Cell(x, y, height);
                }
            }

            return new Map
            {
                Width = input.Length,
                Height = input[0].Length,
                Cells = cells
            };
        }
        
        public record Cell(int X, int Y, int Height);

        public class Map
        {
            public int Width { get; init; }
            public int Height { get; init; }
            public Cell[,] Cells { get; init; } = null!;

            public bool IsTreeVisible(int x, int y)
            {
                // Tree on the edge - always visible
                if (x == 0 || x == Width - 1 || x == Height - 1)
                    return true;
                
                // Tree on the edge - always visible
                if (y == 0 || y == Width - 1 || y == Height - 1)
                    return true;

                return IsVisibleUp(x, y) || IsVisibleDown(x, y) || IsVisibleLeft(x, y) || IsVisibleRight(x, y);
            }

            private bool IsVisibleDown(int x, int y)
            {
                for (var currY = y + 1; currY < Height; currY++)
                {
                    if (Cells[x, currY].Height >= Cells[x, y].Height)
                        return false; 
                }
                
                return true;
            }

            private bool IsVisibleUp(int x, int y)
            {
                for (var currY = y - 1; currY >= 0; currY--)
                {
                    if (Cells[x, currY].Height >= Cells[x, y].Height)
                        return false;  
                }
  
                return true;
            }

            private bool IsVisibleRight(int x, int y)
            {
                for (var currX = x + 1; currX < Width; currX++)
                {
                    if (Cells[currX, y].Height >= Cells[x, y].Height)
                        return false;   
                }
                
                return true;
            }

            private bool IsVisibleLeft(int x, int y)
            {
                for (var currX = x - 1; currX >= 0; currX--)
                {
                    if (Cells[currX, y].Height >= Cells[x, y].Height)
                        return false;                   
                }
                
                return true;
            }
        }
    }
}