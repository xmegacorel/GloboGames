using System;

namespace CalculatorService
{
	public class InvalidInputStream : Exception
	{
		public InvalidInputStream()
		{
			
		}

		public InvalidInputStream(string name) : base(name)
		{
			
		}
	}
}