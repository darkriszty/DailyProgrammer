using DP._20160113.BLL;

namespace DP._20160113.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			ILevenshteinDistanceCalculator calculator = new LevenshteinDistanceCalculator();

			System.Console.WriteLine(calculator.GetDistance("Hello, world!", "olleH, dlrow!"));
		}
	}
}
