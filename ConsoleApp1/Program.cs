using System;
using DataStructures;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            list.Remove(2);
            Print(list);
        }

        static void Print(ArrayList list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list.Get(i) + "\t");
            }
            Console.WriteLine();
        }
    }
}
