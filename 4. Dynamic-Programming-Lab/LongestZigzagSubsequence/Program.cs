using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestZigzagSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //var sequence = new int[] { 10, 22, 9, 33, 49, 50, 31, 60 };
            var longestSeq = FindLongestZigZagSubsequence(sequence);
            //Console.WriteLine(longestSeq);
            Console.WriteLine(string.Join(" ", longestSeq));
        }
        static int max(int a, int b) { return (a > b) ? a : b; }

        private static List<int> FindLongestZigZagSubsequence(int[] sequence)
        {
            int[,] len = new int[sequence.Length, 2];
            int[,] prev = new int[sequence.Length, 2];

            int maxLen = 1;
            int[] lastIndex = new int[2];
            lastIndex[0] = -1;
            for (int x = 0; x < sequence.Length; x++)
            {
                len[x, 0] = len[x, 1] = 1;
                prev[x, 0] = prev[x, 1] = -1;
            }

            for (int x = 1; x < sequence.Length; x++)
            {
                

                for (int i = 0; i < x; i++)
                {

                    if (sequence[i] < sequence[x] && len[x, 0] < len[i, 1] + 1)
                    {
                        len[x, 0] = len[i, 1] + 1;
                        prev[x, 0] = i;
                    }

                    if (sequence[i] > sequence[x] && len[x, 1] < len[i, 0] + 1)
                    {
                        len[x, 1] = len[i, 0] + 1;
                        prev[x, 1] = i;
                    }

                }
                if (maxLen < max(len[x, 0], len[x, 1]))
                {
                    maxLen = max(len[x, 0], len[x, 1]);
                    if (len[x, 0] >= len[x, 1])
                    {
                        lastIndex[0] = x;
                        lastIndex[1] = 0;
                    }
                    else
                    {
                        lastIndex[0] = x;
                        lastIndex[1] = 1;
                    }
                }
            }

            var result = new List<int>();

            while (lastIndex[0] == -1)
            {
                if (lastIndex[1] == 0)
                {
                    result.Add(sequence[lastIndex[0]]);
                    lastIndex[0] = prev[lastIndex[0], 0];
                    lastIndex[1] = 1;
                }
                else
                {
                    result.Add(sequence[lastIndex[0]]);
                    lastIndex[0] = prev[lastIndex[0], 1];
                    lastIndex[1] = 0;
                }
            }

            return result;
        }
    }
}
