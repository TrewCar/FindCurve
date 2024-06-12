using FindCurveLib.Neighbor;
using System.Drawing;

namespace FindCurveLib
{
    public class FindCurve
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix">Матрица x на y</param>
        /// <param name="neighbor">Выборка соседей 8 или 4</param>
        /// <param name="maxLenCurve"></param>
        public FindCurve(int[,] matrix, TypeNeighbor neighbor, int maxLenCurve = 4)
        {
            this.matrix = matrix;
            this.neighbor = InitNeighbor.Init(neighbor);
            exist = new int[matrix.GetLength(0), matrix.GetLength(1)];
            this.maxLenCurve = maxLenCurve;
        }
        private int[,] matrix; // Матрица
        private INeighbor neighbor;
        private int[,] exist; // Ячейки где я уже был

        private int maxLenCurve = 4; // Максимальаня длина кривой

        private List<Point> listPosMax = new List<Point>();
        private int nowSum = -1;

        public void Proccess()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (exist[i, j] == 1)
                        continue;

                    var list = new List<Point>();

                    this.Step(i,j, list);

                    if(list.Count >= maxLenCurve)
                    {
                        CheckMax(list);
                    }
                }
            }
        }

        public (int MaxSum, List<Point> points) GetPoints() => (nowSum, listPosMax);
        
        private void CheckMax(List<Point> points)
        {
            int temp = 0;
            foreach(Point p in points)
            {
                temp += matrix[p.X, p.Y];
            }
            if(temp > nowSum)
            {
                nowSum = temp;
                listPosMax = points;
            }
        }

        private List<Point> Step(int x, int y, List<Point> points)
        {
            points.Add(new Point(x, y));
            exist[x, y] = 1;

            var neighbors = neighbor.getNeighbor(matrix, x, y);

            if (neighbors.Count == 0 || points.Count == maxLenCurve)
                return points;

            foreach(Point p in neighbors)
            {
                if (exist[p.X, p.Y] == 1)
                    continue;
                Step(p.X, p.Y, points);

                if (points.Count == maxLenCurve)
                    return points;

                points.RemoveAt(points.Count - 1); // иначе удалить - нужно чтобы получилась линия а не дерево
            }
            return points;
        }
    }
}
