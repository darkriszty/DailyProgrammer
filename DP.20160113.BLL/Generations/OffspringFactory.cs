using System;
using System.Linq;
using System.Text;
using DP._20160113.BLL.Strings;

namespace DP._20160113.BLL.Generations
{
	/// <summary>
	/// Responsible to create new offsprings.
	/// </summary>
	public class OffspringFactory : IOffspringFactory
	{
		private readonly IStringRandomizer _stringRandomizer;
		private readonly int _mutationCountPerGeneration;

		public OffspringFactory(IStringRandomizer stringRandomizer, int mutationCountPerGeneration)
		{
			_stringRandomizer = stringRandomizer;
			_mutationCountPerGeneration = mutationCountPerGeneration;
		}

		/// <summary>
		/// Use the parents to generate a new offspring.
		/// </summary>
		/// <param name="previousGeneration">The previous generation</param>
		/// <returns>The new offspring</returns>
		public string GetNewOffspring(Generation previousGeneration)
		{
			if (!previousGeneration.Parents.Any())
			{
				throw new ArgumentException("Parents must exist to create offsprings!");
			}

			int length = previousGeneration.Parents.First().Length;
			if (previousGeneration.Parents.Any(parent => parent.Length != length))
			{
				throw new ArgumentException("Parents must be of the same length!");
			}

			// get the cut off point in the parents
			StringBuilder sb = new StringBuilder();
			int cutOffSize = length / previousGeneration.Parents.Count;

			int lastCutoffPoint = 0;
			foreach (string parent in previousGeneration.Parents)
			{
				sb.Append(parent.Substring(lastCutoffPoint, cutOffSize));
				lastCutoffPoint += cutOffSize;
			}

			// make sure the required length is reached (int division)
			int missing = length - sb.Length;
			if (missing > 0)
			{
				// if not then copy from the beginning of the last parent
				string lastParent = previousGeneration.Parents.Last();
				sb.Append(lastParent.Substring(0, missing));
			}

			// now perform the mutation
			string result = _stringRandomizer.RandomizeCharacter(sb.ToString(), _mutationCountPerGeneration);

			return result;
		}
	}
}