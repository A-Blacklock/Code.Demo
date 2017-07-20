using System;
using System.Collections.Generic;
using System.Linq;

namespace Screach.Demo
{
    public class ParenthesesEqualityComparer : IParenthesesEqualityComparer
    {
        public IEnumerable<IPairedParentheses> Parentheses { get; private set; }

        public ParenthesesEqualityComparer(IEnumerable<IPairedParentheses> parentheses)
        {
            Parentheses = parentheses;
        }

        public bool Equals(char x, char y)
        {
            var result = (Enumerable.Any(Parentheses, p => p.Open == x && p.Close == y) ||
                          Enumerable.Any(Parentheses, p => p.Close == x && p.Open == y));

            return result;
        }

        public int GetHashCode(char obj)
        {
            throw new NotImplementedException();
        }
    }
}