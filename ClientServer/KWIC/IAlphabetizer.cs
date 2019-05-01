using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientServer.KWIC
{
    public interface IAlphabetizer
    {
        List<CharIndex> GetAlphabetizedIndices(char[] input, List<CharIndex> circularlyShifted);
    }
}
