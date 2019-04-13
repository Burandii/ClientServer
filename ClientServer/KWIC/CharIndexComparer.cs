using System.Collections.Generic;

namespace ClientServer.KWIC
{
    public class CharIndexComparer : IComparer<CharIndex>
    {
        private readonly char[] _input;

        public CharIndexComparer(char[] input)
        {
            _input = input;
        }

        public int Compare(CharIndex a, CharIndex b)
        {
            var indexA = a.GetFirst() + a.GetOffset();
            var indexB = b.GetFirst() + b.GetOffset();

            var firstIteration = true;

            var indexAStart = indexA;
            var indexBStart = indexB;

            while (true)
            {
                while (_input[indexA] == '\r' || _input[indexA] == '\n' || _input[indexA] == ' ')
                {
                    indexA = GoNextIndex(indexA, a);
                }
                while (_input[indexB] == '\r' || _input[indexB] == '\n' || _input[indexB] == ' ')
                {
                    indexB = GoNextIndex(indexB, b);
                }

                if (!firstIteration && indexA == indexAStart && indexB == indexBStart)
                {
                    return 0;
                }

                if (_input[indexA] == _input[indexB])
                {
                    indexA = GoNextIndex(indexA, a);
                    indexB = GoNextIndex(indexB, b);
                }
                else
                {
                    int comparisonInteger = char.ToUpperInvariant(_input[indexA]).CompareTo(char.ToUpperInvariant(_input[indexB]));

                    // same character
                    if (char.ToUpperInvariant(_input[indexA]) == char.ToUpperInvariant(_input[indexB]))
                    {
                        comparisonInteger = _input[indexA].CompareTo(_input[indexB]);
                        return comparisonInteger * -1;
                    }

                    return comparisonInteger;
                }

                firstIteration = false;
            }
        }
        private int GoNextIndex(int currentIndex, CharIndex index)
        {
            var nextIndex = currentIndex + 1;

            // if at the end of the line, go to the front
            if (nextIndex >= _input.Length || _input[nextIndex] == '\r' || _input[nextIndex] == '\n')
            {
                return index.GetFirst();
            }
            return nextIndex;
        }
    }
}
