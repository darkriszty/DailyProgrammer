using System;

namespace DP._20160210.BLL.Models
{
	/// <summary>
	/// Encapsulates the properties of the problem solution.
	/// </summary>
	public class ProblemSolution
	{
		/// <summary>
		/// Gets or sets a value indicating whether or not the solution to the problem was found
		/// </summary>
		public bool SolutionFound { get; set; }

		/// <summary>
		/// Gets or sets the number of tries it took to reach a conclusion to the problem
		/// </summary>
		public ulong NumberOfTries { get; set; }

		/// <summary>
		/// Gets or sets the time that was needed in order to generate the solution
		/// </summary>
		public TimeSpan ElapsedTime { get; set; }
	}
}