using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction one = new Fraction();
        Random rnd = new Random();
        for (int i = 1; i < 21; i++)
        {
            one.SetTop(rnd.Next(0, 20));
            one.SetBottom(rnd.Next(0, 20));
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Fraction {i}: String: {one.GetFractionString()} Number: {one.GetDecimalValue()}");
        } 
    }
}