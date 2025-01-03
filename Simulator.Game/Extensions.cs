using Simulator.General.Helpers;
using Simulator.General.Statistics;
using System.Diagnostics;

namespace Simulator.Game
{
    public static class Extensions
    {
        public static void PrintGridSymbols(this BonanzaGame game, int[][] gridSymbols, List<int>? indicesToCascade = null)
        {
            if (indicesToCascade != null)
            {
                for (var rowCounter = 0; rowCounter < 8; rowCounter++)
                {
                    for (var reelCounter = 0; reelCounter < game.Grid.ReelCount; reelCounter++)
                    {
                        var index = gridSymbols.GetIndex(reelCounter, rowCounter);
                        var isCascadingSymbol = indicesToCascade.Contains(index);
                        try
                        {
                            if (isCascadingSymbol)
                                Console.ForegroundColor = ConsoleColor.Green;
                            else
                                Console.ForegroundColor = ConsoleColor.White;

                            Console.Write(Symbols.Name[gridSymbols[reelCounter][rowCounter]] + " ");
                        }
                        catch
                        {
                            Console.Write("   ");
                        }
                    }
                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                for (var rowCounter = 0; rowCounter < 8; rowCounter++)
                {
                    for (var reelCounter = 0; reelCounter < game.Grid.ReelCount; reelCounter++)
                    {
                        try
                        {
                            Console.Write(Symbols.Name[gridSymbols[reelCounter][rowCounter]] + " ");
                        }
                        catch
                        {
                            Console.Write("   ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void RunRTPTests(long rounds)
        {
            var rtpStats = new RTPStatistics
            {
                WinDistribution = new WinDistribution { Bet = Constants.Bet }
            };

            rtpStats.WinDistribution.WinBuckets = new WinBucket[]
            {
                new() { Floor = 0, Ceiling = 0 },
                new() { Floor = 0, Ceiling = 0.5m },
                new() { Floor = 0.5m, Ceiling = 1 },
                new() { Floor = 1, Ceiling = 2 },
                new() { Floor = 2, Ceiling = 4 },
                new() { Floor = 4, Ceiling = 7 },
                new() { Floor = 7, Ceiling = 10 },
                new() { Floor = 10, Ceiling = 15 },
                new() { Floor = 15, Ceiling = 25 },
                new() { Floor = 25, Ceiling = 50 },
                new() { Floor = 50, Ceiling = 100 },
                new() { Floor = 100, Ceiling = 200 },
                new() { Floor = 200, Ceiling = 500 },
                new() { Floor = 500, Ceiling = 1000 },
                new() { Floor = 1000, Ceiling = 1500 },
                new() { Floor = 1500, Ceiling = 2500 },
                new() { Floor = 2500, Ceiling = 5000 },
                new() { Floor = 5000, Ceiling = 10000 },
                new() { Floor = 10000, Ceiling = 20000 },
                new() { Floor = 20000, Ceiling = 50000 },
                new() { Floor = 50000, Ceiling = 99999 },
            };

            var symbolWinBucketCount = (Constants.SymbolsWith2Minimum * 5) + (Constants.SymbolsWith3Minimum * 4);
            rtpStats.WinDistribution.SymbolWinBuckets = new SymbolWinBucket[symbolWinBucketCount];
            rtpStats.WinDistribution.SymbolNames = Symbols.Name;

            var symbolBucketCounter = 0;
            for (var symbolId = Symbols.KK; symbolId <= Symbols.BB; symbolId++)
            {
                for (var counter = 3; counter <= 6; counter++)
                {
                    rtpStats.WinDistribution.SymbolWinBuckets[symbolBucketCounter] = new SymbolWinBucket
                    {
                        SymbolId = symbolId,
                        SymbolCount = counter
                    };

                    symbolBucketCounter++;
                }
            }

            for (var counter = 2; counter <= 6; counter++)
            {
                rtpStats.WinDistribution.SymbolWinBuckets[symbolBucketCounter] = new SymbolWinBucket
                {
                    SymbolId = Symbols.AA,
                    SymbolCount = counter
                };

                symbolBucketCounter++;
            }

            var roundsFivePercent = rounds * .05;
            var stopwatch = new Stopwatch();
            var rtpLock = new object();
            var progress = 0;

            stopwatch.Start();

            Console.WriteLine("Showing elapsed time as (hh:mm:ss)");

            Parallel.For(0, rounds, roundCounter =>
            {
                var game = new BonanzaGame(Constants.ReelCount);

                var round = game.PlayRound();

                lock (rtpLock)
                {
                    progress++;
                    if (progress % roundsFivePercent == 0)
                    {
                        var elapsed = stopwatch.Elapsed;
                        Console.WriteLine($"Currently at round {progress}. Elapsed time: {elapsed.Hours}:{elapsed.Minutes}:{elapsed.Seconds}.");
                    }
                    rtpStats.AddStatistics(round);
                }
            });

            Console.WriteLine();
            rtpStats.PrintStatistics();
        }
    }
}
