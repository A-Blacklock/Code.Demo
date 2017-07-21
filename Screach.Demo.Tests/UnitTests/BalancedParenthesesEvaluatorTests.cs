using System.Collections.Generic;
using Moq;
using Xunit;

namespace Screach.Demo.Tests.UnitTests
{
    public class BalancedParenthesesEvaluatorTests
    {
        [Theory]
        [InlineData("{}[](Test)")]
        [InlineData("[](){}")]
        public void Evaluate_Balanced(string input)
        {
            var parentheses = new List<IPairedParentheses>()
            {
                new PairedParentheses('{', '}'),
                new PairedParentheses('[', ']'),
                new PairedParentheses('(', ')')
            };

            var moqEqualityComparer = new Mock<IParenthesesEqualityComparer>();

            moqEqualityComparer.Setup(p => p.Equals(It.IsAny<char>(), It.IsAny<char>())).Returns(true).Verifiable();
            moqEqualityComparer.Setup(p => p.Parentheses).Returns(parentheses).Verifiable();

            var evaluator = new BalancedParenthesesEvaluator(moqEqualityComparer.Object);

            var result = evaluator.Evaluate(input);

            Assert.Equal(result, true);

            moqEqualityComparer.Verify();
        }

        [Theory]
        [InlineData("{][](Test)")]
        [InlineData("[])){}")]
        public void Evaluate_Not_Balanced(string input)
        {
            var parentheses = new List<IPairedParentheses>()
            {
                new PairedParentheses('{', '}'),
                new PairedParentheses('[', ']'),
                new PairedParentheses('(', ')')
            };

            var moqEqualityComparer = new Mock<IParenthesesEqualityComparer>();

            moqEqualityComparer.Setup(p => p.Equals(It.IsAny<char>(), It.IsAny<char>())).Returns(false).Verifiable();
            moqEqualityComparer.Setup(p => p.Parentheses).Returns(parentheses).Verifiable();

            var evaluator = new BalancedParenthesesEvaluator(moqEqualityComparer.Object);

            var result = evaluator.Evaluate(input);

            Assert.Equal(result, false);

            moqEqualityComparer.Verify();
        }
    }
}