using System;
using CalculatorService;
using Optional;

namespace ConsoleCalculator
{
	public class ConsoleSolver
	{
		public static Option<double, Exception> Process(string inputString)
		{
			try
			{
				var parcer = new InputStringParcer(inputString, Consts.AviableOperatons);
				var iterator = new LexemIterator(parcer.Lexems);
				var builder = new AstBuilder(iterator);
				var solver = new Solver(builder.AST);

				return solver.Result.Some<double, Exception>();
			}
			catch (InvalidInputStream e)
			{
				return Option.None<double, Exception>(e);
			}
			catch (ArgumentException e)
			{
				return Option.None<double, Exception>(e);
			}
			
		}
	}
}