namespace CarRace
{
    class Program
    {

        /**
         * Entry point of our program. Creates one race instance and uses that.
         *
         * @param args commandline arguments passed to the program.
         *             It is unused.
         */

        static void Main(string[] args)
        {
            Race race = new Race();
            CreateVehicles(race);

            race.SimulateRace();
            race.PrintRaceResults();
        }

        // Creates all the vehicles that will be part of this race.

        private static void CreateVehicles(Race race)
        {
            const int numberOfVehicles = 10;
            for (int i = 0; i < numberOfVehicles; i++)
            {
                race.RegisterRacer(new Car());
                race.RegisterRacer(new Motorcycle());
                race.RegisterRacer(new Truck());
            }

        }
    }
}
