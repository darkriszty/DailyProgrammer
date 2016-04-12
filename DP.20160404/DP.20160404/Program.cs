using System;
using DP._20160404.Boot;
using DP._20160404.Business;
using Microsoft.Practices.Unity;

namespace DP._20160404
{
	class Program
	{
		static void Main(string[] args)
		{
			// set up an IoC container
			IUnityContainer container = new UnityContainer();
			container.ConfigureRegistrations(15);

			// run the main controller
			var controller = container.Resolve<IMagicSquareController>();
			controller.Run(Console.In, Console.Out);

			// pause the execution if a debugger is attached
			if (System.Diagnostics.Debugger.IsAttached)
			{
				Console.WriteLine("Press any key to exit.");
				Console.ReadKey(false);
			}
		}
	}
}
