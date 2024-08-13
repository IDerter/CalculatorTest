using api.Interfaces;

public class ExpressionsCalculateService : IExpressionsCalculateService
{
	public void Eval(string input)
	{
		var ans = Evaluate(input);
		Console.WriteLine(input + " = " + ans);
	}

	public double Evaluate(String input)
	{
		String expr = "(" + input + ")";
		Stack<String> ops = new Stack<String>();
		Stack<Double> vals = new Stack<Double>();

		for (int i = 0; i < expr.Length; i++)
		{
			String s = expr.Substring(i, 1);
			if (s.Equals("(")) { }
			else if (s.Equals("+")) ops.Push(s);
			else if (s.Equals("-")) ops.Push(s);
			else if (s.Equals("*")) ops.Push(s);
			else if (s.Equals("/")) ops.Push(s);
			else if (s.Equals("sqrt")) ops.Push(s);
			else if (s.Equals(")"))
			{
				int count = ops.Count;
				while (count > 0)
				{
					String op = ops.Pop();
					double v = vals.Pop();
					if (op.Equals("+")) v = vals.Pop() + v;
					else if (op.Equals("-")) v = vals.Pop() - v;
					else if (op.Equals("*")) v = vals.Pop() * v;
					else if (op.Equals("/")) v = vals.Pop() / v;
					else if (op.Equals("sqrt")) v = Math.Sqrt(v);
					vals.Push(v);

					count--;
				}
			}
			else vals.Push(Double.Parse(s));
		}
		return vals.Pop();
	}
}
