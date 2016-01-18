namespace DP._20160113.BLL.Generations
{
	public interface IOffspringFactory
	{
		/// <summary>
		/// Use the parents to generate a new offspring.
		/// </summary>
		/// <param name="previousGeneration">The previous generation</param>
		/// <returns>The new offspring</returns>
		string GetNewOffspring(Generation previousGeneration);
	}
}