using System;
using System.Linq;

namespace Algorithms
{
    public class Question3
    {
        public static bool IsPrimeNumber(int number)
        {
            if (number == 1)
                return false;

            for (var i = 2; i <= (int)Math.Sqrt(number); i++)
                if (number % i == 0)
                    return false;

            return true;
        }

        public static string GetPrimeNumbersTo(int number)
        {
            return string.Join(",", Enumerable.Range(1, number).Where(IsPrimeNumber));
        }
    }
}