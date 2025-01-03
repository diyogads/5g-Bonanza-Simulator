namespace Simulator.General.Randomization
{
    public class WeightedValue
    {
        public int Weight { get; set; }
        public int Value { get; set; }

        public WeightedValue(int weight, int value)
        {
            Weight = weight;
            Value = value;
        }
    }
}
