using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace CarRace
{
    public abstract class Vehicle
    {
        List<string> namesList = new List<string>(GetNames());
        public Vehicle(string name)
        {
            Name = name;
            Distance = 0;
        }

        public string Name { get; private set; }
        public int Distance { get; private set; }


        public void MoveForAnHour()
        {
            throw new NotImplementedException();
        }

        private var namesDAO = new NamesDao();

    }

    public class NamesDao
    {
        public static string[] GetNames()
        {
            return System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");
        }
    }
}

