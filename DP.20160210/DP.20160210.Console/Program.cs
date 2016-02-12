using DP._20160210.BLL.IoC;
using Microsoft.Practices.Unity;

namespace DP._20160210.Console
{
	class Program
	{
		/*
		* https://www.reddit.com/r/dailyprogrammer/comments/452omr/20160210_challenge_253_intermediate_countdown/
		*/
		static void Main(string[] args)
		{
			IUnityContainer container = new UnityContainer();
			container.RegisterServices();
		}
	}
}
