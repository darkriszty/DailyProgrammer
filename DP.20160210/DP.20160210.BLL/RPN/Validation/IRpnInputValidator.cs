using System.Collections.Generic;
using DP._20160210.BLL.Models.Rpn;

namespace DP._20160210.BLL.RPN.Validation
{
	/// <summary>
	/// Responsible for validation the RPN input.
	/// </summary>
	public interface IRpnInputValidator
	{
		/// <summary>
		/// Validates the RPN input and returns a validation result indicating the success.
		/// </summary>
		/// <param name="input">The input to validate</param>
		/// <returns>The validation result</returns>
		RpnInputValidationResult Validate(IEnumerable<string> input);
	}
}