namespace QueuesStacks.Tests;
using QueuesStacks.Application;

[TestClass]
public class PrefixNotationTest
{
    [TestMethod]
    public void TestAddition()
    {
        string expression = "+ 2 3";
        double expected = 5;
        double result = PolishNotation.PrefixNotation(expression);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestSubtraction()
    {
        string expression = "- 5 3";
        double expected = 2;
        double result = PolishNotation.PrefixNotation(expression);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestMultiplication()
    {
        string expression = "* 2 4";
        double expected = 8;
        double result = PolishNotation.PrefixNotation(expression);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestDivision()
    {
        string expression = "/ 8 2";
        double expected = 4;
        double result = PolishNotation.PrefixNotation(expression);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void TestComplexExpression()
    {
        string expression = "+ * 2 3 4";
        double expected = 10;
        double result = PolishNotation.PrefixNotation(expression);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestInvalidExpression_NotEnoughOperands()
    {
        string expression = "+ 2";
        PolishNotation.PrefixNotation(expression);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestInvalidExpression_TooManyOperands()
    {
        string expression = "+ 2 3 4 5";
        PolishNotation.PrefixNotation(expression);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestInvalidExpression_InvalidOperator()
    {
        string expression = "x 2 3";
        PolishNotation.PrefixNotation(expression);
    }
}