// See https://aka.ms/new-console-template for more information
using Simulator.Game;
using Simulator.General.Helpers;
using Simulator.General.Slot;
using Extensions = Simulator.Game.Extensions;

Console.WriteLine("Bonanza Game");
Console.WriteLine();
Console.WriteLine("Please see commands below:");
Console.WriteLine("> Press \"Enter\" if you'd like to spin one without seed");
Console.WriteLine("> Type the seed (comma-delimited) then enter if you want to simulate with seed");
Console.WriteLine("> Type \"RTP\" then number of rounds if you want to check statistics (ex: RTP 1000000)");
var input = Console.ReadLine()?.ToLower();

if (input == null)
{
    Console.WriteLine("Invalid input");
}
else if (!input.Contains("rtp"))
{
    do
    {
        var game = new BonanzaGame(Constants.ReelCount);
        Console.Clear();
        Console.WriteLine("Bonanza Game Spins");
        Console.WriteLine();

        if (!string.IsNullOrEmpty(input))
        {
            var stringRandoms = input.Split(',', StringSplitOptions.TrimEntries);
            var seeds = new List<int>();
            var stringError = new List<string>();

            for (var randomCounter = 0; randomCounter < stringRandoms.Length; randomCounter++)
            {
                try
                {
                    seeds.Add(Convert.ToInt32(stringRandoms[randomCounter]));
                }
                catch
                {
                    stringError.Add(stringRandoms[randomCounter]);
                }
            }

            if (stringError.Count > 0)
                Console.WriteLine($"Ommitted from randoms due to error: {string.Join(",", stringError)}");

            if (seeds.Count > 0)
            {
                game.Randomizer.Seed = seeds.ToArray();
                Console.WriteLine($"Added seed to randomizer: {string.Join(",", seeds)}");
            }
        }

        var round = game.PlayRound();
        var actualSpinCounter = 1;

        Console.WriteLine($"Randoms: {string.Join(", ", game.Randomizer.Randoms.ToArray())}");
        Console.WriteLine();

        for (var spinCounter = 0; spinCounter < round.Spins.Length; spinCounter++)
        {
            var spin = round.Spins[spinCounter];
            var spinType = spin.SpinType == SpinType.Base ? "Base Game" : "Free";

            if (!spin.IsCascade)
            {
                var ways = 1;

                foreach (var symbols in spin.Symbols)
                    if (symbols != null)
                        ways *= symbols.ToList().Count(s => s != GenericSymbols.Blank);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{spinType} Spin #{actualSpinCounter}: {ways} Megaways");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                actualSpinCounter++;
            }

            Console.WriteLine("Symbols:");
            game.PrintGridSymbols(spin.Symbols);
            Console.WriteLine();

            if (spin.Combos.Length > 0)
            {
                Console.WriteLine("Symbols to cascade:");
                var indicesToCascade = spin.GetCascadingIndices();
                game.PrintGridSymbols(spin.Symbols, indicesToCascade);
                Console.WriteLine();

                foreach (var combo in spin.Combos)
                {
                    Console.WriteLine($"x{combo.Length} {Symbols.Name[combo.SymbolId]} for {combo.Ways} way/s: {combo.CoinsWon/combo.Ways} coins");
                }

                Console.WriteLine($"Total coins won: {spin.TotalCoinsWon}");
                Console.WriteLine();
            }
        }

        Console.WriteLine($"Total coins won: {round.TotalCoinsWon}");
        Console.WriteLine($"Total amount won: {round.TotalAmountWon}");
        Console.WriteLine();
        Console.WriteLine("> Type \"exit\" to end");
        Console.WriteLine("> Press \"Enter\" if you'd like to spin one without seed");
        Console.WriteLine("> Type the seed (comma-delimited) then enter if you want to simulate with seed");
        input = Console.ReadLine()?.ToLower();
    }
    while (input != "exit");
}
else
{
    long rounds = 0;
    try
    {
        rounds = Convert.ToInt64(input.Split("rtp", StringSplitOptions.RemoveEmptyEntries)[0].Trim());
    }
    catch
    {
        Console.WriteLine("Invalid round number");
    }

    Console.Clear();
    Console.WriteLine("Bonanza Game RTP");
    Console.WriteLine();

    Extensions.RunRTPTests(rounds);
}