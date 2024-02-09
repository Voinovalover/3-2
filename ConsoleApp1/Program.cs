using System;

abstract class ArrayBase
{
    public abstract void Initialize();
    public abstract double CalculateAverage();
    public abstract void Print();
}

sealed class OneDimensionalArray : ArrayBase
{
    private double[] array;

    public override void Initialize()
    {
        array = new double[] { 1, 2, 3 };
    }

    public override double CalculateAverage()
    {
        double sum = 0;
        foreach (double num in array)
        {
            sum += num;
        }
        return sum / array.Length;
    }

    public override void Print()
    {
        Console.Write("One-dimensional array: ");
        foreach (double num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}

sealed class MultidimensionalArray : ArrayBase
{
    private int[,] array;

    public override void Initialize()
    {
        array = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
    }

    public override double CalculateAverage()
    {
        int sum = 0;
        int count = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                sum += array[i, j];
                count++;
            }
        }
        return (double)sum / count;
    }

    public override void Print()
    {
        Console.WriteLine("Multidimensional array:");
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
sealed class JaggedArray : ArrayBase
{
    private int[][] array;

    public override void Initialize()
    {
        array = new int[][]
        {
            new int[] { 1 },
            new int[] { 2, 3 },
            new int[] { 4, 5, 6 }
        };
    }

    public override double CalculateAverage()
    {
        int sum = 0;
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                sum += array[i][j];
                count++;
            }
        }
        return (double)sum / count;
    }

    public override void Print()
    {
        Console.WriteLine("Jagged array:");
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArrayBase[] array = new ArrayBase[3];

        array[0] = new OneDimensionalArray();
        array[1] = new MultidimensionalArray();
        array[2] = new JaggedArray();

        for (int i = 0; i < array.Length; i++)
        {
            array[i].Initialize();
            double average = array[i].CalculateAverage();
            array[i].Print();
            Console.WriteLine("Average: " + average);
        }
    }
}
