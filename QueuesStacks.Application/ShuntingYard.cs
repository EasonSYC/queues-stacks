using System;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using QueuesStacks.Application;

namespace QueuesStacks.Application
{
	public class ShuntingYard
	{
		public static double EvaluateExpression(string expression)
		{
			expression = expression.Replace(" ", "");
			string infix = string.Empty;

			for (int i = 0; i < expression.Length; )
			{
				if (!(char.IsDigit(expression[i]) || expression[i] == '.'))
				{
					infix += expression[i] + " ";
					++i;
				}
				else
				{
					int len = 0;

					for (; (i + len) < expression.Length && (char.IsDigit(expression[i + len]) || expression[i + len] == '.'); ++len);

					infix += expression.Substring(i, len) + " ";

					i += len;
				}
			}

			return PolishNotation.PostfixNotation(InfixToPostfix(infix.Trim()));
		}

		public static string InfixToPostfix(string infixNotation)
		{
			string[] tokens = infixNotation.Split(' ');

			Queue<string> outputQueue = new();
			Stack<string> operatorStack = new();

			for (int i = 0; i < tokens.Length; ++i)
			{
				string token = tokens[i];

				if (double.TryParse(token, out double num))
				{ 
					outputQueue.Enqueue(token);
				}
				else if (token == "(")
				{
					operatorStack.Push(token);
				}
				else if (token == ")")
				{
					bool error = true;
					while (operatorStack.Count != 0)
					{
						if (operatorStack.Peek() == "(")
						{
							error = false;
							break;
						}
						else
						{
							outputQueue.Enqueue(operatorStack.Pop());
						}
					}

					if (error)
					{
						throw new InvalidOperationException("Invalid expression: parenthesis do not match.");
					}

					operatorStack.Pop();
				}
				else if (token == "+" || token == "-")
				{
					while (operatorStack.Count != 0 && operatorStack.Peek() != "(")
					{
						outputQueue.Enqueue(operatorStack.Pop());
					}

					operatorStack.Push(token);
				}
				else if (token == "*" || token == "/")
				{
					while (operatorStack.Count != 0 && (operatorStack.Peek() == "*" || operatorStack.Peek() == "/"))
					{
						outputQueue.Enqueue(operatorStack.Pop());
					}

					operatorStack.Push(token);
				}
				else
				{
					throw new InvalidOperationException("Invalid expression: " + token);
				}
			}

			while (operatorStack.Count != 0)
			{
				if (operatorStack.Peek() == "(" || operatorStack.Peek() == ")")
				{
					throw new InvalidOperationException("Invalid expression: parenthesis do not match.");
				}

				outputQueue.Enqueue(operatorStack.Pop());
			}

			string returnStr = string.Empty;
			while (outputQueue.Count != 0)
			{
				returnStr += outputQueue.Dequeue();
				returnStr += " ";
			}

			returnStr = returnStr.Trim();
			
			return returnStr;
		}
	}
}