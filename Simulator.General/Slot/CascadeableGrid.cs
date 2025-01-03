using Simulator.General.Helpers;
using Simulator.General.Randomization;

namespace Simulator.General.Slot
{
    public class CascadeableGrid : ICascadeableGrid
    {

        public int ReelCount { get; set; }
        public int RowCount { get; set; }
        public int[][] Symbols { get; set; } = Array.Empty<int[]>();
        public GridSet Set { get; set; } = new GridSet();
        public int[] StopPositions { get; set; } = Array.Empty<int>();
        public Randomizer Randomizer { get; set; } = new Randomizer();

        public CascadeableGrid(int reelCount = 5, int rowCount = 4)
        {
            ReelCount = reelCount;
            RowCount = rowCount;
            StopPositions = new int[rowCount];
            Symbols = new int[rowCount][];

            for (var rowCounter = 0; rowCounter < rowCount; rowCounter++)
            {
                Symbols[rowCounter] = new int[reelCount];
            }
        }

        public void Cascade(Direction cascadeDirection = Direction.Down)
        {
            switch (cascadeDirection)
            {
                case Direction.Left:
                    CascadeLeft();
                    break;
            }
        }

        private void CascadeLeft()
        {
            for (int rowCounter = RowCount - 1; rowCounter >= 0; rowCounter--)
            {
                int writeIndex = 0; // Start from left
                var blankSymbolCount = Symbols[rowCounter].ToList().Count(s => s == GenericSymbols.Blank);
                var cascadingSymbols = Set.Strips[rowCounter].GetStripPart(blankSymbolCount, StopPositions[rowCounter], false);

                // Move non-zero elements to the right
                for (int reelCounter = 0; reelCounter < ReelCount; reelCounter++)
                {
                    if (Symbols[rowCounter][reelCounter] != 0)
                    {
                        Symbols[rowCounter][writeIndex] = Symbols[rowCounter][reelCounter];

                        if (writeIndex != reelCounter)
                            Symbols[rowCounter][reelCounter] = 0; // Clear the moved position

                        writeIndex++;
                    }
                }

                var counter = 0;

                // Fill the remaining empty spaces with symbols from the reel strip
                while (writeIndex < Symbols[rowCounter].Length)
                {
                    Symbols[rowCounter][writeIndex] = cascadingSymbols[counter];
                    StopPositions[rowCounter] = (StopPositions[rowCounter] + 1) % StopPositions.Length; // Move to the next symbol
                    writeIndex++;
                    counter++;
                }
            }
        }

        public void Spin(Direction spinDirection = Direction.Down)
        {
            switch (spinDirection)
            {
                case Direction.Left:
                    SpinToLeft();
                    break;
            }
        }

        private void SpinToLeft()
        {
            for (var rowCounter = 0; rowCounter < RowCount; rowCounter++)
            {
                var stripLength = Set.Strips[rowCounter].Strip.Length;
                var stopPosition = Randomizer.GetNext(stripLength);
                StopPositions[rowCounter] = stopPosition;

                var counter = 0;
                for (var reelCounter = ReelCount - 1; reelCounter >= 0; reelCounter--)
                {
                    var position = stopPosition + counter;
                    position = position >= stripLength ? position - stripLength : position;
                    var symbol = Set.Strips[rowCounter].Strip[position];

                    Symbols[rowCounter][reelCounter] = symbol;
                    counter++;
                }
            }
        }
    }
}
