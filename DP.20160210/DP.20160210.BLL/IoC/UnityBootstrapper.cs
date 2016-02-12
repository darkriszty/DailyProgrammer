using DP._20160210.BLL.RPN;
using DP._20160210.BLL.RPN.Validation;
using Microsoft.Practices.Unity;

namespace DP._20160210.BLL.IoC
{
	/// <summary>
	/// Responsible to provide the means of registering the application specific services into Unity.
	/// </summary>
	public static class UnityBootstrapper
	{
		/// <summary>
		/// Add the application specific registrations into the container.
		/// </summary>
		public static IUnityContainer RegisterServices(this IUnityContainer container)
		{
			container.RegisterType<ITokenInfoProvider, TokenInfoProvider>();
			container.RegisterType<IRpnCalculator, RpnCalculator>();
			container.RegisterType<IRpnInputValidator, RpnInputValidator>();

			return container;
		}
	}
}