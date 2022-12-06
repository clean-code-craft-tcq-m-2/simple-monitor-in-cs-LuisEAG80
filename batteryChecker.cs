using System;
using System.Collections.Generic;

namespace batteryChecker
{
    public static class BatteryChecker
    {
        public static bool BatteryIsOk(ITemperature temperature, IStateOfCharge stateOfCharge, IChargeRate chargeRate)
        {
            return (
                IsInRange(StatusType.Temperature, temperature.Value()) &&
                IsInRange(StatusType.StateOfCharge, stateOfCharge.Value()) &&
                IsInRange(StatusType.ChargeRate, chargeRate.Value()));
        }

        public static bool IsInRange(StatusType statusType, float statusValue)
        {
            var range = ValidRanges.Ranges[statusType];
            bool isInRange = true;
            
            if(statusValue < range.Min)
            {
                isInRange = false;
                Console.WriteLine(outOfRangeMessage(statusType, isLow: true));
            }
            else if(statusValue > range.Max)
            {
                isInRange = false;
                Console.WriteLine(outOfRangeMessage(statusType, isLow: false));
            }

            return isInRange;
        }

        public static string outOfRangeMessage(StatusType statusType, bool isLow)
        {
            return
                StatusMessages.StatusNames[statusType] + " " +
                StatusMessages.OutOfRangeMessage + " " +
                (isLow ? StatusMessages.Low : StatusMessages.High) ;
        }
    }
}