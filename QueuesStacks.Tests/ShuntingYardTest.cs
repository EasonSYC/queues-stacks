namespace QueuesStacks.Tests;
using QueuesStacks.Application;

[TestClass]
public class ShuntingYardTest
{
    [TestMethod]
    public void TestConversion1()
    {
        string expression = "3 + 4 * 2 / ( 1 - 5 )";
        string expected = "3 4 2 * 1 5 - / +";
        string actual = ShuntingYard.InfixToPostfix(expression);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestConversion2()
    {
        string expression = "3 + 4 * ( 2 - 1 )";
        string expected = "3 4 2 1 - * +";
        string actual = ShuntingYard.InfixToPostfix(expression);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void UnpairingParenthesis()
    {
        string expression = "3 + 4 * ( 2 - 1 ";
        ShuntingYard.InfixToPostfix(expression);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void InvalidOperand()
    {
        string expression = "3 + 4 * ( 2 & 1 )";
        ShuntingYard.InfixToPostfix(expression);
    }

    [TestMethod]
    public void TestEvaluation1()
    {
        string expression = "3+4*2/(1-5)";
        double expected = 1;
        double actual = ShuntingYard.EvaluateExpression(expression);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestEvaluation2()
    {
        string expression = "3+4*(2-1)";
        double expected = 7;
        double actual = ShuntingYard.EvaluateExpression(expression);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestEvaluation3()
    {
        string expression = "   3 +4* 2/( 1 -5)  ";
        double expected = 1;
        double actual = ShuntingYard.EvaluateExpression(expression);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestEvaluation4()
    {
        string expression = " 3+  4*(   2-1)  ";
        double expected = 7;
        double actual = ShuntingYard.EvaluateExpression(expression);
        Assert.AreEqual(expected, actual);
    }
}