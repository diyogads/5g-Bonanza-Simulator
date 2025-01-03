﻿using Simulator.General.Randomization;
using Simulator.General.Slot;

namespace Simulator.Game
{
    public static class Constants
    {
        public const string DefaultName = "Default";
        public const string FreeSpinName = "FreeSpin";
        public const string FreeSpinReTriggerName = "FreeSpin ReTrigger";
        public const int Bet = 20;

        public const int ReelCount = 6;
        public const int SymbolsWith3Minimum = 9;
        public const int SymbolsWith2Minimum = 1;
        public const int BaseGameScatterTriggerCount = 4;
        public const int FreeSpinScatterTriggerCount = 4;
        public const int InitialFreeSpinCount = 12;
        public const int ReTriggerFreeSpinCount = 5;

        public static readonly WeightedValueList BaseGameSymbolCountReelOneWeights = new()
        {
            Name = DefaultName,
            WeightedValues = new WeightedValue[] {
                new(27, 2),
                new(27, 3),
                new(28, 4),
                new(11, 5),
                new(4, 6),
                new(3, 7),
            }
        };

        public static readonly WeightedValueList BaseGameSymbolCountReelTwoWeights = new()
        {
            Name = DefaultName,
            WeightedValues = new WeightedValue[] {
                new(27, 2),
                new(27, 3),
                new(28, 4),
                new(11, 5),
                new(4, 6),
                new(3, 7),
            }
        };

        public static readonly WeightedValueList BaseGameSymbolCountReelThreeWeights = new()
        {
            Name = DefaultName,
            WeightedValues = new WeightedValue[] {
                new(26, 2),
                new(24, 3),
                new(19, 4),
                new(15, 5),
                new(10, 6),
                new(6, 7),
            }
        };

        public static readonly WeightedValueList BaseGameSymbolCountReelFourWeights = new()
        {
            Name = DefaultName,
            WeightedValues = new WeightedValue[] {
                new(26, 2),
                new(24, 3),
                new(19, 4),
                new(15, 5),
                new(10, 6),
                new(6, 7),
            }
        };

        public static readonly WeightedValueList BaseGameSymbolCountReelFiveWeights = new()
        {
            Name = DefaultName,
            WeightedValues = new WeightedValue[] {
                new(28, 2),
                new(24, 3),
                new(19, 4),
                new(13, 5),
                new(10, 6),
                new(6, 7),
            }
        };

        public static readonly WeightedValueList BaseGameSymbolCountReelSixWeights = new()
        {
            Name = DefaultName,
            WeightedValues = new WeightedValue[] {
                new(28, 2),
                new(24, 3),
                new(19, 4),
                new(13, 5),
                new(10, 6),
                new(6, 7),
            }
        };

        public static readonly WeightedValueList[] BaseGameSymbolCountWeights = new WeightedValueList[]
        {
            BaseGameSymbolCountReelOneWeights,
            BaseGameSymbolCountReelTwoWeights,
            BaseGameSymbolCountReelThreeWeights,
            BaseGameSymbolCountReelFourWeights,
            BaseGameSymbolCountReelFiveWeights,
            BaseGameSymbolCountReelSixWeights,
        };

        public static readonly WeightedValueList FreeSpinSymbolCountReelOneWeights = new()
        {
            Name = DefaultName,
            WeightedValues = new WeightedValue[] {
                new(35, 2),
                new(27, 3),
                new(15, 4),
                new(13, 5),
                new(7, 6),
                new(3, 7),
            }
        };

        public static readonly WeightedValueList FreeSpinSymbolCountReelTwoWeights = new()
        {
            Name = DefaultName,
            WeightedValues = new WeightedValue[] {
                new(35, 2),
                new(28, 3),
                new(14, 4),
                new(12, 5),
                new(7, 6),
                new(4, 7),
            }
        };

        public static readonly WeightedValueList FreeSpinSymbolCountReelThreeWeights = new()
        {
            Name = DefaultName,
            WeightedValues = new WeightedValue[] {
                new(35, 2),
                new(29, 3),
                new(15, 4),
                new(10, 5),
                new(8, 6),
                new(3, 7),
            }
        };

        public static readonly WeightedValueList FreeSpinSymbolCountReelFourWeights = new()
        {
            Name = DefaultName,
            WeightedValues = new WeightedValue[] {
                new(35, 2),
                new(27, 3),
                new(17, 4),
                new(11, 5),
                new(6, 6),
                new(4, 7),
            }
        };

        public static readonly WeightedValueList FreeSpinSymbolCountReelFiveWeights = new()
        {
            Name = DefaultName,
            WeightedValues = new WeightedValue[] {
                new(31, 2),
                new(25, 3),
                new(20, 4),
                new(13, 5),
                new(7, 6),
                new(4, 7),
            }
        };

        public static readonly WeightedValueList FreeSpinSymbolCountReelSixWeights = new()
        {
            Name = DefaultName,
            WeightedValues = new WeightedValue[] {
                new(27, 2),
                new(25, 3),
                new(19, 4),
                new(14, 5),
                new(9, 6),
                new(6, 7),
            }
        };

        public static readonly WeightedValueList[] FreeSpinSymbolCountWeights = new WeightedValueList[]
        {
            FreeSpinSymbolCountReelOneWeights,
            FreeSpinSymbolCountReelTwoWeights,
            FreeSpinSymbolCountReelThreeWeights,
            FreeSpinSymbolCountReelFourWeights,
            FreeSpinSymbolCountReelFiveWeights,
            FreeSpinSymbolCountReelSixWeights,
        };

        public static readonly GridSet BaseGameGridSet = new()
        {
            Name = DefaultName,
            Strips = new[]
            {
                new ReelStrip(new int[] { 4,9,5,8,2,6,9,7,1,3,1,5,10,1,1,2,2,8,4,12,7,6,8,10,6,4,1,3,5,8,8,9,6,8,8,8,10,6,5,7,8,3,4,6,9,5,1,12,2,1,3,4,5,6,8,1,2,6,7,3,5,1,2,5,4,8,7,8,3,1,4,7,7,2,12,8,2,6,3,1,2,5,6,8,4,6,10,7,2,9,1,3,3,6,5,2,7,5,7,12,4,1,6,5,3,1,2,4,3,1,2,2,5,5,6,2,7,4,10,1,9,4,1,7,12,6,7,2,1,3,3,1,1,4,3,5,9,1,10,6,7,5,12,2,7,8,8,2,1,9,9,3,8,2,5,3,8,1,3,5,1,10,2,1,9,9,2,2,5,8,6,6,1,4,4,6,5,4,3,12,2,9,3,4,7,7,9,4,1,3,5,6,3,2,1,4,4,7,3,4,10,2,3,1,2,2,3,1,5,3,7,2,6,9,1,6,2,6,12,8,2,1,1,3,6,10,5,5,7,6,4,3,9,7,6,5,12,2,2,6,6,4,2,5,3,7,2,2,4,4,4,1,8,7,3,3,7,1,8,4,2,3,3,5,1,12,10,7,4,2,5,4,4,1,9,12,6,7,2,1,5,3,7,7,1,1,10,5,4,8,8,7,1,8,5,6,1,7,3,4,2,8,8,8,1,7,6,6,5,4,1,2,1,10,4,4,8,5,7,1,3,5,6,4,8,8,2,6,7,2,1,5,5,8,5,12,5,3,8,1,5,3,2,9,4,6,6,2,1,5,4,2,7,1,9,5,5,2,6,3,1,2,9,4,7,7,1,3,2,2,1,1,7,5,3,2,3,3,12,1,2,2,10,3,3,5,4,8,8,2,6,3,4,1,6,10,5,3,3,4,4,8,3,12,9,2,4,3,6,2,3,3,5,5,4,2,1,6,3,4,10,5,9,4,2,2,2,2,1,12,6,4,4,2,2,5,5,10,1,6,3,3,4,4,5,1,1,6,6,9,9,3,7,5,6,2,2,4,3,6,2,10,7,7,9,4,1,1,2,6,12,3,2,6,5,6,6,2,2,1,4,12,5,5,7,6,1,4,4,4,6,5,2,3,1,9,6,3,12,2,2,7,1,2,1,5,5,2,2,6,9,9,2,6,7,4,3,9,7,7,12,5,6,1,1,4,4,2,7,6 }),
                new ReelStrip(new int[] { 2,9,9,1,1,3,3,8,3,2,3,4,4,5,6,3,5,7,4,8,8,3,1,1,5,7,8,6,1,3,1,6,2,5,5,2,1,5,4,2,7,4,4,2,1,2,5,4,10,2,1,3,3,5,5,3,1,5,5,9,12,2,5,6,6,3,7,7,4,9,3,1,8,4,4,7,7,2,8,10,1,1,6,12,3,5,1,8,11,6,2,3,4,5,6,1,2,8,8,1,3,9,5,12,5,4,5,3,10,2,4,3,1,6,6,2,7,8,1,2,1,3,2,1,10,5,6,1,2,7,6,3,12,9,1,6,1,10,7,4,2,6,9,4,8,7,5,1,10,6,4,5,3,10,6,4,4,3,3,6,9,9,2,10,12,1,1,6,4,7,3,10,1,8,2,3,2,3,4,9,2,10,4,3,8,8,12,3,2,4,7,5,5,6,2,3,1,8,4,8,9,1,1,12,4,1,3,10,6,4,8,5,5,6,2,3,4,4,5,5,2,10,3,2,1,3,6,3,12,8,3,4,5,2,4,4,5,10,1,9,5,3,6,6,4,8,1,2,5,6,12,3,3,4,4,6,2,10,7,7,5,12,4,5,1,3,9,1,4,7,4,1,10,2,9,2,3,8,3,3,6,2,9,3,3,5,2,6,4,5,5,1,9,2,6,4,2,8,4,4,1,7,7,6,5,1,2,4,1,3,5,2,1,12,9,1,1,6,8,8,4,6,5,3,7,7,6,7,7,1,10,6,4,7,1,4,2,1,6,2,6,1,1,6,3,2,5,5,12,4,3,1,8,4,10,6,5,6,5,4,7,1,5,9,3,5,8,8,1,4,2,12,8,6,6,4,4,5,1,1,8,2,1,1,6,6,2,7,7,5,2,4,3,10,2,9,6,8,3,10,8,7,4,9,9,3,3,7,2,6,5,1,6,3,3,1,7,7,4,6,5,7,7,3,4,3,1,4,2,10,6,3,3,5,4,2,6,7,2,5,4,2,8,8,6,9,5,2,5,12,3,4,5,6,1,1,1,3,5,5,1,7,12,8,1,3,2,6,1,5,3,9,1,5,6,8,5,6,3,2,3,5,4,6,8,8,2,3,9,4,5,1,1,4,2,10,5,5,12,6,6,7,3,1,2,4,6,3,9,1,4,9,1,4,8,3,9,1,2,12,1,5,5,6,2,10,4,1,8,5 }),
                new ReelStrip(new int[] { 10,10,3,3,8,7,2,2,6,5,2,5,10,7,3,5,8,6,4,3,6,12,4,8,8,2,3,1,6,2,1,1,7,6,6,9,4,8,5,7,6,1,2,1,8,6,8,1,3,5,10,4,7,6,6,3,4,8,8,9,1,3,7,7,2,10,2,6,3,3,8,12,2,2,1,6,6,3,9,4,4,6,8,10,2,8,4,6,3,6,3,9,4,8,7,4,3,3,5,10,12,3,1,11,1,6,8,10,1,5,2,6,5,5,9,4,5,2,10,3,9,2,3,4,8,8,12,6,3,1,7,2,8,10,4,3,1,4,4,2,1,6,6,4,5,8,2,1,3,6,1,1,10,6,6,6,5,12,9,7,7,10,4,7,6,3,4,6,1,6,2,8,8,1,1,12,9,9,1,3,4,9,1,2,5,5,4,2,3,3,7,1,9,4,3,2,5,5,1,2,10,4,1,1,9,2,2,10,7,12,5,4,2,2,3,9,9,2,8,8,4,7,7,10,8,5,12,2,6,8,2,1,10,5,4,4,5,1,4,8,8,2,4,7,9,5,4,10,8,3,1,9,9,5,10,5,3,3,6,9,8,1,1,12,4,2,10,4,10,5,5,9,3,3,6,6,2,3,4,3,7,1,1,9,10,12,1,7,2,7,7,4,5,10,9,1,3,9,9,5,4,6,6,3,3,7,9,9,3,2,12,7,7,3,3,10,9,6,5,5,1,7,8,8,7,7,4,6,6,4,3,7,1,6,4,10,1,9,1,7,7,6,6,1,7,4,8,8,3,7,2,4,4,3,3,7,7,8,8,1,3,6,9,8,10,1,5,5,4,9,1,5,5,7,9,10,4,12,3,2,4,5,4,4,1,7,2,5,6,6,3,1,2,1,10,2,7,1,2,6,3,9,9,4,4,3,5,1,8,10,7,6,6,7,2,4,3,3,1,2,6,7,4,2,5,5,1,1,3,10,2,7,6,8,10,10,7,3,8,8,1,3,6,2,7,12,3,3,9,6,5,7,5,7,4,4,4,9,2,8,4,12,10,10,9,2,3,1,10,8,9,1,4,9,2,8,7,7,12,3,10,8,1,7,7,5,3,2,2,1,8,7,6,4,3,9,8,9,5,5,4,4,2,1,1,7,7,2,4,3,9,9,4,12,5,2,8,4,6,2,6,6,3,8,5,3,5,2,5,8 }),
                new ReelStrip(new int[] { 10,3,3,1,4,4,10,1,3,3,2,1,1,8,5,4,7,3,4,6,2,2,10,4,7,4,6,3,3,1,2,1,1,3,5,1,1,2,8,6,3,3,4,4,9,1,7,1,6,6,4,7,3,7,3,6,6,7,7,1,2,2,7,1,4,1,6,3,1,1,4,2,1,4,3,3,12,6,5,9,2,8,7,6,4,7,3,2,8,9,12,4,5,7,8,2,1,1,1,5,4,6,12,3,5,5,7,1,3,6,2,2,8,8,10,2,1,4,2,3,9,12,4,2,7,7,8,2,6,5,8,11,7,9,2,1,3,9,9,1,6,8,5,2,5,3,4,12,6,1,1,5,4,6,8,6,2,5,5,8,1,10,6,6,9,2,2,8,5,3,4,7,7,10,3,3,1,4,5,6,12,9,5,1,1,1,2,9,9,5,8,7,7,3,6,4,8,5,5,1,4,2,9,7,5,2,4,12,8,5,1,2,7,9,6,5,2,5,7,10,2,6,8,5,7,2,8,8,2,7,4,5,1,1,2,2,2,3,3,6,7,4,7,8,5,1,2,6,7,2,2,1,1,11,5,2,6,6,3,5,7,5,5,8,2,12,10,1,1,5,8,9,3,3,6,6,3,1,2,6,8,5,2,1,4,6,2,8,4,7,7,2,6,6,8,2,1,1,5,4,8,3,3,9,6,8,5,3,3,4,7,3,3,1,1,4,2,8,1,2,5,8,6,6,3,3,3,8,7,3,8,8,5,3,2,1,1,5,3,8,12,5,2,9,4,7,7,7,6,2,1,6,1,5,6,8,8,2,7,5,2,3,9,4,6,12,1,1,2,5,1,6,1,8,6,5,5,9,7,6,7,2,12,3,6,8,4,3,3,7,6,5,1,10,1,5,8,5,4,4,5,12,3,2,2,6,4,5,7,4,8,8,3,10,3,2,6,8,5,9,9,10,4,4,9,9,2,2,6,4,10,8,4,7,5,12,8,6,7,7,5,6,9,4,8,2,2,3,3,2,6,6,1,8,2,12,5,4,4,7,7,6,1,3,3,4,6,4,2,7,4,5,2,2,1,4,5,8,8,5,4,7,5,12,2,1,6,1,5,4,7,8,10,5,3,9,7,1,1,1,2,2,4,4,3,8,8,12,2,6,9,9,6,6,2,4,5,3,3,1,9,2,4,6,6,1,5,2,1,7 }),
                new ReelStrip(new int[] { 4,8,8,9,5,6,9,8,2,7,7,9,9,1,10,8,5,7,9,4,5,5,6,3,5,9,4,2,6,1,2,10,10,7,7,1,9,5,6,4,7,5,1,10,10,9,5,2,9,12,1,3,6,9,7,4,3,3,10,9,3,4,5,3,2,7,8,7,6,7,10,3,2,12,2,7,4,4,10,7,10,9,5,7,9,5,3,3,9,9,10,6,2,1,6,4,8,8,5,6,1,4,3,6,9,9,5,1,2,8,3,7,7,5,2,3,8,12,7,4,6,10,4,3,5,5,6,3,4,7,6,10,5,9,3,1,7,1,10,2,4,6,9,12,8,7,6,1,4,7,2,2,1,4,6,10,7,4,9,6,9,9,3,6,6,12,7,2,5,7,6,5,6,4,4,2,9,9,2,4,3,10,8,1,8,8,3,7,4,2,9,5,2,1,4,9,7,8,2,6,9,3,12,8,8,3,1,1,4,2,8,3,5,3,8,7,9,9,5,5,3,6,6,2,1,12,10,8,3,5,9,2,8,8,6,7,6,3,7,4,5,1,1,6,2,8,12,1,8,2,5,3,7,8,2,5,10,10,7,1,1,2,2,6,9,12,9,3,1,2,6,7,8,8,4,4,1,8,5,4,10,5,1,1,12,3,3,6,1,5,9,8,4,4,2,2,4,8,9,1,8,7,7,2,4,7,9,9,4,3,6,4,4,1,1,12,7,7,8,4,2,2,5,9,7,7,8,10,5,8,12,3,7,7,3,4,2,10,9,4,6,2,3,9,12,5,5,10,6,8,1,3,8,9,4,6,5,3,5,2,4,2,9,9,8,8,8,11,7,9,1,4,8,6,12,9,9,5,1,5,3,3,1,8,2,6,1,12,7,7,4,2,7,7,9,9,6,9,1,6,5,7,4,8,8,4,9,5,5,3,10,6,4,8,1,3,4,6,9,1,3,6,7,8,7,10,3,2,4,9,1,1,12,2,1,8,6,4,5,5,2,4,8,9,6,10,4,8,6,8,1,2,8,6,7,3,3,8,2,5,5,8,8,8,9,1,10,4,3,5,1,2,3,7,7,6,9,6,9,4,7,2,2,6,8,9,4,2,7,2,5,3,3,7,4,10,5,5,6,8,3,3,12,3,8,6,6,9,3,9,1,10,3,4,8,7,10,12,6,8,7,5,5,10,4,4,2,3,8,5 }),
                new ReelStrip(new int[] { 5,9,5,10,1,9,3,6,5,5,9,2,12,8,10,10,6,7,1,10,3,4,3,4,6,2,10,1,8,2,3,9,9,7,7,5,12,6,8,2,7,1,10,6,9,8,4,1,1,3,2,3,8,4,7,10,3,9,5,10,3,7,1,8,5,5,7,7,1,6,7,9,6,2,9,7,12,2,10,9,3,8,10,6,6,4,3,4,8,10,5,12,2,4,8,3,4,8,1,1,2,8,3,8,9,9,6,2,6,10,3,2,8,8,5,12,9,2,1,1,9,6,10,9,1,4,8,4,5,1,1,10,9,6,3,8,9,1,9,4,12,8,1,5,6,7,2,3,9,6,1,8,2,4,8,12,7,5,1,8,4,10,3,5,9,9,10,4,8,7,2,10,3,4,4,5,5,9,6,3,7,5,5,2,6,6,4,7,9,1,8,4,12,1,5,10,8,6,10,6,6,3,7,9,5,5,10,7,8,6,6,7,4,9,5,7,12,4,4,5,6,7,8,1,4,3,1,8,9,4,2,9,1,6,10,9,6,3,6,5,4,8,3,8,5,6,3,5,4,5,6,5,9,6,5,3,10,5,7,2,4,9,9,8,4,4,10,10,2,1,8,9,5,4,9,7,2,6,7,4,4,7,8,9,6,5,3,8,11,4,8,3,10,5,8,9,2,6,12,2,3,7,7,2,10,8,1,3,5,2,4,8,7,9,5,2,3,6,6,10,5,8,4,2,7,7,1,7,12,5,9,8,10,7,3,2,1,1,5,5,8,1,1,9,4,9,4,4,5,8,10,7,5,1,6,8,8,9,12,1,5,7,9,2,7,4,6,6,3,1,4,7,6,8,3,1,9,4,4,12,9,1,9,3,10,8,2,7,7,4,9,5,7,6,1,10,8,6,2,2,12,7,1,7,3,6,2,1,7,3,8,8,7,5,7,3,10,8,1,2,3,12,7,2,9,9,3,9,7,7,6,8,8,4,1,7,8,10,4,4,1,7,6,2,8,6,5,7,10,3,2,12,6,8,9,7,4,10,1,6,5,5,6,6,11,2,7,6,3,4,2,1,12,9,10,6,2,8,8,5,10,4,1,8,2,6,10,2,2,1,4,8,12,9,10,9,4,1,9,7,5,9,2,3,5,8,8,2,12,10,9,9,7,5,3,2,1,3,4,6,9,12,4,5,1,4,4,10,6,9 })
            }
        };

        public static readonly GridSet BaseGameTopReelGridSet = new()
        {
            Name = DefaultName,
            Strips = new[]
            {
                new ReelStrip(new int[] { 1,1,5,9,8,10,7,2,5,9,3,6,3,1,8,2,7,3,1,2,1,8,8,1,7,7,2,2,1,2,7,8,2,2,8,9,1,6,2,9,1,1,5,1,3,6,7,4,9,8,1,5,8,7,1,2,6,5,7,2,1,7,5,4,8,10,8,2,1,9,2,7,9,3,7,8,10,1,3,3,8,2,1,4,6,2,2,7,7,1,4,3,6,9,2,7,7,1,3,1,8,11,1,6,6,7,2,1,7,7,4,9,1,10,2,1,8,2,5,6,7,1,2,5,1,3,3,7,3,2,4,6,8,2,9,5,2,4,7,4,3,2,4,2,2,5,6,1,9,6,2,2,1,5,6,6,2,8,2,7,2,9,1,1,3,2,5,8,10,4,6,2,1,2,2,7,4,7,8,2,6,1,4,5,5,3,4,5,10,5,6,1,9,1,4,5,9,9,6,10,3,6,5,3,1,6,6,5,9,7,10,8,2,1,4,5,8,4,6,3,1,5,7,7,2,6,8,1,6,4,3,5,7,1,6,3,5,3,1,6,4,1,5,9,3,9,8,3,3,6,4,3,2,3,8,2,1,8,10,6,2,2,6,1,5,7,10,4,3,5,2,10,1,6,1,4,9,9,4,8,3,9,10,4,1,2,5,10,6,9,1,3,8,5,8,1,7,1,5,8,1,7,4,1,9,10,10,3,6,6,3,2,1,5,9,10,8,9,1,3,5,7,4,10,5,8,5,3,5,1,5,7,8,3,3,6,4,8,2,6,5,2,9,4,5,4,6,1,6,4,7,7,3,1,8,5,2,6,9,1,3,9,4,2,10,1,8,2,3,4,1,3,5,3,2,3,6,4,1,10,2,6,9,9,6,4,8,8,6,1,3,4,8,10,4,5,3,4,3,2,8,1,3,1,4,4,3,6,2,6,8,4,10,4,2,1,9,2,4,9,5,8,4,1,2,2,6,1,4,7,8,3,6,3,2,3,1,7,6,3,6,7,3,5,2,4,3,1,2,4,3,7,6,2,5,3,9,1,6,2,8,1,7,9,4,4,3,4,6,3,8,2,9,5,4,5,2,3,1,4,6,7,5,2,7,1,6,4,3,6,5,2,3,5,9,1,3,2,1,1,2,3,5,6,4,5,1,8,1,5,7,2,1,5,3,3,2,10,4,9,4,6,2,8,1,3,2,7,10,6 })
            }
        };

        public static readonly GridSet FreeSpinGridSet = new()
        {
            Name = DefaultName,
            Strips = new[]
            {
                new ReelStrip(new int[] { 4,9,5,8,2,6,9,7,1,3,1,5,10,1,1,2,2,8,4,3,7,6,8,10,6,4,1,3,5,8,8,9,6,8,8,8,10,6,5,7,8,3,4,6,9,5,1,4,2,1,3,4,5,6,8,1,2,6,7,3,5,1,2,5,4,8,7,8,3,1,4,7,7,2,1,8,2,6,3,1,2,5,6,8,4,6,10,7,2,9,1,3,3,6,5,2,7,5,7,1,4,1,6,5,3,1,2,4,3,1,2,2,5,5,6,2,7,4,10,1,9,4,1,7,12,6,7,2,1,3,3,1,1,4,3,5,9,1,10,6,7,5,12,2,7,8,8,2,1,9,9,3,8,2,5,3,8,1,3,5,1,10,2,1,9,9,2,2,5,8,6,6,1,4,4,6,5,4,3,1,2,9,3,4,7,7,9,4,1,3,5,6,3,2,1,4,4,7,3,4,10,2,3,1,2,2,3,1,5,3,7,2,6,9,1,6,2,6,2,8,2,1,1,3,6,10,5,5,7,6,4,3,9,7,6,5,12,2,2,6,6,4,2,5,3,7,2,2,4,4,4,1,8,7,3,3,7,1,8,4,2,3,3,5,1,1,10,7,4,2,5,4,4,1,9,12,6,7,2,1,5,3,7,7,1,1,10,5,4,8,8,7,1,8,5,6,1,7,3,4,2,8,8,8,1,7,6,6,5,4,1,2,1,10,4,4,8,5,7,1,3,5,6,4,8,8,2,6,7,2,1,5,5,8,5,1,5,3,8,1,5,3,2,9,4,6,6,2,1,5,4,2,7,1,9,5,5,2,6,3,1,2,9,4,7,7,1,3,2,2,1,1,7,5,3,2,3,3,1,1,2,2,10,3,3,5,4,8,8,2,6,3,4,1,6,10,5,3,3,4,4,8,3,4,9,2,4,3,6,2,3,3,5,5,4,2,1,6,3,4,10,5,9,4,2,2,2,2,1,12,6,4,4,2,2,5,5,10,1,6,3,3,4,4,5,1,1,6,6,9,9,3,7,5,6,2,2,4,3,6,2,10,7,7,9,4,1,1,2,6,12,3,2,6,5,6,6,2,2,1,4,1,5,5,7,6,1,4,4,4,6,5,2,3,1,9,6,3,12,2,2,7,1,2,1,5,5,2,2,6,9,9,2,6,7,4,3,9,7,7,12,5,6,1,1,4,4,2,7,6 }),
                new ReelStrip(new int[] { 2,9,9,1,1,3,3,8,3,2,3,4,4,5,6,3,5,7,4,8,8,3,1,1,5,7,8,6,1,3,1,6,2,5,5,2,1,5,4,2,7,4,4,2,1,2,5,4,10,2,1,3,3,5,5,3,1,5,5,9,12,2,5,6,6,3,7,7,4,9,3,1,8,4,4,7,7,2,8,10,1,1,6,12,3,5,1,8,11,6,2,3,4,5,6,1,2,8,8,1,3,9,5,2,5,4,5,3,10,2,4,3,1,6,6,2,7,8,1,2,1,3,2,1,10,5,6,1,2,7,6,3,6,9,1,6,1,10,7,4,2,6,9,4,8,7,5,1,10,6,4,5,3,10,6,4,4,3,3,6,9,9,2,10,12,1,1,6,4,7,3,10,1,8,2,3,2,3,4,9,2,10,4,3,8,8,12,3,2,4,7,5,5,6,2,3,1,8,4,8,9,1,1,2,4,1,3,10,6,4,8,5,5,6,2,3,4,4,5,5,2,10,3,2,1,3,6,3,1,8,3,4,5,2,4,4,5,10,1,9,5,3,6,6,4,8,1,2,5,6,1,3,3,4,4,6,2,10,7,7,5,1,4,5,1,3,9,1,4,7,4,1,10,2,9,2,3,8,3,3,6,2,9,3,3,5,2,6,4,5,5,1,9,2,6,4,2,8,4,4,1,7,7,6,5,1,2,4,1,3,5,2,1,12,9,1,1,6,8,8,4,6,5,3,7,7,6,7,7,1,10,6,4,7,1,4,2,1,6,2,6,1,1,6,3,2,5,5,4,4,3,1,8,4,10,6,5,6,5,4,7,1,5,9,3,5,8,8,1,4,2,12,8,6,6,4,4,5,1,1,8,2,1,1,6,6,2,7,7,5,2,4,3,10,2,9,6,8,3,10,8,7,4,9,9,3,3,7,2,6,5,1,6,3,3,1,7,7,4,6,5,7,7,3,4,3,1,4,2,10,6,3,3,5,4,2,6,7,2,5,4,2,8,8,6,9,5,2,5,4,3,4,5,6,1,1,1,3,5,5,1,7,1,8,1,3,2,6,1,5,3,9,1,5,6,8,5,6,3,2,3,5,4,6,8,8,2,3,9,4,5,1,1,4,2,10,5,5,2,6,6,7,3,1,2,4,6,3,9,1,4,9,1,4,8,3,9,1,2,4,1,5,5,6,2,10,4,1,8,5 }),
                new ReelStrip(new int[] { 10,10,3,3,8,7,2,2,6,5,2,5,10,7,3,5,8,6,4,3,6,1,4,8,8,2,3,1,6,2,1,1,7,6,6,9,4,8,5,7,6,1,2,1,8,6,8,1,3,5,10,4,7,6,6,3,4,8,8,9,1,3,7,7,2,10,2,6,3,3,8,1,2,2,1,6,6,3,9,4,4,6,8,10,2,8,4,6,3,6,3,9,4,8,7,4,3,3,5,10,2,3,1,11,1,6,8,10,1,5,2,6,5,5,9,4,5,2,10,3,9,2,3,4,8,8,12,6,3,1,7,2,8,10,4,3,1,4,4,2,1,6,6,4,5,8,2,1,3,6,1,1,10,6,6,6,5,12,9,7,7,10,4,7,6,3,4,6,1,6,2,8,8,1,1,2,9,9,1,3,4,9,1,2,5,5,4,2,3,3,7,1,9,4,3,2,5,5,1,2,10,4,1,1,9,2,2,10,7,12,5,4,2,2,3,9,9,2,8,8,4,7,7,10,8,5,1,2,6,8,2,1,10,5,4,4,5,1,4,8,8,2,4,7,9,5,4,10,8,3,1,9,9,5,10,5,3,3,6,9,8,1,1,2,4,2,10,4,10,5,5,9,3,3,6,6,2,3,4,3,7,1,1,9,10,12,1,7,2,7,7,4,5,10,9,1,3,9,9,5,4,6,6,3,3,7,9,9,3,2,5,7,7,3,3,10,9,6,5,5,1,7,8,8,7,7,4,6,6,4,3,7,1,6,4,10,1,9,1,7,7,6,6,1,7,4,8,8,3,7,2,4,4,3,3,7,7,8,8,1,3,6,9,8,10,1,5,5,4,9,1,5,5,7,9,10,4,1,3,2,4,5,4,4,1,7,2,5,6,6,3,1,2,1,10,2,7,1,2,6,3,9,9,4,4,3,5,1,8,10,7,6,6,7,2,4,3,3,1,2,6,7,4,2,5,5,1,1,3,10,2,7,6,8,10,10,7,3,8,8,1,3,6,2,7,12,3,3,9,6,5,7,5,7,4,4,4,9,2,8,4,12,10,10,9,2,3,1,10,8,9,1,4,9,2,8,7,7,2,3,10,8,1,7,7,5,3,2,2,1,8,7,6,4,3,9,8,9,5,5,4,4,2,1,1,7,7,2,4,3,9,9,4,3,5,2,8,4,6,2,6,6,3,8,5,3,5,2,5,8 }),
                new ReelStrip(new int[] { 10,3,3,1,4,4,10,1,3,3,2,1,1,8,1,4,7,3,4,6,2,2,10,4,7,4,6,3,3,1,2,1,1,3,5,1,1,2,8,6,3,3,4,4,9,1,7,1,6,6,4,7,3,7,3,6,6,7,7,1,2,2,7,1,4,1,6,3,1,1,4,2,1,4,3,3,1,6,5,9,2,8,7,6,4,7,3,2,8,9,1,4,5,7,8,2,1,1,1,5,4,6,2,3,5,5,7,1,3,6,2,2,8,8,10,2,1,4,2,3,9,5,4,2,7,7,8,2,6,5,8,11,7,9,2,1,3,9,9,1,6,8,5,2,5,3,4,2,6,1,1,5,4,6,8,6,2,5,5,8,1,10,6,6,9,2,2,8,5,3,4,7,7,10,3,3,1,4,5,6,2,9,5,1,1,1,2,9,9,5,8,7,7,3,6,4,8,5,5,1,4,2,9,7,5,2,4,1,8,5,1,2,7,9,6,5,2,5,7,10,2,6,8,5,7,2,8,8,2,7,4,5,1,1,2,2,2,3,3,6,7,4,7,8,5,1,2,6,7,2,2,1,1,11,5,2,6,6,3,5,7,5,5,8,2,4,10,1,1,5,8,9,3,3,6,6,3,1,2,6,8,5,2,1,4,6,2,8,4,7,7,2,6,6,8,2,1,1,5,4,8,3,3,9,6,8,5,3,3,4,7,3,3,1,1,4,2,8,1,2,5,8,6,6,3,3,3,8,7,3,8,8,5,3,2,1,1,5,3,8,12,5,2,9,4,7,7,7,6,2,1,6,1,5,6,8,8,2,7,5,2,3,9,4,6,2,1,1,2,5,1,6,1,8,6,5,5,9,7,6,7,2,2,3,6,8,4,3,3,7,6,5,1,10,1,5,8,5,4,4,5,12,3,2,2,6,4,5,7,4,8,8,3,10,3,2,6,8,5,9,9,10,4,4,9,9,2,2,6,4,10,8,4,7,5,2,8,6,7,7,5,6,9,4,8,2,2,3,3,2,6,6,1,8,2,1,5,4,4,7,7,6,1,3,3,4,6,4,2,7,4,5,2,2,1,4,5,8,8,5,4,7,5,1,2,1,6,1,5,4,7,8,10,5,3,9,7,1,1,1,2,2,4,4,3,8,8,1,2,6,9,9,6,6,2,4,5,3,3,1,9,2,4,6,6,1,5,2,1,7 }),
                new ReelStrip(new int[] { 4,8,8,9,5,6,9,8,2,7,7,9,9,1,10,1,5,7,9,4,5,5,6,3,5,9,4,2,6,1,2,10,10,7,7,1,9,5,6,4,7,5,1,10,10,9,5,2,9,12,1,3,6,9,7,4,3,3,10,9,3,4,5,3,2,7,8,7,6,7,10,3,2,1,2,7,4,4,10,7,10,9,5,7,9,5,3,3,9,9,10,6,2,1,6,4,8,8,5,6,1,4,3,6,9,9,5,1,2,8,3,7,7,5,2,3,8,12,7,4,6,10,4,3,5,5,6,3,4,7,6,10,5,9,3,1,7,1,10,2,4,6,9,4,8,7,6,1,4,7,2,2,1,4,6,10,7,4,9,6,9,9,3,6,6,12,7,2,5,7,6,5,6,4,4,2,9,9,2,4,3,10,8,1,8,8,3,7,4,2,9,5,2,1,4,9,7,8,2,6,9,3,12,8,8,3,1,1,4,2,8,3,5,3,8,7,9,9,5,5,3,6,6,2,1,2,10,8,3,5,9,2,8,8,6,7,6,3,7,4,5,1,1,6,2,8,12,1,8,2,5,3,7,8,2,5,10,10,7,1,1,2,2,6,9,1,9,3,1,2,6,7,8,8,4,4,1,8,5,4,10,5,1,1,5,3,3,6,1,5,9,8,4,4,2,2,4,8,9,1,8,7,7,2,4,7,9,9,4,3,6,4,4,1,1,12,7,7,8,4,2,2,5,9,7,7,8,10,5,8,2,3,7,7,3,4,2,10,9,4,6,2,3,9,1,5,5,10,6,8,1,3,8,9,4,6,5,3,5,2,4,2,9,9,8,8,8,11,7,9,1,4,8,6,6,9,9,5,1,5,3,3,1,8,2,6,1,12,7,7,4,2,7,7,9,9,6,9,1,6,5,7,4,8,8,4,9,5,5,3,10,6,4,8,1,3,4,6,9,1,3,6,7,8,7,10,3,2,4,9,1,1,2,2,1,8,6,4,5,5,2,4,8,9,6,10,4,8,6,8,1,2,8,6,7,3,3,8,2,5,5,8,8,8,9,1,10,4,3,5,1,2,3,7,7,6,9,6,9,4,7,2,2,6,8,9,4,2,7,2,5,3,3,7,4,10,5,5,6,8,3,3,4,3,8,6,6,9,3,9,1,10,3,4,8,7,10,7,6,8,7,5,5,10,4,4,2,3,8,5 }),
                new ReelStrip(new int[] { 5,9,5,10,1,9,3,6,5,5,9,2,2,8,10,10,6,7,1,10,3,4,3,4,6,2,10,1,8,2,3,9,9,7,7,5,3,6,8,2,7,1,10,6,9,8,4,1,1,3,2,3,8,4,7,10,3,9,5,10,3,7,1,8,5,5,7,7,1,6,7,9,6,2,9,7,1,2,10,9,3,8,10,6,6,4,3,4,8,10,5,12,2,4,8,3,4,8,1,1,2,8,3,8,9,9,6,2,6,10,3,2,8,8,5,3,9,2,1,1,9,6,10,9,1,4,8,4,5,1,1,10,9,6,3,8,9,1,9,4,12,8,1,5,6,7,2,3,9,6,1,8,2,4,8,12,7,5,1,8,4,10,3,5,9,9,10,4,8,7,2,10,3,4,4,5,5,9,6,3,7,5,5,2,6,6,4,7,9,1,8,4,12,1,5,10,8,6,10,6,6,3,7,9,5,5,10,7,8,6,6,7,4,9,5,7,1,4,4,5,6,7,8,1,4,3,1,8,9,4,2,9,1,6,10,9,6,3,6,5,4,8,3,8,5,6,3,5,4,5,6,5,9,6,5,3,10,5,7,2,4,9,9,8,4,4,10,10,2,1,8,9,5,4,9,7,2,6,7,4,4,7,8,9,6,5,3,8,11,4,8,3,10,5,8,9,2,6,12,2,3,7,7,2,10,8,1,3,5,2,4,8,7,9,5,2,3,6,6,10,5,8,4,2,7,7,1,7,1,5,9,8,10,7,3,2,1,1,5,5,8,1,1,9,4,9,4,4,5,8,10,7,5,1,6,8,8,9,12,1,5,7,9,2,7,4,6,6,3,1,4,7,6,8,3,1,9,4,4,1,9,1,9,3,10,8,2,7,7,4,9,5,7,6,1,10,8,6,2,2,6,7,1,7,3,6,2,1,7,3,8,8,7,5,7,3,10,8,1,2,3,12,7,2,9,9,3,9,7,7,6,8,8,4,1,7,8,10,4,4,1,7,6,2,8,6,5,7,10,3,2,7,6,8,9,7,4,10,1,6,5,5,6,6,11,2,7,6,3,4,2,1,12,9,10,6,2,8,8,5,10,4,1,8,2,6,10,2,2,1,4,8,5,9,10,9,4,1,9,7,5,9,2,3,5,8,8,2,6,10,9,9,7,5,3,2,1,3,4,6,9,12,4,5,1,4,4,10,6,9 }),
            }
        };

        public static readonly GridSet FreeSpinTopReelGridSet = new()
        {
            Name = DefaultName,
            Strips = new[]
            {
                new ReelStrip(new int[] { 1,1,5,9,8,10,7,2,5,9,3,6,3,1,8,2,7,3,1,2,1,8,8,1,7,7,2,2,1,2,7,8,2,2,8,9,1,6,2,9,1,1,5,1,3,6,7,4,9,8,1,5,8,7,1,2,6,5,7,2,1,7,5,4,8,10,8,2,1,9,2,7,9,3,7,8,10,1,3,3,8,2,1,4,6,2,2,7,7,1,4,3,6,9,2,7,7,1,3,1,8,11,1,6,6,7,2,1,7,7,4,9,1,10,2,1,8,2,5,6,7,1,2,5,1,3,3,7,3,2,4,6,8,2,9,5,2,4,7,4,3,2,4,2,2,5,6,1,9,6,2,2,1,5,6,6,2,8,2,7,2,9,1,1,3,2,5,8,10,4,6,2,1,2,2,7,4,7,8,2,6,1,4,5,5,3,4,5,10,5,6,1,9,1,4,5,9,9,6,10,3,6,5,3,1,6,6,5,9,7,10,8,2,1,4,5,8,4,6,3,1,5,7,7,2,6,8,1,6,4,3,5,7,1,6,3,5,3,1,6,4,1,5,9,3,9,8,3,3,6,4,3,2,3,8,2,1,8,10,6,2,2,6,1,5,7,10,4,3,5,2,10,1,6,1,4,9,9,4,8,3,9,10,4,1,2,5,10,6,9,1,3,8,5,8,1,7,1,5,8,1,7,4,1,9,10,10,3,6,6,3,2,1,5,9,10,8,9,1,3,5,7,4,10,5,8,5,3,5,1,5,7,8,3,3,6,4,8,2,6,5,2,9,4,5,4,6,1,6,4,7,7,3,1,8,5,2,6,9,1,3,9,4,2,10,1,8,2,3,4,1,3,5,3,2,3,6,4,1,10,2,6,9,9,6,4,8,8,6,1,3,4,8,10,4,5,3,4,3,2,8,1,3,1,4,4,3,6,2,6,8,4,10,4,2,1,9,2,4,9,5,8,4,1,2,2,6,1,4,7,8,3,6,3,2,3,1,7,6,3,6,7,3,5,2,4,3,1,2,4,3,7,6,2,5,3,9,1,6,2,8,1,7,9,4,4,3,4,6,3,8,2,9,5,4,5,2,3,1,4,6,7,5,2,7,1,6,4,3,6,5,2,3,5,9,1,3,2,1,1,2,3,5,6,4,5,1,8,1,5,7,2,1,5,3,3,2,10,4,9,4,6,2,8,1,3,2,7,10,6 }),
            }
        };

        public static readonly List<SymbolPays> PayTable = new()
        {
            new(1, 3, 2),
            new(1, 4, 4),
            new(1, 5, 8),
            new(1, 6, 20),

            new(2, 3, 2),
            new(2, 4, 4),
            new(2, 5, 8),
            new(2, 6, 20),

            new(3, 3, 2),
            new(3, 4, 4),
            new(3, 5, 8),
            new(3, 6, 20),

            new(4, 3, 4),
            new(4, 4, 8),
            new(4, 5, 12),
            new(4, 6, 30),

            new(5, 3, 4),
            new(5, 4, 8),
            new(5, 5, 12),
            new(5, 6, 30),

            new(6, 3, 4),
            new(6, 4, 8),
            new(6, 5, 12),
            new(6, 6, 30),

            new(7, 3, 6),
            new(7, 4, 10),
            new(7, 5, 16),
            new(7, 6, 40),

            new(8, 3, 6),
            new(8, 4, 10),
            new(8, 5, 20),
            new(8, 6, 50),

            new(9, 3, 20),
            new(9, 4, 40),
            new(9, 5, 50),
            new(9, 6, 100),

            new(10, 2, 20),
            new(10, 3, 40),
            new(10, 4, 200),
            new(10, 5, 400),
            new(10, 6, 1200)
        };
    }
}
