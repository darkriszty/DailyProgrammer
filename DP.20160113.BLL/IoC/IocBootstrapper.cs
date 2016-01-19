using DP._20160113.BLL.Generations;
using DP._20160113.BLL.Strings;
using Microsoft.Practices.Unity;

namespace DP._20160113.BLL.IoC
{
	public static class IocBootstrapper
	{
		/// <summary>
		/// Add the application specific registrations into the container.
		/// </summary>
		public static IUnityContainer RegisterServices(this IUnityContainer container, int mutationCountPerGeneration)
		{
			container.RegisterType<IStringDistanceCalculator, CharDistanceCalculator>();
			container.RegisterType<IStringRandomizer, StringRandomizer>(new ContainerControlledLifetimeManager());
			container.RegisterType<IChildFactory, ChildFactory>(
				new InjectionConstructor(
					new ResolvedParameter<IStringRandomizer>(), 
					mutationCountPerGeneration
				)
			);

			return container;
		}
	}
}