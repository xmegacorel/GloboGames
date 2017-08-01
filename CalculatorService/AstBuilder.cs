using System;

namespace CalculatorService
{
	public class AstBuilder
	{
		private readonly LexemIterator _lexemIterator;
		private NodeBase _ast;

		public AstBuilder(LexemIterator lexemIterator)
		{
			_lexemIterator = lexemIterator;

			if (lexemIterator.Count < 3)
			{
				throw new InvalidInputStream("Количество лексем меньше 3");
			}

			try
			{
				BuildAst();
			}
			catch (Exception e)
			{
				throw new InvalidInputStream("Ошибка построения дерева вычислений");
			}
			
		}

		private void BuildAst()
		{
			var left = _lexemIterator.GetNextValue();
			var op = _lexemIterator.GetNextValue();
			var right = _lexemIterator.GetNextValue();

			_ast = BuildNodeWithOperation(op, Operand.Parse(left), Operand.Parse(right));

			_ast = BuildAstRecurs(_ast, op);

		}

		private NodeBase BuildAstRecurs(NodeBase ast, string prevOp)
		{
			if (_lexemIterator.HasNext() == false)
			{
				return ast;
			}

			var op = _lexemIterator.GetNextValue();
			var right = _lexemIterator.GetNextValue();
			if ((prevOp == "+" || prevOp == "-") && (op == "*" || op == "/"))
			{
				var binaryOperation = (ast as BinaryOperation);
				var temporaryNode = BuildNodeWithOperation(op, binaryOperation.RightNode, Operand.Parse(right));
				var next = BuildAstRecurs(temporaryNode, op);

				return BuildNodeWithOperation(binaryOperation.Operation, binaryOperation.LeftNode, next);
			}

			var nextNode = BuildNodeWithOperation(op, ast, Operand.Parse(right));

			return BuildAstRecurs(nextNode, op);

		}

		BinaryOperation BuildNodeWithOperation(string op, NodeBase left, NodeBase right)
		{

			if (op == "+")
			{
				var node = new NodeSummation()
				{
					LeftNode = left,
					RightNode = right
				};
				return node;
			}
			if (op == "-")
			{
				var node = new NodeSubtraction()
				{
					LeftNode = left,
					RightNode = right
				};
				return node;
			}
			if (op == "*")
			{
				var node = new NodeMultiplication()
				{
					LeftNode = left,
					RightNode = right
				};
				return node;
			}
			if (op == "/")
			{
				var node = new NodeDivision()
				{
					LeftNode = left,
					RightNode = right
				};
				return node;
			}

			throw new NotImplementedException();
		}

		public NodeBase AST => _ast;
	}
}