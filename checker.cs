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
            StatusMessages.CurrentLanguage = LanguagesEnum.English;
            // Temperature Test
            ExpectFalse(BatteryChecker.BatteryIsOk(new CelciusTemperature(ValidRanges.TemperatureRange.Min - 0.1f), new StateOfCharge(70), new ChargeRate(0.7f)));
            ExpectTrue(BatteryChecker.BatteryIsOk(new CelciusTemperature(ValidRanges.TemperatureRange.Min), new StateOfCharge(70), new ChargeRate(0.7f)));
            ExpectTrue(BatteryChecker.BatteryIsOk(new CelciusTemperature(ValidRanges.TemperatureRange.Min + 0.1f), new StateOfCharge(70), new ChargeRate(0.7f)));
            ExpectTrue(BatteryChecker.BatteryIsOk(new CelciusTemperature(ValidRanges.TemperatureRange.Max - 0.1f), new StateOfCharge(70), new ChargeRate(0.7f)));
            ExpectTrue(BatteryChecker.BatteryIsOk(new CelciusTemperature(ValidRanges.TemperatureRange.Max), new StateOfCharge(70), new ChargeRate(0.7f)));
            ExpectFalse(BatteryChecker.BatteryIsOk(new CelciusTemperature(ValidRanges.TemperatureRange.Max + 0.1f), new StateOfCharge(70), new ChargeRate(0.7f)));

            ExpectFalse(BatteryChecker.BatteryIsOk(new FahrenheitTemperature(32 - 0.1f), new StateOfCharge(70), new ChargeRate(0.7f)));
            ExpectTrue(BatteryChecker.BatteryIsOk(new FahrenheitTemperature(32), new StateOfCharge(70), new ChargeRate(0.7f)));
            ExpectTrue(BatteryChecker.BatteryIsOk(new FahrenheitTemperature(32 + 0.1f), new StateOfCharge(70), new ChargeRate(0.7f)));
            ExpectTrue(BatteryChecker.BatteryIsOk(new FahrenheitTemperature(113 - 0.1f), new StateOfCharge(70), new ChargeRate(0.7f)));
            ExpectFalse(BatteryChecker.BatteryIsOk(new FahrenheitTemperature(113), new StateOfCharge(70), new ChargeRate(0.7f)));
            ExpectFalse(BatteryChecker.BatteryIsOk(new FahrenheitTemperature(113 + 0.1f), new StateOfCharge(70), new ChargeRate(0.7f)));

            // State of Charge Test
            ExpectFalse(BatteryChecker.BatteryIsOk(new CelciusTemperature(25), new StateOfCharge(ValidRanges.StateOfChargeRange.Min - 0.1f), new ChargeRate(0.7f)));
            ExpectTrue(BatteryChecker.BatteryIsOk(new CelciusTemperature(25), new StateOfCharge(ValidRanges.StateOfChargeRange.Min), new ChargeRate(0.7f)));
            ExpectTrue(BatteryChecker.BatteryIsOk(new CelciusTemperature(25), new StateOfCharge(ValidRanges.StateOfChargeRange.Min + 0.1f), new ChargeRate(0.7f)));
            ExpectTrue(BatteryChecker.BatteryIsOk(new CelciusTemperature(25), new StateOfCharge(ValidRanges.StateOfChargeRange.Max - 0.1f), new ChargeRate(0.7f)));
            ExpectTrue(BatteryChecker.BatteryIsOk(new CelciusTemperature(25), new StateOfCharge(ValidRanges.StateOfChargeRange.Max), new ChargeRate(0.7f)));
            ExpectFalse(BatteryChecker.BatteryIsOk(new CelciusTemperature(25), new StateOfCharge(ValidRanges.StateOfChargeRange.Max + 0.1f), new ChargeRate(0.7f)));
            // Charge Rate Test
            ExpectFalse(BatteryChecker.BatteryIsOk(new CelciusTemperature(25), new StateOfCharge(70), new ChargeRate(ValidRanges.ChargeRateRange.Min - 0.1f)));
            ExpectTrue(BatteryChecker.BatteryIsOk(new CelciusTemperature(25), new StateOfCharge(70), new ChargeRate(ValidRanges.ChargeRateRange.Min)));
            ExpectTrue(BatteryChecker.BatteryIsOk(new CelciusTemperature(25), new StateOfCharge(70), new ChargeRate(ValidRanges.ChargeRateRange.Min + 0.1f)));
            ExpectTrue(BatteryChecker.BatteryIsOk(new CelciusTemperature(25), new StateOfCharge(70), new ChargeRate(ValidRanges.ChargeRateRange.Max - 0.1f)));
            ExpectTrue(BatteryChecker.BatteryIsOk(new CelciusTemperature(25), new StateOfCharge(70), new ChargeRate(ValidRanges.ChargeRateRange.Max)));
            ExpectFalse(BatteryChecker.BatteryIsOk(new CelciusTemperature(25), new StateOfCharge(70), new ChargeRate(ValidRanges.ChargeRateRange.Max + 0.1f)));

            // Test languages English
            StatusMessages.CurrentLanguage = LanguagesEnum.English;
            ExpectTrue(BatteryChecker.outOfRangeMessage(StatusType.Temperature, isLow: true) == "Temperature out of range is low");
            ExpectTrue(BatteryChecker.outOfRangeMessage(StatusType.Temperature, isLow: false) == "Temperature out of range is high");
            ExpectTrue(BatteryChecker.outOfRangeMessage(StatusType.StateOfCharge, isLow: true) == "State of Charge out of range is low");
            ExpectTrue(BatteryChecker.outOfRangeMessage(StatusType.StateOfCharge, isLow: false) == "State of Charge out of range is high");
            ExpectTrue(BatteryChecker.outOfRangeMessage(StatusType.ChargeRate, isLow: true) == "Charge Rate out of range is low");
            ExpectTrue(BatteryChecker.outOfRangeMessage(StatusType.ChargeRate, isLow: false) == "Charge Rate out of range is high");

            // Test languages German
            StatusMessages.CurrentLanguage = LanguagesEnum.German;
            ExpectTrue(BatteryChecker.outOfRangeMessage(StatusType.Temperature, isLow: true) == "Temperatur ausser reichweite ist niedrig");
            ExpectTrue(BatteryChecker.outOfRangeMessage(StatusType.Temperature, isLow: false) == "Temperatur ausser reichweite ist hoch");
            ExpectTrue(BatteryChecker.outOfRangeMessage(StatusType.StateOfCharge, isLow: true) == "Ladezustand ausser reichweite ist niedrig");
            ExpectTrue(BatteryChecker.outOfRangeMessage(StatusType.StateOfCharge, isLow: false) == "Ladezustand ausser reichweite ist hoch");
            ExpectTrue(BatteryChecker.outOfRangeMessage(StatusType.ChargeRate, isLow: true) == "Laderate ausser reichweite ist niedrig");
            ExpectTrue(BatteryChecker.outOfRangeMessage(StatusType.ChargeRate, isLow: false) == "Laderate ausser reichweite ist hoch");

            Console.WriteLine("All ok");
            return 0;
        }
    }
}