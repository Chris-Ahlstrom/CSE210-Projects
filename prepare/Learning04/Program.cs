using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment test = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.Clear();
        Console.WriteLine($"{test.GetSummary()}");
        Console.WriteLine($"{test.GetHomeworkList()}");

        WritingAssignment test2 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine($"\n{test2.GetWritingInformation()}");
    }
}