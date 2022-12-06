using System;
using System.Collections.Generic;

namespace batteryChecker
{
    public static class StatusMessages
    {
        public static readonly string OutOfRangeMessage = "out of range!";
        public static readonly string High = "high";
        public static readonly string Low = "low";

        public static readonly Dictionary<StatusType, string> StatusNames = new Dictionary<StatusType, string>(){
            { StatusType.Temperature, "Temperature" },
            { StatusType.StateOfCharge, "State of Charge" },
            { StatusType.ChargeRate, "Charge Rate" }
        };
    }
}