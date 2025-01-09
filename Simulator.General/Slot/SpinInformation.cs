using Simulator.General.Helpers;
using Simulator.General.Statistics;

namespace Simulator.General.Slot
{
    public class SpinInformation
    {
        public List<Event> Events { get; set; } = new List<Event>();
        public SpinType SpinType { get; set; }
        public bool IsCascade { get; set; } = false;
        public int[][] Symbols { get; set; } = Array.Empty<int[]>();
        public Combo[] Combos { get; set; } = Array.Empty<Combo>();
        public int TotalCoinsWon => Combos.ToList().Sum(c => c.TotalCoinsWon);
        public decimal TotalAmountWon => Helper.GetRemainder(TotalCoinsWon, Bet);
        public int Bet { get; set; }
        public SpinInformation(int bet = 20)
        {
            Bet = bet;
        }
    }
}
