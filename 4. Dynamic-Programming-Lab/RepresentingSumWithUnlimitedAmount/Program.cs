using System;
using System.Linq;

class SumWithUnlimitedCoins
{
    static void Main()
    {
        Console.Write("S = ");
        var totalSum = int.Parse(Console.ReadLine());

        Console.Write("Coins = ");
        var coins =
            Console.ReadLine()
                .Trim('{', '}');
        Console.WriteLine(coins);

        var combinationsCount = new int[totalSum + 1];

        // Calculate the number of possible combinations for the first coin (coins[0])
        for (int sum = 0; sum <= totalSum; sum++)
        {
            if (sum % coins[0] == 0)
            {
                combinationsCount[sum] = 1;
            }
        }

        // Calculate the number of possible combinations for every other coin
        for (int coin = 1; coin < coins.Length; coin++)
        {
            for (int sum = 1; sum <= totalSum; sum++)
            {
                if (coins[coin] <= sum)
                {
                    combinationsCount[sum] += combinationsCount[sum - coins[coin]];
                }
            }
        }

        Console.WriteLine(combinationsCount[totalSum]);
    }
}