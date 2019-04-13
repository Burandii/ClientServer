using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientServer.KWIC;

namespace SharedData.KWIC
{
    public class OutputManager
    {
        private char[] _input;
        private char[] _urls;
        private int[] _urlIndices;

        public void SetInputs(char[] input, char[] urls, int[] urlIndices)
        {
            _input = input;
            _urls = urls;
            _urlIndices = urlIndices;
        }

        public List<string> GetStringListFromIndices(List<CharIndex> indices)
        {
            var result = new List<string>();
            foreach (var index in indices)
            {
                result.Add(GenerateStringLineWithUrl(index));
            }

            return result;
        }

        public string GetStringFromIndices(List<CharIndex> indices)
        {
            var stringBuilder = new StringBuilder();
            foreach (var index in indices)
            {
                stringBuilder.Append(GenerateStringLineWithUrl(index));
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        private string GenerateStringLineWithUrl(CharIndex index)
        {
            var stringBuilder = new StringBuilder();

            var first = index.GetFirst();
            var offset = index.GetOffset();
            var i = first + offset;
            var k = first;

            while (i != _input.Length && _input[i] != '\r' && _input[i] != '\n')
            {
                stringBuilder.Append(_input[i]);
                i++;
            }

            if (offset != 0)
            {
                stringBuilder.Append(' ');
            }

            while (k < first + offset - 1)
            {
                stringBuilder.Append(_input[k]);
                k++;
            }

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(' ');

            var matchingUrlIndex = _urlIndices[index.GetLineNumber()];

            for (int j = matchingUrlIndex; j < _urls.Length; j++)
            {

                if (_urls[j] == '\n')
                {
                    break;
                }

                urlBuilder.Append(_urls[j]);
            }

            stringBuilder.Append(urlBuilder);

            return stringBuilder.ToString();
        }

        private string GenerateStringLine(CharIndex index)
        {
            var stringBuilder = new StringBuilder();

            var first = index.GetFirst();
            var offset = index.GetOffset();
            var i = first + offset;
            var k = first;

            while (i != _input.Length && _input[i] != '\r' && _input[i] != '\n')
            {
                stringBuilder.Append(_input[i]);
                i++;
            }

            if (offset != 0)
            {
                stringBuilder.Append(' ');
            }

            while (k < first + offset - 1)
            {
                stringBuilder.Append(_input[k]);
                k++;
            }

            return stringBuilder.ToString();
        }
    }

}
