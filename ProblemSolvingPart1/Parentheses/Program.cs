using System;
using System.Text;

namespace Parentheses
{
    class Program
    {
        private static StringBuilder result = new StringBuilder();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Brackets(n, 0, "");
            Console.WriteLine(result.ToString().Trim());
        }

        private static void Brackets(int openStock, int closeStock, String s)
        {

            if (openStock == 0 && closeStock == 0)
            {
                result.AppendLine(s);
            }
            if (openStock > 0)
            {
                Brackets(openStock - 1, closeStock + 1, s + "(");
            }
            if (closeStock > 0)
            {
                Brackets(openStock, closeStock - 1, s + ")");
            }
        }
    }
}
