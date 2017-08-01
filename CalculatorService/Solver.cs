using System;
using System.ComponentModel;

namespace CalculatorService
{
	public class Solver
	{
		private double _value = 0.0d;

		public Solver(NodeBase ast)
		{
			if (ast == null)
			{
				throw new ArgumentException(nameof(ast));
			}

			_value = Process(ast);
		}

		private double Process(NodeBase ast)
		{
			var binaryOp = ast as BinaryOperation;
			double left = 0, right = 0;
			if (binaryOp.LeftNode is Operand)
			{
				left = ((Operand) binaryOp.LeftNode).Value;
			}
			else
			{
				left = Process(binaryOp.LeftNode);
			}

			if (binaryOp.RightNode is Operand)
			{
				right = ((Operand)binaryOp.RightNode).Value;
			}
			else
			{
				right = Process(binaryOp.RightNode);
			}

			var result =  Calc(left, right, binaryOp.Operation);

			return result;
		}

		private double Calc(double left, double right, string operation)
		{
			switch (operation)
			{
				case "+":
					return left + right;
				case "-":
					return left - right;
				case "*":
					return left * right;
				case "/":
					return left / right;
				default:
					throw new InvalidEnumArgumentException();
			}
		}


		public double Result => _value;
	}
}