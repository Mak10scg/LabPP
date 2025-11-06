using System;

namespace Laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов: ");
            int count = int.Parse(Console.ReadLine());

            Console.Write("Введите минимальное значение: ");
            double minValue = double.Parse(Console.ReadLine());

            Console.Write("Введите максимальное значение: ");
            double maxValue = double.Parse(Console.ReadLine());

            double[] numbers = new double[count];
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                double randomValue = minValue + (maxValue - minValue) * random.NextDouble();
                numbers[i] = Math.Round(randomValue, 2);
            }

            Console.WriteLine("\nСгенерированные числа:");
            for (int i = 0; i < count; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();

            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += numbers[i];
            }
            double average = sum / count;

            double minimum = numbers[0];
            double maximum = numbers[0];
            for (int i = 1; i < count; i++)
            {
                if (numbers[i] < minimum) minimum = numbers[i];
                if (numbers[i] > maximum) maximum = numbers[i];
            }
            double range = maximum - minimum;

            double sumOfSquares = 0;
            for (int i = 0; i < count; i++)
            {
                double difference = numbers[i] - average;
                sumOfSquares += difference * difference;
            }
            double variance = sumOfSquares / count;
            double standardDeviation = Math.Sqrt(variance);

            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        double temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            double median;
            if (count % 2 == 1)
            {
                median = numbers[count / 2];
            }
            else
            {
                median = (numbers[count / 2 - 1] + numbers[count / 2]) / 2;
            }

            Console.WriteLine("\nСтатистические характеристики:");
            Console.WriteLine("Среднее арифметическое: " + Math.Round(average, 2));
            Console.WriteLine("Медиана: " + Math.Round(median, 2));
            Console.WriteLine("Размах: " + Math.Round(range, 2));
            Console.WriteLine("Стандартное отклонение: " + Math.Round(standardDeviation, 2));
            Console.WriteLine("Дисперсия: " + Math.Round(variance, 2));

            Console.WriteLine("\nГистограмма распределения:");
            int intervalsCount = 5;
            double intervalWidth = (maximum - minimum) / intervalsCount;

            int[] frequency = new int[intervalsCount];

            for (int i = 0; i < count; i++)
            {
                int intervalIndex = (int)((numbers[i] - minimum) / intervalWidth);
                if (intervalIndex == intervalsCount)
                    intervalIndex = intervalsCount - 1;
                frequency[intervalIndex]++;
            }

            for (int i = 0; i < intervalsCount; i++)
            {
                double intervalStart = minimum + i * intervalWidth;
                double intervalEnd = intervalStart + intervalWidth;
                Console.Write($"{Math.Round(intervalStart, 1)}-{Math.Round(intervalEnd, 1)}: ");
                Console.WriteLine(" (" + frequency[i] + ")");
            }

            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}
