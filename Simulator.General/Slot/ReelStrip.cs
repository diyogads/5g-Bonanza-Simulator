namespace Simulator.General.Slot
{
    public class ReelStrip
    {
        public int[] Strip { get; set; } = Array.Empty<int>();

        public ReelStrip(int[] strip)
        {
            Strip = strip;
        }
    }
}
