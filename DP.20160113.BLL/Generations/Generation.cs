using System.Collections.Generic;

namespace DP._20160113.BLL.Generations
{
	public class Generation
	{
		/// <summary>
		/// Gets the list of parents that generated the offspring
		/// </summary>
		public List<string> Parents { get; private set; } 

		/// <summary>
		/// Gets or sets the actual new offspring of the generation
		/// </summary>
		public string Offspring { get; set; }

		/// <summary>
		/// Gets or sets the fitness level of this generation
		/// </summary>
		public int Fitness { get; set; }

		public Generation()
		{
			Parents = new List<string>();
		}
	}
}