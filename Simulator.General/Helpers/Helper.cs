using Simulator.General.Statistics;

namespace Simulator.General.Helpers
{
    public enum SpinType
    {
        Base = 0,
        Free = 1
    }

    public enum Direction
    {
        Down = 0,
        Left = 1,
        Right = 2,
        Up = 3
    }

    public static class Helper
    {
        public static decimal GetProbability(decimal dividend, decimal divisor, int decimalPlaces = 8)
        {
            return Math.Round(decimal.Divide(dividend, divisor) * 100, decimalPlaces);
        }
    }
}
