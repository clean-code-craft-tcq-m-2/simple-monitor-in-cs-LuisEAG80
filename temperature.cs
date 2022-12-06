using System;

namespace batteryChecker
{
    public interface ITemperature
    {
        float Value();
    }

    public class CelciusTemperature : ITemperature
    {
        float _value;

        public CelciusTemperature(float value)
        {
            _value = value;
        }

        public float Value()
        {
            return _value;
        }
    }

    public class FahrenheitTemperature : ITemperature
    {
        float _value;

        public FahrenheitTemperature(float value)
        {
            _value = value;
        }

        public float Value()
        {
            return (_value - 32) * 0.5556f;
        }
    }
}