using Simulator.General.Helpers;
using Simulator.General.Randomization;

namespace Simulator.General.Slot
{
    public class DynamicRowCascadeableGrid : ICascadeableGrid, IDynamicRowGrid
    {
        public int ReelCount { get; set; }
        public int[] RowCounts { get; set; }
        public int[][] Symbols { get; set; } = Array.Empty<int[]>();
        public GridSet Set { get; set; } = new GridSet();
        public int[] StopPositions { get; set; }
        public Randomizer Randomizer { get; set; } = new Randomizer();

        public DynamicRowCascadeableGrid(int reelCount = 5, int initialRowCount = 2)
        {
            ReelCount = reelCount;
            RowCounts = new int[reelCount];

            for (var counter = 0; counter < reelCount; counter++)
                RowCounts[counter] = initialRowCount;
            
            StopPositions = new int[reelCount];
            Symbols = new int[reelCount][];
        }

        public void Cascade(Direction cascadeDirection = Direction.Down)
        {
            switch (cascadeDirection)
            {
                case Direction.Down:
                    CascadeDown();
                    break;
            }
        }

        private void CascadeDown()
        {
            for (int reelCounter = 0; reelCounter < ReelCount; reelCounter++)
            {
                var blankSymbolCount = Symbols[reelCounter].ToList().Count(s => s == GenericSymbols.Blank);
                var cascadingSymbols = Set.Strips[reelCounter].GetStripPart(blankSymbolCount, StopPositions[reelCounter], false);
                int writeIndex = RowCounts[reelCounter] - 1; // Start from the bottom

                // Move non-zero elements down
                for (int rowCounter = RowCounts[reelCounter] - 1; rowCounter >= 0; rowCounter--)
                {
                    if (Symbols[reelCounter][rowCounter] != 0)
                    {
                        Symbols[reelCounter][writeIndex] = Symbols[reelCounter][rowCounter];

                        if (writeIndex != rowCounter)
                            Symbols[reelCounter][rowCounter] = 0; // Clear the moved position

                        writeIndex--;
                    }
                }

                var counter = 0;

                // Fill the remaining empty spaces with symbols from the reel strip
                while (writeIndex >= 0)
                {
                    Symbols[reelCounter][counter] = cascadingSymbols[writeIndex];
                    StopPositions[reelCounter] = (StopPositions[reelCounter] + 1) % StopPositions.Length; // Move to the next symbol
                    writeIndex--;
                    counter++;
                }
            }
        }

        public void Spin(Direction spinDirection = Direction.Down)
        {
            switch (spinDirection)
            {
                case Direction.Down:
                    SpinDown();
                    break;
            }
        }

        private void SpinDown()
        {
            for (var reelCounter = 0; reelCounter < ReelCount; reelCounter++)
            {
                var stripLength = Set.Strips[reelCounter].Strip.Length;
                var stopPosition = Randomizer.GetNext(stripLength);
                StopPositions[reelCounter] = stopPosition;

                for (var rowCounter = 0; rowCounter < RowCounts[reelCounter]; rowCounter++)
                {
                    var position = stopPosition + rowCounter;
                    position = position >= stripLength ? position-stripLength : position;
                    var symbol = Set.Strips[reelCounter].Strip[position];

                    Symbols[reelCounter][rowCounter] = symbol;
                }
            }
        }
    }
}
