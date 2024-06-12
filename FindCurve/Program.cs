using FindCurveLib;
using FindCurveLib.Neighbor;
internal class Program
{
    private static void Main(string[] args)
    {
        int[,] matrix =  InitMatrix(10);

        // Вывод массива на консоль
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        FindCurve fc = new FindCurve(matrix, TypeNeighbor.Eight,4);
        fc.Proccess();

        var result = fc.GetPoints();

        Console.WriteLine("Максимальаня сумма: " + result.MaxSum);

        Console.WriteLine("Точки:");
        foreach (var pair in result.points)
        {
            Console.Write($"| X:{pair.X} Y:{pair.Y} | ");
        }
        Console.WriteLine("\n");
        // Вывод массива на консоль
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if(result.points.Contains(new System.Drawing.Point(i, j))) 
                    Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(matrix[i, j] + " ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        Console.ReadLine();
    }
    private static int[,] InitMatrix(int Size)
    {
        int[,] array = new int[Size, Size];
        Random rand = new Random();

        // Заполнение массива случайными цифрами
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                array[i, j] = rand.Next(0, 10);
            }
        }
        return array;
    }
}