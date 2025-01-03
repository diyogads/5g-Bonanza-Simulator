namespace Simulator.General.Randomization
{
    public class WeightedValueList : IWeightedValueList
    {
        public string? Name { get; set; }
        public WeightedValue[] WeightedValues { get; set; } = Array.Empty<WeightedValue>();
        public int TotalWeight => GetTotalWeight(WeightedValues);

        public int GetTotalWeight(WeightedValue[] weightedValues)
        {
            var totalWeight = 0;

            for (var counter = 0; counter < weightedValues.Length; counter++)
                totalWeight += weightedValues[counter].Weight;

            return totalWeight;
        }

        public int GetWeightedValue()
        {
            return GetWeightedValue(WeightedValues);
        }

        public int GetWeightedValue(Randomizer randomizer)
        {
            return GetWeightedValue(WeightedValues, randomizer);
        }

        public int GetWeightedValue(WeightedValue[] weightedValues)
        {
            var weightedValue = new Random().Next(TotalWeight);
            var currentWeight = 0;

            for (var counter = 0; counter < weightedValues.Length; counter++)
            {
                currentWeight += weightedValues[counter].Weight;
                if (weightedValue < currentWeight && currentWeight >= 0)
                    return weightedValue;
            }

            return weightedValue;
        }

        public int GetWeightedValue(WeightedValue[] weightedValues, Randomizer randomizer)
        {
            var weightedValue = randomizer.GetNext(TotalWeight);
            var currentWeight = 0;

            for (var counter = 0; counter < weightedValues.Length; counter++)
            {
                currentWeight += weightedValues[counter].Weight;
                if (weightedValue <= currentWeight && currentWeight >= 0)
                    return weightedValues[counter].Value;
            }

            return weightedValue;
        }
    }
}