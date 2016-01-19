using DP._20160113.BLL.Strings;

namespace DP._20160113.BLL.Generations
{
	public class IndividFactory
	{
		private readonly IStringDistanceCalculator _stringDistanceCalculator;

		public IndividFactory(IStringDistanceCalculator stringDistanceCalculator)
		{
			_stringDistanceCalculator = stringDistanceCalculator;
		}

		public Person CreateIndividual(string value, string expectedValue)
		{
			return new Person
			{
				Value = value,
				Fitness = _stringDistanceCalculator.GetDistance(value, expectedValue)
			};
		}
	}
}