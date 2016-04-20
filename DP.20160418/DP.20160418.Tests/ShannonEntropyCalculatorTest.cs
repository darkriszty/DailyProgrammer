using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DP._20160418.Tests
{
	[TestClass]
	public class ShannonEntropyCalculatorTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Test_GetEntropy_NoInput_Exception()
		{
			// set up
			string input = null;

			// act
			decimal entropy = ShannonEntropyCalculator.GetEntropy(input);

			// assert
			// exception excepted
		}

		[TestMethod]
		public void Test_GetEntropy_Simple1_CorrectResult()
		{
			// set up
			string input = "1223334444";

			// act
			decimal entropy = ShannonEntropyCalculator.GetEntropy(input);

			// assert
			Assert.AreEqual(1.84644, entropy);
		}

		[TestMethod]
		public void Test_GetEntropy_Simple2_CorrectResult()
		{
			// set up
			string input = "Hello, world!";

			// act
			decimal entropy = ShannonEntropyCalculator.GetEntropy(input);

			// assert
			Assert.AreEqual(3.18083, entropy);
		}

		[TestMethod]
		public void Test_GetEntropy_Complex1_CorrectResult()
		{
			// set up
			string input = "122333444455555666666777777788888888";

			// act
			decimal entropy = ShannonEntropyCalculator.GetEntropy(input);

			// assert
			Assert.AreEqual(2.794208683, entropy);
		}

		[TestMethod]
		public void Test_GetEntropy_Complex2_CorrectResult()
		{
			// set up
			string input = "563881467447538846567288767728553786";

			// act
			decimal entropy = ShannonEntropyCalculator.GetEntropy(input);

			// assert
			Assert.AreEqual(2.794208683, entropy);
		}

		[TestMethod]
		public void Test_GetEntropy_Complex3_CorrectResult()
		{
			// set up
			string input = "https://www.reddit.com/r/dailyprogrammer";

			// act
			decimal entropy = ShannonEntropyCalculator.GetEntropy(input);

			// assert
			Assert.AreEqual(4.056198332, entropy);
		}

		[TestMethod]
		public void Test_GetEntropy_Complex4_CorrectResult()
		{
			// set up
			string input = "int main(int argc, char *argv[])";

			// act
			decimal entropy = ShannonEntropyCalculator.GetEntropy(input);

			// assert
			Assert.AreEqual(3.866729296, entropy);
		}
	}
}
