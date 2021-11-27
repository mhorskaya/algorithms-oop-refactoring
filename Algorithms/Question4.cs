using System.Linq;

namespace Algorithms
{
    public class Question4
    {
        public static bool ConstructTree(string[] strArr)
        {
            // eliminate same pairs if exist.
            strArr = strArr.Distinct().ToArray();

            var sameNumberDifferentParentExists = strArr.Select(s => s.Split(",")[0])
                .GroupBy(x => x)
                .Select(x => x.Count())
                .Any(x => x > 1);

            if (sameNumberDifferentParentExists)
                return false;

            // return true if all parents are parent to at most two numbers, otherwise false.
            return strArr
                .Select(s => s.Split(",")[1])
                .GroupBy(x => x)
                .Select(x => x.Count())
                .All(x => x <= 2);
        }
    }
}