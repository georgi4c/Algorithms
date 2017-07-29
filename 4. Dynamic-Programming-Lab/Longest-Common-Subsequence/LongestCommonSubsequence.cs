namespace Longest_Common_Subsequence
{
    using System;

    public class LongestCommonSubsequence
    {
        public static void Main()
        {

            var firstStr = "tree";
            var secondStr = "team";

            var lcs = FindLongestCommonSubsequence(firstStr, secondStr);

            Console.WriteLine("Longest common subsequence:");
            Console.WriteLine("  first  = {0}", firstStr);
            Console.WriteLine("  second = {0}", secondStr);
            Console.WriteLine("  lcs    = {0}", lcs);

        }

        public static string FindLongestCommonSubsequence(string firstStr, string secondStr)
        {
            int firstLen = firstStr.Length + 1;
            int secondLen = secondStr.Length + 1;
            var lcs = new int[firstLen, secondLen];
            for (int i = 1; i < firstLen; i++)
            {
                for (int j = 1; j < secondLen; j++)
                {
                    if (firstStr[i - 1] == secondStr[j - 1])
                    {
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                    }
                }
            }

            char[] result = new char[lcs[firstLen - 1, secondLen - 1]];
            int index = result.Length - 1;
            int r = firstLen - 1;
            int c = secondLen - 1;
            while (r > 0 && c > 0)
            {
                if (firstStr[r - 1] == secondStr[c - 1])
                {
                    result[index--] = firstStr[r - 1];
                    r--;
                    c--;
                }
                else if (lcs[r, c] == lcs[r - 1, c])
                {
                    r--;
                }
                else
                {
                    c--;
                }
            }

            return new string(result);

        }

        
    }
}
