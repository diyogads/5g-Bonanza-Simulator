using Simulator.General.Helpers;
using Simulator.General.Slot;
using System.Net.Sockets;

namespace Simulator.General.Statistics
{
    public class WinDistribution
    {
        public WinBucket[] WinBuckets { get; set; } = Array.Empty<WinBucket>();
        public SymbolWinBucket[] SymbolWinBuckets { get; set; } = Array.Empty<SymbolWinBucket>();
        public string[] SymbolNames { get; set; } = Array.Empty<string>();
        public int Bet { get; set; }

        public void AddStatistics(RoundInformation round)
        {
            for (var bucketCounter = 0; bucketCounter < WinBuckets.Length; bucketCounter++)
            {
                var bucket = WinBuckets[bucketCounter];

                if (bucket.Floor == 0 && bucket.Ceiling == 0 && round.TotalAmountWon == 0)
                {
                    bucket.TotalCoinsWon += round.TotalCoinsWon;
                    bucket.TotalCount++;
                }
                else if (bucket.Floor < round.TotalAmountWon && bucket.Ceiling >= round.TotalAmountWon)
                {
                    bucket.TotalCoinsWon += round.TotalCoinsWon;
                    bucket.TotalCount++;
                }
            }

            for (var bucketCounter = 0; bucketCounter < SymbolWinBuckets.Length; bucketCounter++)
            {
                var bucket = SymbolWinBuckets[bucketCounter];
                var combos = round.Spins.SelectMany(s => s.Combos);

                foreach (var combo in combos)
                {
                    if (bucket.SymbolId == combo.SymbolId && bucket.SymbolCount <= combo.Length)
                    {
                        bucket.TotalCoinsWon += round.TotalCoinsWon;
                        bucket.TotalCount++;
                    }
                }
            }
        }

        public void PrintWinBuckets(long totalRounds)
        {
            var padWidth = $"{WinBuckets[^1].Floor}-{WinBuckets[^1].Ceiling}".Length + 5;

            Console.WriteLine("-------------------------");
            Console.WriteLine("Win Distribution");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Wins\t\tTotal Count\tProbability");
            foreach (var bucket in WinBuckets)
            {
                string paddedBucket = $"{bucket.Floor}-{bucket.Ceiling}".PadRight(padWidth);
                string paddedTotalWin = $"{bucket.TotalCount}".PadRight(padWidth);
                Console.WriteLine($"{paddedBucket}{paddedTotalWin}{Helper.GetProbability(bucket.TotalCount, totalRounds)} %");
            }

            Console.WriteLine();
            Console.WriteLine($"Total Probability: {Helper.GetProbability(WinBuckets.Sum(s => s.TotalCount), totalRounds)} %");
        }

        public void PrintSymbolWinBuckets(long totalRounds)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Symbol Win Distribution");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Winning\t\tTotal Count\tDistribution\tProbability");

            var totalWon = SymbolWinBuckets.Sum(s => s.TotalCoinsWon);
            var symbol = string.Empty;

            foreach (var bucket in SymbolWinBuckets)
            {
                symbol = SymbolNames != null ? $"{bucket.SymbolCount} {SymbolNames[bucket.SymbolId]}" : $"{bucket.SymbolCount} {bucket.SymbolId}";

                Console.WriteLine($"x{symbol}\t\t{bucket.TotalCount}\t\t{string.Format("{0:0.0000000}", Helper.GetProbability(bucket.TotalCoinsWon, totalWon))} %\t{string.Format("{0:0.0000000}", Helper.GetProbability(bucket.TotalCount, totalRounds))} %");
            }
        }
    }
}
