using System.Diagnostics;
using System.Threading.Tasks;
using DP._20160210.BLL.Models;

namespace DP._20160210.BLL.Controllers
{
	/// <summary>
	/// Responsible to find the solution to the the main problem.
	/// </summary>
	public class MainController
	{
		/// <summary>
		/// Starts the process of finding the solution to the main problem.
		/// </summary>
		/// <param name="input">The input numbers separated by spaces</param>
		/// <param name="expectedResult">The expected result of the operation</param>
		/// <returns>The result with the solution marked as found or not.</returns>
		public async Task<ProblemSolution> FindSolution(string input, decimal expectedResult)
		{
			Stopwatch sw = Stopwatch.StartNew();

			await Task.FromResult(0);

			sw.Stop();

			return new ProblemSolution
			{
				SolutionFound = false,
				NumberOfTries = 0,
				ElapsedTime = sw.Elapsed,
			};
		}
	}
}