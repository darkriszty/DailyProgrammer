using System.Configuration;

namespace DP._20160113.BLL
{
	/// <summary>
	/// Encapsulates applicatyion settings.
	/// </summary>
	public static class AppSettings
	{
		/// <summary>
		/// Gets the number of mutations to perform for each new generation.
		/// </summary>
		public static int MutationCountPerGeneration
		{
			get
			{
				return int.Parse(ConfigurationManager.AppSettings["mutation-count-per-generation"]);
			}
		}
	}
}