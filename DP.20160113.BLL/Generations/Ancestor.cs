using System.Collections.Generic;

namespace DP._20160113.BLL.Generations
{
	public class Ancestor
	{
		/// <summary>
		/// Gets the list of parents that generated the offspring
		/// </summary>
		public List<string> Parents { get; private set; }

		public Ancestor()
		{
			Parents = new List<string>();
		}
	}
}