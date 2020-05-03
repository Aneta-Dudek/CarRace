using System;
using System.Collections.Generic;

namespace CarRace
{
    public class Race
    {
        private List<Vehicle> _racersList = new List<Vehicle>();
        // Register a car, truck, or motorcycle into the race with a method called registerRacer
        public void RegisterRacer(Vehicle vehicle)
        {

        }

        // Simulates the passing of time by advancing the weather and moving the vehicles for the duration of a whole race. 
        public void SimulateRace()
        {
            var isRaining;
            for (int i = 0; i < 50; i++)
            {
                isRaining = IsRaining();
                foreach (var racerVehicle in _racersList)
                {
                    racerVehicle.MoveForAnHour();
                }

            }
        }

        private bool IsRaining()
        {
            var gen = new Random();
            var prob = gen.Next(100);
            return prob <= 30;
        }

        private bool IsYellowFlagActive()
        {
            return false;
        }


        // Prints the state of all vehicles. Called at the end of the race.

        public void PrintRaceResults()
        {
            foreach (var racerVehicle in _racersList)
            {
                Console.WriteLine($"Name: {racerVehicle.Name}\tDistance: {racerVehicle.Distance}\tType: {GetType(racerVehicle)}");
            }
        }
    }
}