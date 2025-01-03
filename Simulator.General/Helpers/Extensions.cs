using Simulator.General.Slot;
using System.Threading.Tasks.Dataflow;

namespace Simulator.General.Helpers
{
    public static class Extensions
    {
        public static int GetIndex(this IGrid grid, int reel, int row)
        {
            var index = 0;
            for (var reelCounter = 0; reelCounter < grid.Symbols.Length; reelCounter++)
            {
                for (var rowCounter = 0; rowCounter < grid.Symbols[reelCounter].Length; rowCounter++)
                {
                    if(reel == reelCounter && row == rowCounter)
                        return index;
                    index++;
                }
            }

            return index;
        }
        public static int GetIndex(this int[][] grid, int reel, int row)
        {
            var index = 0;
            for (var reelCounter = 0; reelCounter < grid.Length; reelCounter++)
            {
                for (var rowCounter = 0; rowCounter < grid[reelCounter].Length; rowCounter++)
                {
                    if (reel == reelCounter && row == rowCounter)
                        return index;
                    index++;
                }
            }

            return index;
        }

        public static int GetSymbolCount(this int[][] symbols, int symbolId)
        {
            var symbolCount = 0;

            for (var column = 0; column < symbols.Length; column++)
            {
                for (var row = 0; row < symbols[column].Length; row++)
                {
                    if (symbols[column][row] == symbolId)
                        symbolCount++;
                }
            }

            return symbolCount;
        }

        public static int[] GetStripPart(this ReelStrip strip, int length, int startingPosition = 0, bool IsForward = true)
        {
            var part = new int[length];
            var stripLength = strip.Strip.Length;
            var lengthCeiling = length - 1;

            if (IsForward)
            {
                for (var counter = 0; counter < length; counter++)
                {
                    var position = startingPosition + counter;
                    position = position >= stripLength ? position - stripLength : position;
                    part[counter] = strip.Strip[position];
                }
            }
            else
            {
                for (var counter = lengthCeiling; counter >= 0; counter--)
                {
                    var position = startingPosition + counter - length;
                    position = position < 0 ? stripLength + position : position;
                    part[lengthCeiling-counter] = strip.Strip[position];
                }
            }

            return part;
        }

        public static int[][] CloneStrip(this int[][] strip)
        {
            var outputStrip = new int[strip.Length][];

            for (var reelCounter = 0; reelCounter < strip.Length; reelCounter++)
            {
                for (var rowCounter = 0; rowCounter < strip[reelCounter].Length; rowCounter++)
                    outputStrip[reelCounter] = (int[]) strip[reelCounter].Clone();
            }

            return outputStrip;
        }

        public static List<int> GetCascadingIndices(this SpinInformation spin)
        {
            return spin.Combos.SelectMany(c => c.Indices).Distinct().ToList();
        }

        public static bool IsComboExisting(this List<Combo> wins, int[] indicesToCheck)
        {
            var combosLeft = wins;

            foreach (var index in indicesToCheck)
            {
                combosLeft = combosLeft.Where(c => c.Indices.Contains(index)).ToList();
            }

            return combosLeft.Any();
        }
    }
}
