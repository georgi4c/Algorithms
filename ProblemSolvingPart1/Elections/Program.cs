using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections
{
    class Program
    {
        static int k;
        static Dictionary<int, int> votes = new Dictionary<int, int>();
        static int[] parties;
        private static int controlBorder;
        private static int numberOfParties;
        //static List<string> result = new List<string>();
        private static int result;
        
        static int[] slots;

        static void Main(string[] args)
        {
            controlBorder = int.Parse(Console.ReadLine());
            numberOfParties = int.Parse(Console.ReadLine());
            parties= new int[numberOfParties];
            for (int i = 0; i < numberOfParties; i++)
            {
                parties[i] = i;
                votes[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 1; i <= numberOfParties; i++)
            {
                slots = new int[i];
                k = i;
                GenerateCombinationsNoRepetitions(0, 0);
            }

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine(result);
        }

        //static void Start()
        //{
        //    parties = Console.ReadLine().Split(' ').ToArray();
        //    k = int.Parse(Console.ReadLine());
        //    slots = new string[k];

        //    GenerateCombinationsNoRepetitions(0, 0);
        //}

        static void GenerateCombinationsNoRepetitions(int index, int start)
        {
            if (index >= k)
            {
                if (slots.Select(s => votes[s]).Sum() >= controlBorder)
                {
                    //result.Add(string.Join(" ", slots));
                    result++;
                }
            }
            else
            {
                for (int i = start; i < parties.Length; i++)
                {
                    slots[index] = parties[i];
                    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                }
            }
        }
        
    }
   
}
