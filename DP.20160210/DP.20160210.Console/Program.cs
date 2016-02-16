using System.Threading.Tasks;
using DP._20160210.BLL.Controllers;
using DP._20160210.BLL.IoC;
using DP._20160210.BLL.Models;
using Microsoft.Practices.Unity;

namespace DP._20160210.Console
{
	class Program
	{
		/*
		* https://www.reddit.com/r/dailyprogrammer/comments/452omr/20160210_challenge_253_intermediate_countdown/
		*/
		static void Main(string[] args)
		{
			Task main = MainAsync(args);
			main.Wait();

			if (System.Diagnostics.Debugger.IsAttached)
			{
				System.Console.WriteLine("Press any key to exit . . .");
				System.Console.ReadKey();
			}
		}

		static async Task MainAsync(string[] args)
		{
			IUnityContainer container = new UnityContainer();
			container.RegisterServices();

			MainController controller = container.Resolve<MainController>();
			ProblemSolution problemResult = await controller.FindSolution("10 33 23", 0);

			System.Console.WriteLine("Solution found: " + (problemResult.SolutionFound ? "yes" : "no"));
			System.Console.WriteLine("Number of combinations tried: " + problemResult.NumberOfTries);
			System.Console.WriteLine("Total processing time: " + problemResult.ElapsedTime.ToString(@"dd\.hh\:mm\:ss"));
		}
	}
}
