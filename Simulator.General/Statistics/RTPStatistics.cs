using Simulator.General.Helpers;
using Simulator.General.Slot;

namespace Simulator.General.Statistics
{
    public class RTPStatistics
    {
        public int Bet { get; set; } = 20;
        public long RoundsPlayed { get; set; }
        public long SpinsPlayed { get; set; }
        public long CascadesCount{ get; set; }
        public long TotalBet { get; set; }
        public long BaseGameWin { get; set; }
        public long FreeSpinWin { get; set; }
        public int FreeSpinsTriggerCount { get; set; }
        public int FreeSpinsReTriggerCount { get; set; }
        public decimal MaxExposure { get; set; }

        public decimal TotalWin => BaseGameWin + FreeSpinWin;
        public int TotalFreeSpins => (FreeSpinsTriggerCount + FreeSpinsReTriggerCount) * 5;
        public decimal BaseGameRTP => decimal.Divide(BaseGameWin, TotalBet); 
        public decimal FreeSpinRTP => decimal.Divide(FreeSpinWin, TotalBet);
        public decimal OverallRTP => BaseGameRTP + FreeSpinRTP;
        public decimal FreeSpinAveragePay => decimal.Divide(FreeSpinWin, FreeSpinsTriggerCount);


        public WinDistribution WinDistribution { get; set; } = new WinDistribution();

        public void AddStatistics(RoundInformation round)
        {
            RoundsPlayed++;
            TotalBet += Bet;
            MaxExposure = round.TotalAmountWon > MaxExposure ? round.TotalAmountWon : MaxExposure;

            BaseGameWin += round.Spins.Where(s => s.SpinType == Helpers.SpinType.Base).Sum(s => s.TotalCoinsWon);
            FreeSpinWin += round.Spins.Where(s => s.SpinType == Helpers.SpinType.Free).Sum(s => s.TotalCoinsWon);

            FreeSpinsTriggerCount += round.Spins.SelectMany(s => s.Events).Count(e => e.Type == EventType.FreeSpin);
            FreeSpinsReTriggerCount += round.Spins.SelectMany(s => s.Events).Count(e => e.Type == EventType.Feature);

            SpinsPlayed += round.Spins.Count(s => !s.IsCascade);
            CascadesCount += round.Spins.Count(s => s.IsCascade);

            WinDistribution.AddStatistics(round);
        }

        public void PrintStatistics()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("RTP Statistics");
            Console.WriteLine("-------------------------");

            Console.WriteLine();

            Console.WriteLine($"Rounds Played: {RoundsPlayed}");
            Console.WriteLine($"Spins Played: {SpinsPlayed}");
            Console.WriteLine($"Cascasdes Count: {CascadesCount}");
            Console.WriteLine($"Total Bet: {TotalBet}");
            Console.WriteLine($"Total Win: {TotalWin}");
            Console.WriteLine($"Overall RTP: {OverallRTP}");
            Console.WriteLine($"Maximum Exposure: {MaxExposure}");

            Console.WriteLine();

            Console.WriteLine($"Base Game Win: {BaseGameWin}");
            Console.WriteLine($"Base Game RTP: {BaseGameRTP}");

            Console.WriteLine();

            Console.WriteLine($"Total FreeSpins: {TotalFreeSpins}");
            Console.WriteLine($"FreeSpin Win: {FreeSpinWin}");
            Console.WriteLine($"FreeSpin RTP: {FreeSpinRTP}");
            Console.WriteLine($"FreeSpin Average Pay: {FreeSpinAveragePay}");
            Console.WriteLine($"FreeSpin Trigger Count: {FreeSpinsTriggerCount}");
            Console.WriteLine($"FreeSpin Probability: {Helper.GetProbability(FreeSpinsTriggerCount, RoundsPlayed)}");
            Console.WriteLine($"FreeSpin ReTrigger Count: {FreeSpinsReTriggerCount}");
            Console.WriteLine($"FreeSpin ReTrigger Probability: {Helper.GetProbability(FreeSpinsReTriggerCount, FreeSpinsTriggerCount)}");

            Console.WriteLine();

            WinDistribution.PrintWinBuckets(RoundsPlayed);

            Console.WriteLine();

            WinDistribution.PrintSymbolWinBuckets(RoundsPlayed);
        }
    }
}