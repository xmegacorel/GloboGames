namespace CalculatorService
{
	public static class NodePrintExtension
	{
		public static string Print(this NodeBase node)
		{
			if (node == null)
				return "";

			var bNode = node as BinaryOperation;

			if (bNode != null)
			{
				var left = bNode.LeftNode;
				var right = bNode.RightNode;

				var str = $"left: {left.Print()} {bNode.Operation} {right.Print()}\n";

				return str;
			}
			else
			{
				var operand = node as Operand;
				var str = $"op: {operand} \n";

				return str;
			}
			
		}
	}
}