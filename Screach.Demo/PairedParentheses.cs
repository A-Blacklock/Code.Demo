namespace Screach.Demo
{
    public class PairedParentheses : IPairedParentheses
    {
        public char Open { get; private set; }
        public char Close { get; private set; }

        public PairedParentheses(char open, char close)
        {
            Open = open;
            Close = close;
        }
    }
}