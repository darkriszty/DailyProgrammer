namespace DP._20160210.BLL.RPN
{
	/// <summary>
	/// Responsible to perform calculations in Reverse Polish Notation
	/// </summary>
	public interface IRpnCalculator
	{
		/// <summary>
		/// Calculates and returns the result of the input string.
		/// </summary>
		/// <param name="input">The input string in RPN</param>
		/// <returns>The calculated result.</returns>
		RpnResult GetResult(string input);
	}
}