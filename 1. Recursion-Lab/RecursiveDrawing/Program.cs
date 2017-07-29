using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Draw(n);
        }

        private static void Draw(int count)
        {
            if (count < 1)
            {
                return;
            }
            Console.WriteLine(new string('*', count));
            Draw(count - 1);
            Console.WriteLine(new string('#', count));
        }
    }
}
