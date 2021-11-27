using Xunit;

namespace Algorithms.Tests
{
    public class Question2Tests
    {
        [Theory]
        [InlineData("aa6?9", false)]
        [InlineData("acc?7??sss?3rr1??????5", true)]
        [InlineData("xxx1???9???1xxx", true)]
        [InlineData("xxx1???9???1???9xxx", false)] // 9 question marks between first 1 and last 9.
        [InlineData("xxx1???9???1x2???8???2x3???7???3x4???6???4x5???5", true)]
        [InlineData("3???7", true)]
        [InlineData("3???73", false)]
        [InlineData("333???777", true)]
        public void QuestionMarksTest(string str, bool expected)
        {
            var result = Question2.QuestionsMarks(str);

            Assert.Equal(expected, result);
        }
    }
}