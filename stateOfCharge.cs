namespace batteryChecker
{
    public interface IStateOfCharge
    {
        float Value();
    }

    public class StateOfCharge : IStateOfCharge
    {
        float _value;

        public StateOfCharge(float value)
        {
            _value = value;
        }

        public float Value()
        {
            return _value;
        }
    }
}