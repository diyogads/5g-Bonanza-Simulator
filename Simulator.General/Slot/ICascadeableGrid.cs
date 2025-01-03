using Simulator.General.Helpers;

namespace Simulator.General.Slot
{
    internal interface ICascadeableGrid : IGrid
    {
        void Cascade(Direction cascadeDirection = Direction.Down);
    }
}
