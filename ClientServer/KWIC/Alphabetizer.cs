using System.Collections.Generic;
using System.Linq;

namespace ClientServer.KWIC
{
    public class Alphabetizer : IAlphabetizer
    {
        public List<CharIndex> GetAlphabetizedIndices(char[] input, List<CharIndex> circularlyShifted)
        {
            var comparer = new CharIndexComparer(input);
            var alphabetizedIndices = circularlyShifted.OrderBy(x => x, comparer).ToList();

            return alphabetizedIndices;
        }
    }
}
