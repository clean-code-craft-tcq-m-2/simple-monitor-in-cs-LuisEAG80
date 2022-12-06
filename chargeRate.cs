namespace batteryChecker
{
    public interface IChargeRate
    {
        float Value();
    }

    public class ChargeRate : IChargeRate
    {
        float _value;

        public ChargeRate(float value)
        {
            _value = value;
        }

        public float Value()
        {
            return _value;
        }
    }
}