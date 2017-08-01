using CalculatorService;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace UnitTestProject
{
    public class CalculatorTests
    {
	    private readonly ITestOutputHelper _helper;

	    public CalculatorTests(ITestOutputHelper helper)
	    {
		    _helper = helper;
	    }

	    [Fact]
	    public void PrintAst_Successed()
	    {
		    var parcer = new InputStringParcer("12 + 3 * 4", Consts.AviableOperatons);
			var iterator = new LexemIterator(parcer.Lexems);
			var builder = new AstBuilder(iterator);
		    _helper.WriteLine(builder.AST.Print());

	    }

		[Theory]
		[InlineData("12 + 3 * ")]
		[InlineData("12 + ")]
		[InlineData("12")]
		public void WrongInoutString_Successed(string input)
	    {
		    var parcer = new InputStringParcer(input, Consts.AviableOperatons);
		    var iterator = new LexemIterator(parcer.Lexems);
		    Should.Throw<InvalidInputStream>(()=> new AstBuilder(iterator));
	    }

		[Theory]
	    [InlineData("12 + 3 * 4", 24)]
		[InlineData("12 * 3 + 3 * 4", 48)]
		[InlineData("12 + 3 - 4 * 2", 7)]
		[InlineData("12 + 3 * 4 - 2", 22)]
		[InlineData("12 + 3 * 4 / 2", 18)]
		public void Calc_Successed(string task, double result)
	    {
		    var parcer = new InputStringParcer(task, Consts.AviableOperatons);
		    var iterator = new LexemIterator(parcer.Lexems);
			var builder = new AstBuilder(iterator);
			var solver = new Solver(builder.AST);
		    _helper.WriteLine($"Task : {task} = {solver.Result}");

			solver.Result.ShouldBe(result, 0.01);
	    }

	}
}
