using System;

class BinomialCoefficientsFast
{
    const int MAX = 100;
    static decimal[,] binomCoeff = new decimal[MAX, MAX];

    static decimal Binom(int n, int k)
    {
        if (k > n)
            return 0;
        if (0 == k || k == n)
            return 1;
        if (binomCoeff[n, k] == 0)
            binomCoeff[n, k] = Binom(n - 1, k - 1) + Binom(n - 1, k);
        return binomCoeff[n, k];
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        Console.WriteLine(Binom(n, k));
    }
}
