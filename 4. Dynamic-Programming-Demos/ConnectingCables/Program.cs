namespace ConnectingCables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] south =Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] north = new int[south.Length];
            for (int i = 1; i <= south.Length; i++)
            {
                north[i - 1] = i;
            }


            List<int> indeces = new List<int>();
            for (int i = 0; i < north.Length; i++)
            {
                for (int j = 0; j < south.Length; j++)
                {
                    if (north[i] == south[j])
                    {
                        indeces.Add(j);
                        break;
                    }
                }
            }

            int[] prev = new int[indeces.Count];
            int[] len = new int[indeces.Count];
            int maxLen = 0;
            int lastIndex = -1;
            for (int i = 0; i < indeces.Count; i++)
            {
                prev[i] = -1;
                len[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (indeces[j] < indeces[i] && len[i] < len[j] + 1)
                    {
                        len[i] = len[j] + 1;
                        prev[i] = j;
                    }
                }
                if (len[i] > maxLen)
                {
                    maxLen = len[i];
                    lastIndex = i;
                }
            }

            List<int> result = new List<int>();
            while (lastIndex != -1)
            {
                result.Add(indeces[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            result.Reverse();

            Console.WriteLine("Maximum pairs connected: {0}", result.Count);
            //Console.Write("Connected pairs: ");
            //for (int i = 0; i < result.Count; i++)
            //{
            //    Console.Write(south[result[i]] + " ");
            //}

            //Console.WriteLine();
        }
    }
}
