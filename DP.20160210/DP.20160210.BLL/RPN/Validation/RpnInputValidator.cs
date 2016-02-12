using System.Collections.Generic;

namespace DP._20160210.BLL.RPN.Validation
{
	/// <summary>
	/// Responsible for validation the RPN input.
	/// </summary>
	public class RpnInputValidator : IRpnInputValidator
	{
		/// <summary>
		/// Validates the RPN input and returns a validation result indicating the success.
		/// </summary>
		/// <param name="input">The input to validate</param>
		/// <returns>The validation result</returns>
		public RpnInputValidationResult Validate(IEnumerable<string> input)
		{
			return null;
		}
	}
}