using System.Collections.Generic;

namespace DP._20160210.BLL.Models.Rpn
{
	/// <summary>
	/// Encapsulates the properties of a RPN input validation.
	/// </summary>
	public class RpnInputValidationResult
	{
		public RpnInputValidationResult()
		{
			ErrorMessages = new List<string>();
		}

		/// <summary>
		/// Gets or sets a value indicating whether or not the input is valid.
		/// </summary>
		public bool IsValid { get; set; }

		/// <summary>
		/// Gets any error message for the case when the input is not valid
		/// </summary>
		public List<string> ErrorMessages { get; private set; }
	}
}