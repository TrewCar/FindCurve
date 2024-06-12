using System.Drawing;

namespace FindCurveLib.Neighbor
{
    public class _8Neighbor : INeighbor
    {
        public List<Point> getNeighbor(int[,] map, int x, int y)
        {
            var result = new List<Point>();

            int thisValue = map[x, y];

            for (var i = x - 1; i <= x + 1; i++)
            {
                for (var j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y ||
                       i < 0 || j < 0 ||
                       i >= map.GetLength(0) || j >= map.GetLength(1))
                        continue;

                    if (thisValue != map[i, j])
                        continue;

                    result.Add(new Point(i, j));
                }
            }

            return result;
        }
    }
}
