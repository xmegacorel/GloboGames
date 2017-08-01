using System;
using System.Collections.Generic;

namespace CalculatorService
{
	public class LexemIterator
	{
		private readonly IEnumerator<string> _lexems;
		private bool _hasNext;
		private readonly int _count;
		public LexemIterator(IReadOnlyCollection<string> lexems)
		{
			_lexems = lexems.GetEnumerator();
			_hasNext = _lexems.MoveNext();
			_count = lexems.Count;
		}

		public string GetNextValue()
		{
			if (_hasNext == false)
			{
				throw new ArgumentOutOfRangeException();
			}

			var result = _lexems.Current;

			_hasNext = _lexems.MoveNext();

			return result;
		}

		public bool HasNext()
		{
			return _hasNext;
		}

		public int Count => _count;
	}
}