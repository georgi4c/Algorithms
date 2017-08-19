using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towns
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var sequence = new int[n];
            for (int i = 0; i < sequence.Length; i++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                sequence[i] = int.Parse(input[0]);
            }

            int[] len = new int[sequence.Length];
            int[] lenDec = new int[sequence.Length];
            
            int maxLen = 0;
            int lastIndex = -1;

            for (int x = 0; x < sequence.Length; x++)
            {
                len[x] = 1;
                for (int i = 0; i < x; i++)
                {
                    if (sequence[x] > sequence[i] && len[x] <= len[i])
                    {
                        len[x]++;
                    }
                }
                if (len[x] > maxLen)
                {
                    maxLen = len[x];
                }
            }

            int maxLenDec = 0;
            int lastIndexDec = -1;

            for (int x = sequence.Length - 1; x >= 0 ; x--)
            {
                lenDec[x] = 1;
                for (int i = sequence.Length - 1; i > x ; i--)
                {
                    if (sequence[x] > sequence[i] && lenDec[x] <= lenDec[i])
                    {
                        lenDec[x]++;
                    }
                }
                if (lenDec[x] > maxLenDec)
                {
                    maxLenDec = lenDec[x];
                }
            }

            var maxPath = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                var currentLength = len[i] + lenDec[i];
                if (currentLength > maxPath)
                {
                    maxPath = currentLength;
                }
            }
            Console.WriteLine(maxPath - 1);
        }
    }
}
