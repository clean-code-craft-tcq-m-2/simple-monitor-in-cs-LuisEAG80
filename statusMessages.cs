using System;
using System.Collections.Generic;
using System.Linq;

namespace batteryChecker
{
    public enum LanguagesEnum
    {
        English,
        German,
        Spanish
    }

    public static class StatusMessages
    {
        public static LanguagesEnum CurrentLanguage = LanguagesEnum.English;

        public static Dictionary<LanguagesEnum, Dictionary<string, string>> Languages =
            new Dictionary<LanguagesEnum, Dictionary<string, string>>
            {
                {
                    LanguagesEnum.English,
                    new Dictionary<string, string>
                    {
                        { "High", "is high" },
                        { "Low", "is low" },
                        { "OutOfRange", "out of range" },
                        { "Temperature", "Temperature" },
                        { "StateOfCharge", "State of Charge" },
                        { "ChargeRate", "Charge Rate" },
                        { "Warning", "Warning" }
                    }
                },
                {
                    LanguagesEnum.Spanish,
                    new Dictionary<string, string>
                    {
                        { "High", "es alto" },
                        { "Low", "es bajo" },
                        { "OutOfRange", "fuera de rango" },
                        { "Temperature", "Temperatura" },
                        { "StateOfCharge", "Estado de Carga" },
                        { "ChargeRate", "Tasa de Carga" },
                        { "Warning", "Advertencia" }
                    }
                },
                {
                    LanguagesEnum.German,
                    new Dictionary<string, string>
                    {
                        { "High", "ist hoch" },
                        { "Low", "ist niedrig" },
                        { "OutOfRange", "ausser reichweite" },
                        { "Temperature", "Temperatur" },
                        { "StateOfCharge", "Ladezustand" },
                        { "ChargeRate", "Laderate" },
                        { "Warning", "Warnung" }
                    }
                }
            };

        public static string OutOfRangeMessage => Languages[CurrentLanguage]["OutOfRange"];

        public static string High => Languages[CurrentLanguage]["High"];

        public static string Low => Languages[CurrentLanguage]["Low"];

        public static Dictionary<StatusType, string> StatusNames => new Dictionary<StatusType, string>(){
            { StatusType.Temperature, Languages[CurrentLanguage]["Temperature"] },
            { StatusType.StateOfCharge, Languages[CurrentLanguage]["StateOfCharge"] },
            { StatusType.ChargeRate, Languages[CurrentLanguage]["ChargeRate"] }
        };
    }
}