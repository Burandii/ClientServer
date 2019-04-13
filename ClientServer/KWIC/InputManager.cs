using System.Collections.Generic;
using System.Text;

namespace ClientServer.KWIC
{
    public class InputManager
    {
        public List<char[]> GetFormattedWords(string input)
        {
            return SeparateHttp(input);
        }

        private List<char[]> SeparateHttp(string input)
        {
            var words = new List<char>();
            var urls = new List<char>();

            bool consecutiveSpaces = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (i + 5 < input.Length && (input[i] == ' ' || input[i] == '\t')
                                         && input[i+1] == 'h' && input[i+2] == 't' && input[i+3] == 't' && input[i+4] == 'p')
                {
                    i++;
                    // until a new line is found
                    while (i < input.Length && input[i] != '\n')
                    {
                        // windows character \r
                        urls.Add(input[i] == '\r' ? '\n' : input[i]);
                        i++;
                    }

                }
                else if (input[i] != ' ')
                {
                    consecutiveSpaces = false;
                }
                else if (input[i] == ' ') // a space
                {
                    if (consecutiveSpaces)
                        continue;
                    consecutiveSpaces = true;
                }
                else if (input[i] == '\t') // a tab
                {
                    continue;
                }


                if(i < input.Length)
                    words.Add(input[i]);
            }

            var arrays = new List<char[]>
            {
                words.ToArray(),
                urls.ToArray()
            };

            return arrays;
        }

    }
}
