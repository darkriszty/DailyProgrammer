using DP._20160404.Business;
using DP._20160404.IO;
using Microsoft.Practices.Unity;

namespace DP._20160404.Boot
{
	/// <summary>
	/// Responsible to bootstrap the application.
	/// </summary>
	public static class Bootstrapper
	{
		/// <summary>
		/// Registers the implementations of interfaces in the IoC container.
		/// </summary>
		/// <param name="container">The container to register into.</param>
		/// <param name="expectedSquareSum">The expected magic value of magic squares</param>
		/// <returns>The IoC container with the registrations.</returns>
		public static IUnityContainer ConfigureRegistrations(this IUnityContainer container, int expectedSquareSum)
		{
			return container
				.RegisterType<IIntegerInputReader, IntegerInputReader>()
				.RegisterType<ISquareReader, SquareReader>()
				.RegisterType<ISquareWriter, SquareWriter>()
				.RegisterType<IMagicSquareController, MagicSquareController>()
				.RegisterType<IMagicSquareVerifier, MagicSquareVerifier>(new InjectionConstructor(expectedSquareSum));
		}
	}
}