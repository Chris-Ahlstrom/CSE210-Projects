using System;
using System.Globalization;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int numToAdd;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.Write("Enter number: ");
            numToAdd = int.Parse(Console.ReadLine());
            numbers.Add(numToAdd);
        } while (numToAdd != 0);
        numbers.Sort();
        int total = 0;
        foreach (int number in numbers)
        {
            total += number;
        }
        float average = (float)total / (numbers.Count - 1);
        int maximum = numbers[numbers.Count - 1];
        int minimum = total;
        for (int i = 0; i < numbers.Count; i++)
        {
            int current = numbers[i];
            if (minimum > current && current > 0)
            {
                minimum = current;
            }
        }
        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maximum}");
        Console.WriteLine($"The smallest positive number is: {minimum}");
        Console.WriteLine($"The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}