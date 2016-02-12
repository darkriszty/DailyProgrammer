using System.Collections.Generic;

namespace DP._20160210.BLL.RPN
{
	/// <summary>
	/// Encapsulates the properties of the RPN calculation result.
	/// </summary>
	public class RpnResult
	{
		public RpnResult()
		{
			ErrorMessages = new List<string>();
		}

		/// <summary>
		/// Gets or sets the result of the caluclation, if available.
		/// </summary>
		public decimal? CalculationResult { get; set; }

		/// <summary>
		/// Gets any error message for the case when the calculation did not succeed.
		/// </summary>
		public List<string> ErrorMessages { get; private set; }
	}
}