using System.Collections.Generic;

namespace CalculatorService
{
	public static class Consts
	{
		public static IReadOnlyCollection<char> AviableOperatons => new[] { '+', '-', '*', '/' };
	}
}