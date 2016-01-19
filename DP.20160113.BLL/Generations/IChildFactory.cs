namespace DP._20160113.BLL.Generations
{
	public interface IChildFactory
	{
		/// <summary>
		/// Use the parents to generate a new child.
		/// </summary>
		/// <param name="ancestor">The previous generation</param>
		/// <returns>The new child</returns>
		string GetNewChild(Ancestor ancestor);
	}
}