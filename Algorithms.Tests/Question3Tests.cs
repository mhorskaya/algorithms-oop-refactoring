using Xunit;

namespace Algorithms.Tests
{
    public class Question3Tests
    {
        [Theory]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        [InlineData(23, true)]
        [InlineData(24, false)]
        [InlineData(25, false)]
        public void IsPrimeNumberTest(int number, bool expected)
        {
            var result = Question3.IsPrimeNumber(number);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, "")]
        [InlineData(2, "2")]
        [InlineData(3, "2,3")]
        [InlineData(4, "2,3")]
        [InlineData(5, "2,3,5")]
        [InlineData(6, "2,3,5")]
        [InlineData(25, "2,3,5,7,11,13,17,19,23")]
        public void GetPrimeNumbersToTest(int number, string expected)
        {
            var result = Question3.GetPrimeNumbersTo(number);

            Assert.Equal(expected, result);
        }
    }
}