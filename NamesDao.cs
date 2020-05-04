using System.Collections.Generic;
using System.IO;
using static System.String;

namespace CarRace
{
    public class NamesDao : INamesDao
    {
        public NamesDao(string sourcePath)
        {
            _path = IsNullOrWhiteSpace(_path) ? DefaultPath : sourcePath;
        }

        private readonly string _path;
        private static readonly string DefaultPath = Directory.GetCurrentDirectory() + @"\CarNames.txt";

        public List<string> GetCarNames()
        {
            var txtFileContent = LoadFromFile();
            var carNames = new List<string>();

            foreach (var txtLine in txtFileContent)
            {
                carNames.Add(txtLine);
            }

            return carNames;
        }

        private string[] LoadFromFile()
        {
            return File.ReadAllLines(_path);
        }
    }
}