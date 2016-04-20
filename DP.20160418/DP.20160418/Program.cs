using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP._20160418
{
	/*
		https://www.reddit.com/r/dailyprogrammer/comments/4fc896/20160418_challenge_263_easy_calculating_shannon/
	*/
	class Program
	{
		static void Main(string[] args)
		{
			decimal entropy = ShannonEntropyCalculator.GetEntropy("Hello, world!");

			Console.WriteLine(entropy);

			if (System.Diagnostics.Debugger.IsAttached)
				Console.ReadKey(true);
		}
	}
}
