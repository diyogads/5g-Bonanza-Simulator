namespace Simulator.General.Slot
{
    public class RoundInformation
    {
        public SpinInformation[] Spins { get; set; } = Array.Empty<SpinInformation>();
        public int TotalCoinsWon => Spins.ToList().Sum(s => s.TotalCoinsWon);
        public decimal TotalAmountWon => decimal.Divide(TotalCoinsWon, Bet);
        public int Bet {  get; set; }
        public RoundInformation(int bet = 20)
        {
            Bet = bet;
        }
    }
}
