using System;

namespace ConsoleCalculator
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Вас приветствует консольный калькулятор. Поддерживаемые операции +, -, *, /");
			Console.Write("Введите строку для подсчета: ");
			var inputString = Console.ReadLine();

			var result = ConsoleSolver.Process(inputString);

			result.MatchSome(x =>
			{
				Console.WriteLine("Ответ: " + x.ToString("F2"));
			});

			result.MatchNone(x =>
			{
				Console.WriteLine("Ошибка вычислений");
			});
			
			Console.WriteLine("Нажмите любую клавишу для завершения");
			Console.ReadKey();
		}
	}
}
