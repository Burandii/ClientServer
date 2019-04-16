using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServer
{
    public class DatastoreService
    {
        private const string Path = @".\Resources\";

        public DatastoreService()
        {
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
        }
        public void SaveDataToFile(string input, string fileName)
        {
            string path = Path + fileName;
            File.WriteAllText(path, input);
        }

        public string GetAllData(string fileName)
        {
            return File.ReadAllText(Path + fileName);
        }

        public List<string> GetContainingLines(string input, string fileName)
        {
            var results = new List<string>();
            string line;
            StreamReader file = new StreamReader(Path + fileName);
            while ((line = file.ReadLine()) != null)
            {
                if (line.ToUpper().Contains(input.ToUpper()))
                {
                    results.Add(line);
                }
            }

            file.Close();
            return results;
        }

    }
}
