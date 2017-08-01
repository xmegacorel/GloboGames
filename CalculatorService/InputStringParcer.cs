using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorService
{
	public class InputStringParcer
	{
		private readonly List<string> _lexems;
		private readonly IReadOnlyCollection<char> _operations;

		public InputStringParcer(string str, IReadOnlyCollection<char> operations)
		{
			if (string.IsNullOrWhiteSpace(str))
			{
				throw new ArgumentException("Некорректная строка ввода");
			}

			_operations = operations;

			var preparedString = CleanString(str);

			var lexems = ParceLexems(preparedString);

			_lexems = lexems;
		}

		private List<string> ParceLexems(string preparedString)
		{
			var result = new List<string>();
			int index = 0;
			var sb = new StringBuilder();
			do
			{
				var currentChar = preparedString[index];
				if (_operations.Contains(currentChar) == false)
				{
					sb.Append(currentChar);
					if (index + 1 == preparedString.Length)
					{
						result.Add(sb.ToString());
					}
				}
				else
				{
					result.Add(sb.ToString());
					result.Add(currentChar.ToString());

					sb.Clear();
				}
				index++;
			} while (index < preparedString.Length);

			return result;
		}

		private string CleanString(string str)
		{
			return str.Replace(" ", "");
		}

		public IReadOnlyCollection<string> Lexems => _lexems;
	}
}