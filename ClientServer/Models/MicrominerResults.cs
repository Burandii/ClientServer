using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientServer.Models
{
    public class MicrominerResults
    {
        public List<string> SearchResult { get; set; }
        public string Alphabetized { get; set; }
        public string CircularlyShifted { get; set; }
        public string UserInput { get; set; }
    }
}
