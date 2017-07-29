using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestIncreasingSubsequence2
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] len = new int[sequence.Length];
            int[] prev = new int[sequence.Length];
            int maxLen = 0;
            int lastIndex = 0;
            for (int x = 0; x < sequence.Length; x++)
            {
                len[x] = 1;
                prev[x] = -1;
                for (int i = 0; i < x; i++)
                {
                    if (sequence[i] < sequence[x] && len[i] >= len[x])
                    {
                        len[x]++;
                        prev[x] = i;
                        if (len[x] > maxLen)
                        {
                            maxLen = len[x];
                            lastIndex = x;
                        }
                    }
                }

            }
            var longestSeq = new List<int>();
            while (lastIndex != -1)
            {
                longestSeq.Add(sequence[lastIndex]);
                lastIndex = prev[lastIndex];
            }
            longestSeq.Reverse();
            Console.WriteLine(string.Join(" ", longestSeq));

        }
    }
}
