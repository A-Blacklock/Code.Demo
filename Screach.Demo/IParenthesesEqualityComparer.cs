using System.Collections.Generic;

namespace Screach.Demo
{
    public interface IParenthesesEqualityComparer : IEqualityComparer<char>
    {
        IEnumerable<IPairedParentheses> Parentheses { get; }
    }
}