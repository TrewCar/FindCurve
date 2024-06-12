using System.Drawing;

namespace FindCurveLib.Neighbor
{
    public interface INeighbor
    {
        public List<Point> getNeighbor(int[,] map, int x, int y);
    }
}
