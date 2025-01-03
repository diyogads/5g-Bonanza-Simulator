namespace Simulator.General.Slot
{
    public class Combo : ISymbolWinning
    {
        public int Length { get; set; }
        public int[] Indices { get; set; } = Array.Empty<int>();
        public int SymbolId { get; set; }
        public int CoinsWon { get; set; }
        public int Ways { get; set; }
    }
}