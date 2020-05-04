using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Console = Colorful.Console;

namespace CarRace
{
    public class Race
    {
        public Race()
        {

        }

        bool _isRaining;
        bool _isYellowFlagActive;
        private List<AbstractVehicle> _racersList = new List<AbstractVehicle>();
        private readonly string[] _displayColumns = { "Name", "Distance", "Type" };
        // Register a car, truck, or motorcycle into the race with a method called registerRacer
        public void RegisterRacer(AbstractVehicle vehicle)
        {
            _racersList.Add(vehicle);
        }

        // Simulates the passing of time by advancing the weather and moving the vehicles for the duration of a whole race. 
        public void SimulateRace()
        {
            const int loopsNumber = 50;
            for (int i = 0; i < loopsNumber; i++)
            {
                _isRaining = GetIsRaining();
                _isYellowFlagActive = GetIsYellowFlagActive(_racersList);

                foreach (var racerVehicle in _racersList)
                {
                    racerVehicle.MoveForAnHour(_isRaining, _isYellowFlagActive);
                }
            }
        }

        private bool GetIsRaining()
        {
            const int rainProbability = 30;
            return Utils.CalculateProbability(rainProbability);
        }

        private bool GetIsYellowFlagActive(List<AbstractVehicle> racerAbstractVehicles)
        {
            var isVehicleBrokenDown = false;
            foreach (var racerVehicle in racerAbstractVehicles)
            {
                if (racerVehicle is IBreakable breakableVehicle)
                {
                    if (breakableVehicle.IsBrokenDown == true)
                    {
                        isVehicleBrokenDown = true;
                    }
                }
            }

            return isVehicleBrokenDown;
        }


        // Prints the state of all vehicles. Called at the end of the race.

        public void PrintRaceResults()
        {
            _racersList = _racersList.OrderByDescending(v => v.DistanceTraveled).ToList();
            //_racersList = _racersList.OrderByDescending(v => v.GetType().Name).ToList();
            PrintTable();
        }

        private void PrintTable()
        {

            var table = CreateTable(_displayColumns);

            foreach (var racerVehicle in _racersList)
            {

                table.AddRow(racerVehicle.Name,
                            racerVehicle.DistanceTraveled,
                            racerVehicle.GetType().Name);
            }

            table.Write();
        }

        public ConsoleTable CreateTable(params string[] columns)
        {
            return new ConsoleTable(columns)
                .Configure(options => options.EnableCount = false);

        }

        //Playing with gradient colors

        private void PrintHorizontalGradient()
        {

            const int tableSize = 90;
            Console.WriteWithGradient(new string('-', tableSize), Color.Yellow, Color.Fuchsia, 14);
            Console.WriteLine();
            Console.WriteWithGradient(String.Format("| {0,-45} | {1,-15} | {2,20} |", _displayColumns[0], _displayColumns[1], _displayColumns[2]), Color.Yellow, Color.Fuchsia, 14);
            Console.WriteLine();
            Console.WriteWithGradient(new string('-', tableSize), Color.Yellow, Color.Fuchsia, 14);
            Console.WriteLine();

            for (var i = 0; i < _racersList.Count; i++)
            {
                var racerVehicle = _racersList[i];
                Console.WriteWithGradient($"| {racerVehicle.Name,-45} | {racerVehicle.DistanceTraveled,-15} | {racerVehicle.GetType().Name,20} |", Color.Yellow, Color.Fuchsia, 14);
                Console.WriteLine();
            }

            Console.WriteWithGradient(new string('-', tableSize), Color.Yellow, Color.Fuchsia, 14);
        }

        private void PrintVerticalGradient()
        {
            int r = 225;
            int g = 255;
            int b = 250;

            const int tableSize = 90;
            Console.WriteLine(new string('-', tableSize), Color.FromArgb(r, g, b));
            Console.WriteLine($"| {_displayColumns[0],-45} | {_displayColumns[1],-15} | {_displayColumns[2],20} |", Color.FromArgb(r, g, b));
            Console.WriteLine(new string('-', tableSize), Color.FromArgb(r, g, b));
            r -= 200 / 14;
            b -= 100 / 14;

            for (var i = 0; i < _racersList.Count; i++)
            {
                var racerVehicle = _racersList[i];
                Console.WriteLine($"| {racerVehicle.Name,-45} | {racerVehicle.DistanceTraveled,-15} | {racerVehicle.GetType().Name,20} |", Color.FromArgb(r, g, b));
                Console.WriteLine(new string('-', tableSize), Color.FromArgb(r, g, b));
                if (i % _racersList.Count / 13 == 0)
                {
                    r -= 200 / 13;
                    b -= 100 / 13;
                }
            }
        }
    }
}