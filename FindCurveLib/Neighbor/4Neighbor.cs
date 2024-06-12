using System.Drawing;

namespace FindCurveLib.Neighbor
{
    public class _4Neighbor : INeighbor
    {
        public List<Point> getNeighbor(int[,] map, int x, int y)
        {
            var result = new List<Point>();

            int thisValue = map[x,y];

            // Check neighbor up
            if (y - 1 >= 0 && thisValue == map[x, y - 1])
                result.Add(new Point(x, y - 1));

            // Check neighbor down
            if (y + 1 < map.GetLength(1) && thisValue == map[x, y + 1])
                result.Add(new Point(x, y + 1));

            // Check neighbor left
            if (x - 1 >= 0 && thisValue == map[x - 1, y])
                result.Add(new Point(x - 1, y));

            // Check neighbor right
            if (x + 1 < map.GetLength(0) && thisValue == map[x + 1, y])
                result.Add(new Point(x + 1, y));

            return result;
        }
    }
}
