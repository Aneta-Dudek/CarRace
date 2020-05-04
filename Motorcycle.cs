namespace CarRace
{
    public class Motorcycle : AbstractVehicle
    {
        public Motorcycle()
        {
            _id++;
        }

        private const int RegularSpeed = 100;
        private int _minSlowDownSpeed = 5;
        private int _maxSlowDownSpeed = 55;
        private static int _id = 1;
        protected override void SetVehicleName()
        {
            Name = $"{this.GetType().Name} {Motorcycle._id}";
        }

        protected override int SetNormalSpeed()

        {
            return RegularSpeed;
        }
        protected override void PrepareForLap(bool isSpeedModifier)
        {

            ActualSpeed = isSpeedModifier ? (NormalSpeed - Utils.GetRandomNumberBetween(_minSlowDownSpeed, _maxSlowDownSpeed)) : NormalSpeed;
        }
        public override void MoveForAnHour(params bool[] speedModifiers)
        {
            PrepareForLap(speedModifiers[(int)SpeedModifiers.IsRaining]);
            AddTraveledDistance();
        }
    }
}