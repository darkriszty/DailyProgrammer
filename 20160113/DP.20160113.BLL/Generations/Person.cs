namespace DP._20160113.BLL.Generations
{
	public class Person
	{
		/// <summary>
		/// Gets or sets the individual of the generation
		/// </summary>
		public string Value { get; set; }

		/// <summary>
		/// Gets or sets the fitness value of the individual
		/// </summary>
		public int Fitness { get; set; }

		public override string ToString()
		{
			return string.Format("{0} (Fit: {1})", Value, Fitness);
		}
	}
}