using System;

namespace DP._20160418
{
	/*
		https://www.reddit.com/r/dailyprogrammer/comments/4fc896/20160418_challenge_263_easy_calculating_shannon/
	*/
	class Program
	{
		static void Main(string[] args)
		{
			const string input = "Hello, world!";

			double entropy = ShannonEntropyCalculator.GetEntropy(input);

			Console.WriteLine($"The Shannon entropy of \"{input}\" is {entropy}");

			if (System.Diagnostics.Debugger.IsAttached)
				Console.ReadKey(true);
		}
	}
}
