using System;
using System.Collections.Generic;
using System.Linq;

namespace Screach.Demo
{
    public class BalancedParenthesesEvaluator : IBalancedParenthesesEvaluator
    {
        private IEnumerable<IPairedParentheses> Parentheses => _parenthesesEqualityComparer.Parentheses;
        private readonly IParenthesesEqualityComparer _parenthesesEqualityComparer;

        public BalancedParenthesesEvaluator(IParenthesesEqualityComparer parenthesesEqualityComparer)
        {
            _parenthesesEqualityComparer = parenthesesEqualityComparer;
        }

        public bool Evaluate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            var split = input.ToCharArray();

            if (!split.Any())
            {
                throw new BalancedParenthesesEvaluatorException("Nothing to evaluate");
            }

            var parentheses = new List<char>();


            parentheses.AddRange(split.Where(c => Enumerable.Select(Parentheses, p1 => p1.Open).Contains<char>(c) ||
                                                  Enumerable.Select(Parentheses, p2 => p2.Close).Contains<char>(c)));

            if (!parentheses.Any())
            {
                return true;
            }

            var open = parentheses.Where((x, i) => (i + 1) % 2 == 0).ToArray();
            var closed = parentheses.Where((x, i) => (i + 1) % 2 != 0).ToArray();

            var result = open.Length == closed.Length && (open.SequenceEqual(closed, _parenthesesEqualityComparer));

            return result;
        }
    }
}