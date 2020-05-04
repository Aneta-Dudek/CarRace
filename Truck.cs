using System.Collections.Generic;

namespace CarRace
{
    public class Truck : AbstractVehicle, IBreakable
    {
        public Truck()
        {
            IsBrokenDown = false;
            _breakDownTimer = 0;
        }

        private static List<string> TruckNamesList = new List<string>();
        private const int RegularSpeed = 100;
        private const int BrokenDownSpeed = 0;
        private const int MinNameNumber = 0;
        private const int MaxNameNumber = 1000;

        public bool IsBrokenDown { get; set; }
        private int _breakDownTimer;
        protected override void SetVehicleName()
        {
            var generatedName = "";
            do
            {
                generatedName = Utils.GetRandomNumberBetween(MinNameNumber, MaxNameNumber).ToString();
            } while (TruckNamesList.Contains(generatedName));

            Name = generatedName;
            TruckNamesList.Add(Name);
        }

        protected override int SetNormalSpeed()
        {
            return RegularSpeed;
        }
        protected override void PrepareForLap(bool isSpeedModifier)
        {

            ActualSpeed = isSpeedModifier ? BrokenDownSpeed : RegularSpeed;
        }

        public bool CheckIfBreaksDown()
        {
            const int breakDownProbability = 5;

            if (IsBrokenDown == true)
                OngoingRepair();

            if (IsBrokenDown == false)
                IsBrokenDown = Utils.CalculateProbability(breakDownProbability);

            return IsBrokenDown;

        }

        public void OngoingRepair()
        {
            const int breakDownTimeOut = 2;
            if (_breakDownTimer < breakDownTimeOut)
            {
                _breakDownTimer++;
            }
            if (_breakDownTimer == breakDownTimeOut)
            {
                IsBrokenDown = false;
                _breakDownTimer = 0;
            }
        }

        public override void MoveForAnHour(params bool[] speedModifiers)
        {
            PrepareForLap(CheckIfBreaksDown());
            AddTraveledDistance();
        }


    }

}