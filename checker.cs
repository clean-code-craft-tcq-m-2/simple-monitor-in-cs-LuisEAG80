using System;
using System.Diagnostics;

namespace batteryChecker
{
    class Checker
    {
        static void ExpectTrue(bool expression)
        {
            if (!expression)
            {
                Console.WriteLine("Expected true, but got false");
                Environment.Exit(1);
            }
        }
        static void ExpectFalse(bool expression)
        {
            if (expression)
            {
                Console.WriteLine("Expected false, but got true");
                Environment.Exit(1);
            }
        }
        static int Main()
        {
            // Temperature Test
            ExpectFalse(BatteryChecker.BatteryIsOk(ValidRanges.TemperatureRange.Min - 0.1f, 70, 0.7f));
            ExpectTrue(BatteryChecker.BatteryIsOk(ValidRanges.TemperatureRange.Min, 70, 0.7f));
            ExpectTrue(BatteryChecker.BatteryIsOk(ValidRanges.TemperatureRange.Min + 0.1f, 70, 0.7f));
            ExpectTrue(BatteryChecker.BatteryIsOk(ValidRanges.TemperatureRange.Max - 0.1f, 70, 0.7f));
            ExpectTrue(BatteryChecker.BatteryIsOk(ValidRanges.TemperatureRange.Max, 70, 0.7f));
            ExpectFalse(BatteryChecker.BatteryIsOk(ValidRanges.TemperatureRange.Max + 0.1f, 70, 0.7f));
            // State of Charge Test
            ExpectFalse(BatteryChecker.BatteryIsOk(25, ValidRanges.StateOfChargeRange.Min - 0.1f, 0.7f));
            ExpectTrue(BatteryChecker.BatteryIsOk(25, ValidRanges.StateOfChargeRange.Min, 0.7f));
            ExpectTrue(BatteryChecker.BatteryIsOk(25, ValidRanges.StateOfChargeRange.Min + 0.1f, 0.7f));
            ExpectTrue(BatteryChecker.BatteryIsOk(25, ValidRanges.StateOfChargeRange.Max - 0.1f, 0.7f));
            ExpectTrue(BatteryChecker.BatteryIsOk(25, ValidRanges.StateOfChargeRange.Max, 0.7f));
            ExpectFalse(BatteryChecker.BatteryIsOk(25, ValidRanges.StateOfChargeRange.Max + 0.1f, 0.7f));
            // Charge Rate Test
            ExpectFalse(BatteryChecker.BatteryIsOk(25, 70, ValidRanges.ChargeRateRange.Min - 0.1f));
            ExpectTrue(BatteryChecker.BatteryIsOk(25, 70, ValidRanges.ChargeRateRange.Min));
            ExpectTrue(BatteryChecker.BatteryIsOk(25, 70, ValidRanges.ChargeRateRange.Min + 0.1f));
            ExpectTrue(BatteryChecker.BatteryIsOk(25, 70, ValidRanges.ChargeRateRange.Max - 0.1f));
            ExpectTrue(BatteryChecker.BatteryIsOk(25, 70, ValidRanges.ChargeRateRange.Max));
            ExpectFalse(BatteryChecker.BatteryIsOk(25, 70, ValidRanges.ChargeRateRange.Max + 0.1f));
            Console.WriteLine("All ok");
            return 0;
        }
    }
}