using System.Collections.Generic;

namespace DP._20160113.BLL.Generations
{
	public class Generation
	{
		/// <summary>
		/// Gets or sets the ancestors of this generation
		/// </summary>
		public List<Person> Ancestors { get; private set; }

		/// <summary>
		/// Gets or sets the actual new offspring of the generation
		/// </summary>
		public Person Offspring { get; set; }

		public Generation()
		{
			Ancestors = new List<Person>();
		}
	}
}