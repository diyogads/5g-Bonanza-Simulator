using Simulator.General.Helpers;
using Simulator.General.Randomization;
using Simulator.General.Slot;
using Simulator.General.Statistics;

namespace Simulator.Game
{
    public class BonanzaGame : CascadingPaywayGameSession
    {
        CascadeableGrid TopGrid = new(4,1);

        public BonanzaGame(int reelCount = 5, int rowCount = 4) : base(reelCount, rowCount)
        {
            Grid.Set = Constants.BaseGameGridSet;
            TopGrid.Set = Constants.BaseGameTopReelGridSet;
            TopGrid.Randomizer = Randomizer;
            SlotCalculator.PayTable = Constants.PayTable;
            SlotCalculator.WildSymbolIds.Add(Symbols.WC);
        }

        public void ClearAll()
        {
            Randomizer.Reset();
        }

        public RoundInformation PlayRound()
        {
            var roundInformation = new RoundInformation();
            var spins = new List<SpinInformation>();

            spins.AddRange(PlayBaseGame());

            while (FreeSpinCount > 0)
            {
                spins.AddRange(PlayFreeSpins());
                FreeSpinCount--;
            }

            roundInformation.Spins = spins.ToArray();
            return roundInformation;
        }

        private SpinInformation PlayInitialSpin(WeightedValueList[] symbolCountValues, SpinType spinType = SpinType.Base)
        {
            var rowCounts = new int[Grid.ReelCount];

            for (var reelCounter = 0; reelCounter < Grid.ReelCount; reelCounter++)
            {
                rowCounts[reelCounter] = symbolCountValues[reelCounter].GetWeightedValue(Randomizer);
                Grid.Symbols[reelCounter] = new int[rowCounts[reelCounter]];
            }

            Grid.RowCounts = rowCounts;
            Grid.Spin();
            TopGrid.Spin(Direction.Left);

            return ProcessSpinInformation(spinType);
        }

        private SpinInformation PlayCascade(SpinType spinType = SpinType.Base)
        {
            Grid.Cascade();
            TopGrid.Cascade(Direction.Left);
            var spin = ProcessSpinInformation(spinType);
            spin.IsCascade = true;

            return spin;
        }

        private List<SpinInformation> PlayBaseGame()
        {
            var spinInformation = new List<SpinInformation>();
            var spin = PlayInitialSpin(Constants.BaseGameSymbolCountWeights);

            spinInformation.Add(spin);

            while (spin.TotalCoinsWon > 0)
            {
                spin = PlayCascade();
                spinInformation.Add(spin);
            }

            if (SlotCalculator.Symbols.GetSymbolCount(Symbols.SC) >= Constants.BaseGameScatterTriggerCount)
            {
                FreeSpinCount += Constants.InitialFreeSpinCount;
                spinInformation[^1].Events.Add(new Event { Type = EventType.FreeSpin, Name = Constants.FreeSpinName });
            }

            return spinInformation;
        }

        private List<SpinInformation> PlayFreeSpins()
        {
            Grid.Set = Constants.FreeSpinGridSet;
            TopGrid.Set = Constants.FreeSpinTopReelGridSet;

            var spinInformation = new List<SpinInformation>();
            var spin = PlayInitialSpin(Constants.FreeSpinSymbolCountWeights, SpinType.Free);

            spinInformation.Add(spin);

            while (spin.TotalCoinsWon > 0)
            {
                spin = PlayCascade(SpinType.Free);
                spinInformation.Add(spin);
            }

            if (SlotCalculator.Symbols.GetSymbolCount(Symbols.SC) >= Constants.FreeSpinScatterTriggerCount)
            {
                FreeSpinCount += Constants.ReTriggerFreeSpinCount;
                spinInformation[^1].Events.Add(new Event { Type = EventType.Feature, Name = Constants.FreeSpinReTriggerName });
            }

            return spinInformation;
        }

        private SpinInformation ProcessSpinInformation(SpinType spinType)
        {
            var appendedGrid = AppendGrids().CloneStrip();
            SlotCalculator.CalculateWinnings();

            var spin = new SpinInformation
            {
                SpinType = spinType,
                Combos = SlotCalculator.Combos.ToArray(),
                Symbols = appendedGrid
            };

            RemoveCascadingSymbols(spin);

            return spin;
        }

        private void RemoveCascadingSymbols(SpinInformation spin)
        {
            var indicesToCascade = spin.GetCascadingIndices();

            for (var reelCounter = 0; reelCounter < spin.Symbols.Length; reelCounter++)
            {
                for (var rowCounter = 0; rowCounter < spin.Symbols[reelCounter].Length; rowCounter++)
                {
                    var index = spin.Symbols.GetIndex(reelCounter, rowCounter);
                    var isCascadingSymbol = indicesToCascade.Contains(index);

                    if(isCascadingSymbol)
                    {
                        if (rowCounter == 0)
                            TopGrid.Symbols[rowCounter][reelCounter-1] = GenericSymbols.Blank;
                        else
                            Grid.Symbols[reelCounter][rowCounter-1] = GenericSymbols.Blank;
                    }
                }
            }
        }

        private int[][] AppendGrids()
        {
            var appendedGrid = new int[Grid.ReelCount][];

            for (var reelCounter = 0; reelCounter < Grid.ReelCount; reelCounter++)
            {
                appendedGrid[reelCounter] = new int[Grid.RowCounts[reelCounter] + 1];

                if (reelCounter >= 1 && reelCounter <= 4)
                    appendedGrid[reelCounter][0] = TopGrid.Symbols[0][reelCounter-1];
                else
                    appendedGrid[reelCounter][0] = GenericSymbols.Blank;

                for (var rowCounter = 0; rowCounter < Grid.RowCounts[reelCounter]; rowCounter++)
                    appendedGrid[reelCounter][rowCounter+1] = Grid.Symbols[reelCounter][rowCounter];
            }

            SlotCalculator.Symbols = appendedGrid.CloneStrip();

            return appendedGrid;
        }
    }
}
