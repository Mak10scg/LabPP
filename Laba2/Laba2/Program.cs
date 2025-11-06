using System;
using System.Collections.Generic;

public class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

}

public class Vector2D
{
    private Point Start { get; set; }
    private Point End { get; set; }

    private double ProjectionX => End.X - Start.X;
    private double ProjectionY => End.Y - Start.Y;


    public Vector2D(Point start, Point end)
    {
        Start = start;
        End = end;
    }

    public Vector2D(double x, double y)
    {
        Start = new Point(0, 0);
        End = new Point(x, y);
    }
    public static Vector2D Sum(Vector2D a, Vector2D b)
    {
        return new Vector2D(a.ProjectionX + b.ProjectionX, a.ProjectionY + b.ProjectionY);
    }
    public static Vector2D Minus(Vector2D a, Vector2D b)
    {
        return new Vector2D(a.ProjectionX - b.ProjectionX, a.ProjectionY - b.ProjectionY);
    }
    public static Vector2D Multyply(Vector2D v, int scalar)
    {
        return new Vector2D(v.ProjectionX * scalar, v.ProjectionY * scalar);
    }
    public static double Length(Vector2D v)
    {
        return Math.Sqrt(v.ProjectionX * v.ProjectionX + v.ProjectionY * v.ProjectionY);
    }
    public static Vector2D Sum(params Vector2D[] vectors)
    {
        double sumX = vectors.Sum(v => v.ProjectionX);
        double sumY = vectors.Sum(v => v.ProjectionY);
        return new Vector2D(sumX, sumY);
    }
    public override string ToString()
    {
        return $"Vector({ProjectionX:F2}, {ProjectionY:F2}), Length = {Length(this):F2}";
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Введите количество векторов: ");
        int count = int.Parse(Console.ReadLine() ?? "0");

        var vectors = new List<Vector2D>();
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("\nВектор " + (i + 1));
            Console.Write("Введите x1: ");
            double x1 = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Введите y1: ");
            double y1 = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Введите x2: ");
            double x2 = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Введите y2: ");
            double y2 = double.Parse(Console.ReadLine() ?? "0");
            vectors.Add(new Vector2D(new Point(x1, y1), new Point(x2, y2)));
        }

        Console.Write("Введите скаляр: ");
        int scalar = int.Parse(Console.ReadLine() ?? "0");


        if (vectors.Count == 1)
        {
            Console.WriteLine("Умножение вектора на скаляр = " + Vector2D.Multyply(vectors[0], scalar));

        }

        if (vectors.Count >= 2)
        {
            Console.WriteLine("Сумма первый двух вектров = " + Vector2D.Sum(vectors[0], vectors[1]));
            Console.WriteLine("Разность первый двух вектров = " + Vector2D.Minus(vectors[0], vectors[1]));
            Console.WriteLine("Умножение вектора на скаляр = " + Vector2D.Multyply(vectors[0], scalar));
            //Console.WriteLine("Длина первого вектора = " + Vector2D.Length(vectors[0]));
        }

        if (vectors.Count >= 3)
        {
            var sum = Vector2D.Sum(vectors.ToArray());
            Console.WriteLine("Сумма всех векторов = " + sum);
        }

    }
}