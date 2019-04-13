namespace ClientServer.KWIC
{
    public class CharIndex
    {
        private readonly int _first;
        private readonly int _offset;
        private readonly int _lineNumber;

        public CharIndex(int first, int offset, int lineNumber)
        {
            _first = first;
            _offset = offset;
            _lineNumber = lineNumber;
        }

        public int GetFirst()
        {
            return _first;
        }

        public int GetOffset()
        {
            return _offset;
        }

        public int GetLineNumber()
        {
            return _lineNumber;
        }
    }
}
