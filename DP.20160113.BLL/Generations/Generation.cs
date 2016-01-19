namespace DP._20160113.BLL.Generations
{
	public class Generation
	{
		/// <summary>
		/// Gets or sets the ancestors of this generation
		/// </summary>
		public Ancestor Ancestors { get; set; }

		/// <summary>
		/// Gets or sets the actual new offspring of the generation
		/// </summary>
		public Offspring Offspring { get; set; }
	}
}