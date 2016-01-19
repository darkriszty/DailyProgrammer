using DP._20160113.BLL;
using DP._20160113.BLL.IoC;
using DP._20160113.BLL.Strings;
using Microsoft.Practices.Unity;

namespace DP._20160113.Console
{
	class Program
	{
		/*
		 * https://www.reddit.com/r/dailyprogrammer/comments/40rs67/20160113_challenge_249_intermediate_hello_world/
		 * The input string should be the target string you want to evolve the initial random solution into.
		 * The target string (and therefore input) will be 'Hello, world!' 
		 * However, you want your program to initialize the process by randomly generating a string of the same 
		 * length as the input. The only thing you want to use the input for is to determine the fitness of your function, 
		 * so you don't want to just cheat by printing out the input string!
		 */

		private const string INPUT = "Hello, world!";

		static void Main(string[] args)
		{
			IUnityContainer container = new UnityContainer();
			container.RegisterServices(AppSettings.MutationCountPerGeneration);


			IStringDistanceCalculator calculator = container.Resolve<IStringDistanceCalculator>();
			IStringRandomizer randomizer = container.Resolve<IStringRandomizer>();

			string randomizedInput = randomizer.GetRandomizedInput(INPUT);
			System.Console.WriteLine("Random input: {0}", randomizedInput);
			System.Console.WriteLine("Random input distance from original input: {0}", calculator.GetDistance(INPUT, randomizedInput));
		}
	}
}
