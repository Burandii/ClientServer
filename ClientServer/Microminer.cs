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
            return _datastore.GetContainingLines(input, "user_input.txt");
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
