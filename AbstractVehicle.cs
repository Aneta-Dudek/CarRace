namespace CarRace
{
    public abstract class AbstractVehicle
    {

        public AbstractVehicle()
        {
            SetVehicleName();
            NormalSpeed = SetNormalSpeed();
            DistanceTraveled = 0;
        }

        public string Name { get; protected set; }
        public int DistanceTraveled { get; protected set; }
        public int NormalSpeed { get; protected set; }
        public int ActualSpeed { get; protected set; }

        protected abstract void SetVehicleName();
        protected abstract int SetNormalSpeed();
        protected abstract void PrepareForLap(bool isSpeedModifier);

        public abstract void MoveForAnHour(params bool[] speedModifiers);

        protected void AddTraveledDistance()
        {
            DistanceTraveled += ActualSpeed;
        }

    }
}