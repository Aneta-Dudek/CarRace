namespace CarRace
{
    public class Car : AbstractVehicle
    {
        public Car()
        {
        }

        private const int YellowFlagSpeed = 75;
        private int _minNormalSpeed = 80;
        private int _maxNormalSpeed = 110;

        protected override void SetVehicleName()
        {
            var namesDao = new NamesDao("");
            var namesList = namesDao.GetCarNames();
            int maxListIndex = namesList.Count - 1;
            const int minListIndex = 0;

            Name = $"{namesList[Utils.GetRandomNumberBetween(minListIndex, maxListIndex)]} {namesList[Utils.GetRandomNumberBetween(minListIndex, maxListIndex)]}";
        }

        protected override int SetNormalSpeed()
        {
            return Utils.GetRandomNumberBetween(_minNormalSpeed, _maxNormalSpeed);
        }
        protected override void PrepareForLap(bool isSpeedModifier)
        {
            ActualSpeed = isSpeedModifier ? YellowFlagSpeed : NormalSpeed;
        }
        public override void MoveForAnHour(params bool[] speedModifiers)
        {
            PrepareForLap(speedModifiers[(int)SpeedModifiers.IsYellowFlagActive]);
            AddTraveledDistance();
        }

    }
}