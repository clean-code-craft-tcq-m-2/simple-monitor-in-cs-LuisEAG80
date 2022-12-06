using System;
using System.Collections.Generic;

namespace batteryChecker
{
    public static class ValidRanges
    {
        public static readonly Range TemperatureRange = new Range(0.0f, 45.0f);
        public static readonly Range StateOfChargeRange = new Range(20.0f, 80.0f);
        public static readonly Range ChargeRateRange = new Range(0.0f, 0.8f);

        public static readonly Dictionary<StatusType, Range> Ranges = new Dictionary<StatusType, Range>(){
            { StatusType.Temperature, TemperatureRange },
            { StatusType.StateOfCharge, StateOfChargeRange },
            { StatusType.ChargeRate, ChargeRateRange }
        };
    }
}