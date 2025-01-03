namespace Simulator.General.Randomization
{
    interface IWeightedValueList
    {
        WeightedValue[] WeightedValues { get; set; }
        int GetWeightedValue(WeightedValue[] weightedValues);
        int GetTotalWeight(WeightedValue[] weightedValues);
    }
}