namespace Simulator.General.Slot
{
    public class GridSet
    {
        public string Name { get; set; } = string.Empty;
        public ReelStrip[] Strips { get; set; } = Array.Empty<ReelStrip>();

        public GridSet()
        {
        }

        public GridSet(ReelStrip[] reelStrips)
        {
            Name = "Default";
            Strips = reelStrips;
        }
    }
}
