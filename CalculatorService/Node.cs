namespace CalculatorService
{
    public abstract class NodeBase
    {
    }

	public class Operand : NodeBase
	{
		public int Value { get; set; }

		public static Operand Parse(string value)
		{
			return new Operand() {Value = int.Parse(value)};
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}

	public abstract class UnaryOperation : NodeBase
	{
		public NodeBase Node { get; set; }
	}

	public abstract class BinaryOperation : NodeBase
	{
		public NodeBase LeftNode { get; set; }
		public NodeBase RightNode { get; set; }
		public abstract string Operation { get; }
	}

	public class NodeSummation : BinaryOperation
	{
		public override string Operation => "+";
	}

	public class NodeSubtraction : BinaryOperation
	{
		public override string Operation => "-";
	}

	public class NodeMultiplication : BinaryOperation
	{
		public override string Operation => "*";
	}
	public class NodeDivision : BinaryOperation
	{
		public override string Operation => "/";
	}
}
