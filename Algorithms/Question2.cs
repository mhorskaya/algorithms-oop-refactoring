using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class Question2
    {
        public static bool QuestionsMarks(string str)
        {
            var digitIndices = new Dictionary<int, List<int>>();

            // initialize digit indices with empty lists.
            for (var i = 0; i < 10; i++)
                digitIndices[i] = new List<int>();

            // add every index for every digit.
            for (var i = 0; i < str.Length; i++)
                if ('0' <= str[i] && str[i] <= '9')
                    digitIndices[str[i] - '0'].Add(i);

            var pairs = new HashSet<(int, int)>();

            // find every digit pair with sum 10 and add every index pair to list.
            foreach (var (digit, indices) in digitIndices)
                foreach (var index1 in indices)
                    foreach (var index2 in digitIndices[10 - digit].Where(index => index != index1))
                        pairs.Add(index1 < index2 ? (index1, index2) : (index2, index1));

            // if there is no pair with sum 10, return false.
            if (pairs.Count == 0)
                return false;

            // if there is any pair that doesn't contain exactly three question marks, return false
            foreach (var (index1, index2) in pairs)
                if (Enumerable.Range(index1, index2 - index1 + 1).Select(i => str[i]).Count(c => c == '?') != 3)
                    return false;

            return true;
        }
    }
}