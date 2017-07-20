using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Screach.Demo.Tests
{
    public class ParenthesesEqualityComparerTests
    {
        [Theory]
        [InlineData('{', '}')]
        [InlineData('[', ']')]
        [InlineData('(', ')')]
        public void Prarenthesese_Match_And_Supported_Test(char x, char y)
        {
            var parentheses = new List<IPairedParentheses>()
            {
                new PairedParentheses('{', '}'),
                new PairedParentheses('[', ']'),
                new PairedParentheses('(', ')')
            };

            var parenthesesEqualityComparer = new ParenthesesEqualityComparer(parentheses);

            var result = parenthesesEqualityComparer.Equals(x, y);

            Assert.Equal(result, true);
        }

        [Theory]
        [InlineData('{', ']')]
        [InlineData('(', '[')]
        [InlineData('(', '(')]
        public void Prarenthesese_Miss_Match_And_Supported_Test(char x, char y)
        {
            var parentheses = new List<IPairedParentheses>()
            {
                new PairedParentheses('{', '}'),
                new PairedParentheses('[', ']'),
                new PairedParentheses('(', ')')
            };

            var parenthesesEqualityComparer = new ParenthesesEqualityComparer(parentheses);

            var result = parenthesesEqualityComparer.Equals(x, y);

            Assert.Equal(result, false);
        }

        [Theory]
        [InlineData('<', '>')]
        [InlineData('[', ']')]
        [InlineData('(', ')')]
        public void Prarenthesese_Match_And_Not_Supported_Test(char x, char y)
        {
            var parentheses = new List<IPairedParentheses>()
            {
                new PairedParentheses('{', '}'),
            };

            var parenthesesEqualityComparer = new ParenthesesEqualityComparer(parentheses);

            var result = parenthesesEqualityComparer.Equals(x, y);

            Assert.Equal(result, false);
        }
    }
}
