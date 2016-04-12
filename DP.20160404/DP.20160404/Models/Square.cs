namespace DP._20160404.Models
{
	/// <summary>
	/// Encapsulates the properties of a simple square(matrix).
	/// </summary>
	public class Square
	{
		/// <summary>
		/// Gets the size of the square
		/// </summary>
		public int Size { get; private set; }

		/// <summary>
		/// Gets the values of the square.
		/// </summary>
		public int [][] Values { get; private set; }

		public Square(int size)
		{
			// set the size
			Size = size;

			// initialize the arrays
			Values = new int[size][];
			for (int i = 0; i < size; i++)
				Values[i] = new int[size];
		}
	}
}