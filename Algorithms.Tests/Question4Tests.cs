using Xunit;

namespace Algorithms.Tests
{
    public class Question4Tests
    {
        [Theory]
        [InlineData(new[] { "(1,2)", "(2,4)", "(7,2)" }, true)]
        [InlineData(new[] { "(1,2)", "(2,4)", "(5,7)", "(7,2)", "(9,5)" }, true)]
        [InlineData(new[] { "(1,2)", "(3,2)", "(2,12)", "(5,2)" }, false)]
        [InlineData(new[] { "(1,2)", "(1,3)" }, false)]
        [InlineData(new[] { "(1,2)", "(1,2)" }, true)] // same pair given more than once is considered once, so this is a valid binary tree.
        public void IsPrimeNumberTest(string[] strArr, bool expected)
        {
            var result = Question4.ConstructTree(strArr);

            Assert.Equal(expected, result);
        }
    }
}