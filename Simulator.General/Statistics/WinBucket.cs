namespace Simulator.General.Statistics
{
    public class WinBucket
    {
        public decimal Floor { get; set; }
        public decimal Ceiling { get; set; }
        public long TotalCoinsWon { get; set; }
        public long TotalCount { get; set; }
    }
}
