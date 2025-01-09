using Simulator.General.Helpers;

namespace Simulator.General.Slot
{
    public class WaysCalculator : ISlotCalculator
    {
        public int[][] Symbols { get; set; } = Array.Empty<int[]>();
        public List<Combo> Combos { get; set; } = new List<Combo>();
        public List<SymbolPays> PayTable { get; set; } = new List<SymbolPays>();
        public bool IsLeftToRight = true;
        public List<int> WildSymbolIds { get; set; } = new List<int>();
        public int FreeSpinsMultiplier { get; set; } = 1;

        public void CalculateWinnings()
        {
            var winningCombos = new List<Combo>();

            for (var symbolCounter = 0; symbolCounter < Symbols[0].Length; symbolCounter++)
            {
                var symbolId = Symbols[0][symbolCounter];

                if(symbolId == GenericSymbols.Blank)
                    continue;

                var ways = 0;
                var depth = 1;
                var indices = new List<int>
                {
                    Symbols.GetIndex(0, symbolCounter)
                };

                for (var reelCounter = 1; reelCounter < Symbols.Length; reelCounter++)
                {
                    var symbolCount = 0;

                    for (var rowCounter = 0; rowCounter < Symbols[reelCounter].Length; rowCounter++)
                    {
                        if (Symbols[reelCounter][rowCounter] == symbolId || WildSymbolIds.Contains(Symbols[reelCounter][rowCounter]))
                        {
                            symbolCount++;
                            indices.Add(Symbols.GetIndex(reelCounter, rowCounter));
                        }
                    }

                    if (symbolCount > 0)
                    {
                        if (ways == 0)
                            ways += symbolCount;
                        else
                            ways *= symbolCount;

                        depth++;
                    }
                    else
                        break;
                }

                var symbolPay = PayTable.FirstOrDefault(x => x.Count == depth && x.SymbolId == symbolId);
                int? winningAmount = symbolPay?.WinningAmount;

                if (winningAmount.HasValue && winningAmount.Value > 0)
                {
                    winningCombos.Add(new Combo
                    {
                        SymbolId = symbolId,
                        Indices = indices.ToArray(),
                        CoinsWon = (int)winningAmount,
                        Length = depth,
                        Ways = ways,
                        Multiplier = FreeSpinsMultiplier
                    });
                }
            }

            Combos = winningCombos;
        }
    }
}
