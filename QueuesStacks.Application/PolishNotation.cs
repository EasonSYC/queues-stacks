namespace QueuesStacks.Application;

public class PolishNotation
{
    public static double PrefixNotation(string expression)
    {
        string[] tokens = expression.Split(' ');
        Stack<double> operandStack = new Stack<double>();

        for (int i = tokens.Length - 1; i >= 0; i--)
        {
            string token = tokens[i];

            if (double.TryParse(token, out double operand))
            {
                operandStack.Push(operand);
            }
            else
            {
                if (operandStack.Count < 2)
                {
                    throw new InvalidOperationException("Invalid expression : not enough operands");
                }

                double operand2 = operandStack.Pop();
                double operand1 = operandStack.Pop();

                switch (token)
                {
                    case "+":
                        operandStack.Push(operand2 + operand1);
                        break;
                    case "-":
                        operandStack.Push(operand2 - operand1);
                        break;
                    case "*":
                        operandStack.Push(operand2 * operand1);
                        break;
                    case "/":
                        operandStack.Push(operand2 / operand1);
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operator: " + token);
                }
            }
        }

        if (operandStack.Count != 1)
        {
            throw new InvalidOperationException("Invalid expression: too many operands");
        }

        return operandStack.Pop();
    }

    public static double PostfixNotation(string expression)
    {
        string[] tokens = expression.Split(' ');
        Stack<double> operandStack = new Stack<double>();

        foreach (string token in tokens)
        {
            if (double.TryParse(token, out double operand))
            {
                operandStack.Push(operand);
            }
            else
            {
                if (operandStack.Count < 2)
                {
                    throw new InvalidOperationException("Invalid expression: not enough operands");
                }

                double operand2 = operandStack.Pop();
                double operand1 = operandStack.Pop();

                switch (token)
                {
                    case "+":
                        operandStack.Push(operand1 + operand2);
                        break;
                    case "-":
                        operandStack.Push(operand1 - operand2);
                        break;
                    case "*":
                        operandStack.Push(operand1 * operand2);
                        break;
                    case "/":
                        operandStack.Push(operand1 / operand2);
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operator: " + token);
                }
            }
        }
        if (operandStack.Count != 1)
        {
            throw new InvalidOperationException("Invalid expression: too many operands");
        }

        return operandStack.Pop();
    }

}
