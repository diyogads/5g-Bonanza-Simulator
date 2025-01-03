namespace Simulator.General.Randomization
{
    public class Randomizer : IRandomizer
    {
        public int[] Seed { get; set; } = Array.Empty<int>();
        public int UsedSeedCount { get; set; }
        public List<int> Randoms { get; set; } = new List<int>();
        public Random Random { get; set; } = new Random();

        public int GetNext(int ceiling)
        {
            if (Seed.Length > 0 && UsedSeedCount != Seed.Length)
            {
                if (Seed[UsedSeedCount] > ceiling)
                    throw new Exception("Incorrect random");
                else
                {
                    var random = Seed[UsedSeedCount];
                    Randoms.Add(random);
                    UsedSeedCount++;
                    return random;
                }
            }
            else
            {
                var random = Random.Next(ceiling);
                Randoms.Add(random);
                return random;
            }
        }

        public void Reset()
        {
            Array.Clear(Seed);
            UsedSeedCount = 0;
            Randoms.Clear();
        }
    }
}
