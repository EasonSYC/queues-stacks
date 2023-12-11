namespace QueuesStacks.Application;

public class PolishNotation // introduce idea of binary tree traversal
                            // we will use the built in stacks
{
    public static int CalcPolish(string str) // Calculate for polish notation / prefix notation
    {
        string[] split = str.Split();

        Stack<int> stack = new();

        for (int i = split.Length - 1; i >= 0; --i)
        {
            switch (split[i])
            {
                case "+":
                    stack.Push(stack.Pop() + stack.Pop());
                    break;
                case "-":
                    stack.Push(stack.Pop() - stack.Pop());
                    break;
                case "*":
                    stack.Push(stack.Pop() * stack.Pop());
                    break;
                case "/":
                    stack.Push(stack.Pop() / stack.Pop());
                    break;
                default:
                    stack.Push(int.Parse(split[i]));
                    break;
            }
        }

        return stack.Peek();
    }

    public static int CalcInfix(string str) // Calculate for infix notation / normal notation
    {
        throw new NotImplementedException();
    }

    public static int CalcRevPolish(string str) // Calculate for inverse polish notation / postfix notation
    {
        throw new NotImplementedException();
    }

}
