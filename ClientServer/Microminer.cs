using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientServer.KWIC;

namespace ClientServer
{
    public class Microminer
    {
        private readonly DatastoreService _datastore;
        private readonly KWICController _kwicController;

        public Microminer()
        {
            _datastore = new DatastoreService();
            _kwicController = new KWICController();
        }

        public void SetInput(string input)
        {
            _datastore.SaveDataToFile(input, "user_input.txt");
            _kwicController.SetInput(input);

            _datastore.SaveDataToFile(_kwicController.GetCircularlyShifted(), "circularly_shifted.txt");
            _datastore.SaveDataToFile(_kwicController.GetAlphabetized(), "alphabetized.txt");
        }

        public List<string> GetMatches(string input)
        {
            var results = new List<string>();

            var lines = GetOriginalInput().Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );
            string[] words = input.Split(' ');

            for (int i = 0; i < lines.Length; i++)
            {
                bool containsAllWords = false;
                for (int k = 0; k < words.Length; k++)
                {
                    if (!lines[i].ToUpper().Contains(words[k].ToUpper()))
                    {
                        containsAllWords = false;
                        break;
                    }
                    else
                    {
                        containsAllWords = true;
                    }
                    if (k == words.Length - 1 && containsAllWords)
                        results.Add(lines[i]);
                }
            }

            return results;
        }

        public string GetAlphabetized()
        {
            return _datastore.GetAllData("alphabetized.txt");
        }
        public string GetCircularlyShifted()
        {
            return _datastore.GetAllData("circularly_shifted.txt");
        }

        public string GetOriginalInput()
        {
            return _datastore.GetAllData("user_input.txt");
        }
    }
}
