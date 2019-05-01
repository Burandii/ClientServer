using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientServer.KWIC
{
    public interface ICircularShifter
    {
        List<CharIndex> GetShiftedWordIndices(char[] input);
    }
}
