namespace batteryChecker
{
	public class Range
	{
		public Range(float min, float max)
		{
			Min = min;
			Max = max;
		}

		public float Min { get; }
		public float Max { get; }
	}
}