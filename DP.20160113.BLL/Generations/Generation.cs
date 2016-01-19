namespace DP._20160113.BLL.Generations
{
	public class Generation
	{
		public Ancestor Ancestors { get; set; }

		/// <summary>
		/// Gets or sets the actual new offspring of the generation
		/// </summary>
		public string Offspring { get; set; }
	}
}