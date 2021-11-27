namespace Algorithms
{
    public class Question1
    {
        // Iterative
        public static long Factorial(int n)
        {
            var result = 1L;

            for (var i = n; i > 1; i--)
                result *= i;

            return result;
        }

        // Recursive
        public static long Factorial2(int n)
        {
            return n < 2 ? 1L : n * Factorial2(n - 1);
        }
    }
}