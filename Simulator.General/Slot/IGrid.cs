using Simulator.General.Helpers;

namespace Simulator.General.Slot
{
    public interface IGrid
    {
        public int ReelCount { get; set; }
        public int[][] Symbols { get; set; }
        void Spin(Direction spinDirection = Direction.Down);
    }
}
