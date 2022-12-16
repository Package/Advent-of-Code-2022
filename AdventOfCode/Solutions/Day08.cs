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
            var map = ParseCells(@"Input/Day08_Real.txt");

            var bestViewingDistance = 0;
            
            for (var x = 0; x < map.Width; x++)
            {
                for (var y = 0; y < map.Height; y++)
                {
                    var currentViewingDistance = map.GetTreeViewingDistance(x, y);
                    if (currentViewingDistance > bestViewingDistance)
                        bestViewingDistance = currentViewingDistance;
                }
            }
                
            return bestViewingDistance;
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

                var (visibleUp, distanceUp) = VisibilityUp(x, y);
                var (visibleDown, distanceDown) = VisibilityDown(x, y);
                var (visibleLeft, distanceLeft) = VisibilityLeft(x, y);
                var (visibleRight, distanceRight) = VisibilityRight(x, y);

                return visibleUp || visibleDown || visibleLeft || visibleRight;
            }
            
            public int GetTreeViewingDistance(int x, int y)
            {
                // Tree on the edge - always visible
                if (x == 0 || x == Width - 1 || x == Height - 1)
                    return 0;
                
                // Tree on the edge - always visible
                if (y == 0 || y == Width - 1 || y == Height - 1)
                    return 0;

                var (visibleUp, distanceUp) = VisibilityUp(x, y);
                var (visibleDown, distanceDown) = VisibilityDown(x, y);
                var (visibleLeft, distanceLeft) = VisibilityLeft(x, y);
                var (visibleRight, distanceRight) = VisibilityRight(x, y);

                if (visibleUp || visibleDown || visibleLeft || visibleRight)
                    return distanceUp * distanceLeft * distanceRight * distanceDown;

                return 0;
            }            

            private (bool isVisible, int distance) VisibilityDown(int x, int y)
            {
                var visibility = 0;
                
                for (var currY = y + 1; currY < Height; currY++)
                {
                    visibility++;

                    if (Cells[x, currY].Height >= Cells[x, y].Height)
                        return (false, visibility); 
                }
                
                return (true, visibility);
            }

            private (bool isVisible, int distance) VisibilityUp(int x, int y)
            {
                var visibility = 0;
                
                for (var currY = y - 1; currY >= 0; currY--)
                {
                    visibility++;

                    if (Cells[x, currY].Height >= Cells[x, y].Height)
                        return (false, visibility);
                }
  
                return (true, visibility);
            }

            private (bool isVisible, int distance) VisibilityRight(int x, int y)
            {
                var visibility = 0;
                
                for (var currX = x + 1; currX < Width; currX++)
                {
                    visibility++;
                    
                    if (Cells[currX, y].Height >= Cells[x, y].Height)
                        return (false, visibility);
                }
                
                return (true, visibility);
            }

            private (bool isVisible, int distance) VisibilityLeft(int x, int y)
            {
                var visibility = 0;
                
                for (var currX = x - 1; currX >= 0; currX--)
                {
                    visibility++;

                    if (Cells[currX, y].Height >= Cells[x, y].Height)
                        return (false, visibility);
                }
                
                return (true, visibility);
            }
        }
    }
}