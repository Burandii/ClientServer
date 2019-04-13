using System.Collections.Generic;
using SharedData.KWIC;

namespace ClientServer.KWIC
{
    public class KWICController
    {
        private readonly CircularShifter _circularShifter;
        private readonly Alphabetizer _alphabetizer;
        private readonly OutputManager _outputManager;
        private readonly InputManager _inputManager;

        private char[] _input;
        private char[] _urls;
        private List<CharIndex> _circularShiftIndices;
        private List<CharIndex> _alphabetizedIndices;
        private int[] _urlIndices;

        public KWICController()
        {
            _circularShifter = new CircularShifter();
            _alphabetizer = new Alphabetizer();
            _inputManager = new InputManager();
            _outputManager = new OutputManager();
        }

        public void SetInput(string input)
        {
            var inputs = _inputManager.GetFormattedWords(input);

            _input = inputs[0];
            _urls = inputs[1];
            _urlIndices = GetUrlIndices();

            _outputManager.SetInputs(_input, _urls, _urlIndices);

            GenerateResults();
        }

        private void GenerateResults()
        {
            _circularShiftIndices = _circularShifter.GetShiftedWordIndices(_input);
            _alphabetizedIndices = _alphabetizer.GetAlphabetizedIndices(_input, _circularShiftIndices);
        }

        public string GetAlphabetized()
        {
            return _outputManager.GetStringFromIndices(_alphabetizedIndices);
        }

        public List<string> GetAlphabetizedAsList()
        {
            return _outputManager.GetStringListFromIndices(_alphabetizedIndices);
        }

        public string GetCircularlyShifted()
        {
            return _outputManager.GetStringFromIndices(_circularShiftIndices);
        }

        public List<string> GetCircularlyShiftedAsList()
        {
            return _outputManager.GetStringListFromIndices(_circularShiftIndices);
        }

        private int[] GetUrlIndices()
        {
            var urlIndices = new List<int>();
            int startIndex = 0;
            for (int i = 0; i < _urls.Length; i++)
            {
                if (_urls[i] == '\n')
                {
                    urlIndices.Add(startIndex);
                    i++;
                    startIndex = i;
                }
            }
            
            urlIndices.Add(startIndex);

            return urlIndices.ToArray();
        }

    }
}
