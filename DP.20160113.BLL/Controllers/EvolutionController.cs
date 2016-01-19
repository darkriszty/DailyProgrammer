using System;
using System.Diagnostics;
using DP._20160113.BLL.Generations;
using DP._20160113.BLL.Strings;

namespace DP._20160113.BLL.Controllers
{
	/// <summary>
	/// Responsible to create better generations based on old generations to create more fit offsprings.
	/// </summary>
	public class EvolutionController
	{
		private readonly IStringRandomizer _randomizer;
		private readonly GenerationBuilder _generationBuilder;
		private readonly IndividFactory _individFactory;

		public EvolutionController(IStringRandomizer randomizer,
			GenerationBuilder generationBuilder,
			IndividFactory individFactory)
		{
			_randomizer = randomizer;
			_generationBuilder = generationBuilder;
			_individFactory = individFactory;
		}

		/// <summary>
		/// Starts the evolution simulation
		/// </summary>
		/// <param name="input">The expected output</param>
		public void StartEvolution(string input)
		{
			Console.WriteLine("Original input: {0}", input);
			Person parent1 = _individFactory.CreateIndividual(_randomizer.GetRandomizedInput(input), input);
			Person parent2 = _individFactory.CreateIndividual(_randomizer.GetRandomizedInput(input), input);
			Console.WriteLine("First parent: {0}", parent1);
			Console.WriteLine("Second parent: {0}", parent2);

			// set up an initial generation
			Generation initialGeneration = new Generation();
			initialGeneration.Ancestors.Add(parent1);
			initialGeneration.Ancestors.Add(parent2);

			// start the main loop
			StartInner(initialGeneration, input);
		}

		/// <summary>
		/// Starts the inner main loop that finds the solution.
		/// </summary>
		private void StartInner(Generation initialGeneration, string expectedOutput)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			Generation lastGeneration = initialGeneration;
			bool finalGenerationFound = false;
			int generationCount = 0;

			// create better generations with each iteration to reach the expected result
			while (!finalGenerationFound)
			{
				lastGeneration = CreateBetterGeneration(lastGeneration, expectedOutput);
				Console.WriteLine("Gen: {0} | Fitness: {1} | {2}", ++generationCount, lastGeneration.Offspring.Fitness, lastGeneration.Offspring.Value);
				finalGenerationFound = lastGeneration.Offspring.Fitness == 0;
			}
			stopwatch.Stop();
			TimeSpan ts = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);
			Console.WriteLine("Elapsed time: {0}", ts);
		}

		/// <summary>
		/// Creates a new generation with a better fitted offspring based on the provided generation.
		/// </summary>
		private Generation CreateBetterGeneration(Generation oldGeneration, string expectedOutput)
		{
			Generation result = null;
			bool betterGeneration = false;
			while (!betterGeneration)
			{
				result = _generationBuilder.BuildNewGeneration(oldGeneration, expectedOutput);
				if (oldGeneration.Offspring == null || result.Offspring.Fitness < oldGeneration.Offspring.Fitness)
				{
					betterGeneration = true;
				}
			}

			return result;
		}
	}
}