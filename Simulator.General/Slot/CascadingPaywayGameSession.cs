using Simulator.General.Randomization;

namespace Simulator.General.Slot
{
    public abstract class CascadingPaywayGameSession
    {
        public WaysCalculator SlotCalculator { get; set; }
        public DynamicRowCascadeableGrid Grid { get; set; }
        public Randomizer Randomizer { get; set; }
        public int FreeSpinCount { get; set; }

        public CascadingPaywayGameSession(int reelCount = 5, int rowCount = 4)
        {
            Randomizer = new Randomizer();
            Grid = new DynamicRowCascadeableGrid(reelCount, rowCount)
            {
                Randomizer = Randomizer
            };
            SlotCalculator = new WaysCalculator();
        }
    }
}