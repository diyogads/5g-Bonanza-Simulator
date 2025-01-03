namespace Simulator.General.Slot
{
    public class SymbolPays
    {
        public int SymbolId { get; set; }
        public int Count { get; set; }
        public int WinningAmount { get; set; }

        public SymbolPays(int symbolId, int count, int winningAmount)
        {
            SymbolId = symbolId;
            Count = count;
            WinningAmount = winningAmount;
        }
    }
}
