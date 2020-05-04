namespace CarRace
{
    public interface IBreakable
    {
        bool IsBrokenDown { get; set; }
        bool CheckIfBreaksDown();
        void OngoingRepair();

    }
}