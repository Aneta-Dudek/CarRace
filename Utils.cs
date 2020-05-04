using System;

namespace CarRace
{
    public static class Utils
    {
        public static int GetRandomNumberBetween(int minValue, int maxValue)
        {
            var rnd = new Random();
            return rnd.Next(minValue, ++maxValue); //by default is left close, right open 
        }

        public static bool CalculateProbability(int probabilityPercent)
        {
            var gen = new Random();
            var prob = gen.Next(100);
            return prob <= probabilityPercent;
        }
    }
}