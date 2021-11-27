using Xunit;

namespace Algorithms.Tests
{
    public class Question1Tests
    {
        [Theory]
        [InlineData(0, 1L)]
        [InlineData(1, 1L)]
        [InlineData(2, 2L)]
        [InlineData(3, 6L)]
        [InlineData(4, 24L)]
        [InlineData(8, 40320L)]
        [InlineData(18, 6402373705728000L)]
        public void FactorialTest(int number, long expected)
        {
            var result = Question1.Factorial(number);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 1L)]
        [InlineData(1, 1L)]
        [InlineData(2, 2L)]
        [InlineData(3, 6L)]
        [InlineData(4, 24L)]
        [InlineData(8, 40320L)]
        [InlineData(18, 6402373705728000L)]
        public void Factorial2Test(int number, long expected)
        {
            var result = Question1.Factorial2(number);

            Assert.Equal(expected, result);
        }
    }
}