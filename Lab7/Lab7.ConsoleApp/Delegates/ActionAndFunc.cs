using System;

namespace Lab7.ConsoleApp.Delegates
{
    public class ActionAndFunc
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Diff(int x, int y)
        {
            return x - y;
        }

        public void DisplayAdd(int x, int y)
        {
            Console.WriteLine("--> Display from DisplayAdd method");
            Console.WriteLine($"{x + y}");
            Console.WriteLine();
        }

        public void DisplayDiff(int x, int y)
        {
            Console.WriteLine("--> Display from DisplayAdd method");
            Console.WriteLine($"{x - y}");
            Console.WriteLine();
        }
    }
}
