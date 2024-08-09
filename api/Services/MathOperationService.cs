using api.Interfaces;
using api.Request;

namespace api.Services;

public class MathOperationService : IMathOperationService
{
    public double Divide(ValuesIncoming values)
    {
        if (values.SecondValue == 0)
        {
            throw new DivideByZeroException("Division by 0 is not allowed");
        }

        double divideRes = values.FirstValue / values.SecondValue;
        ValidationResult(divideRes);
        return divideRes;
    }

    public double Multiply(ValuesIncoming values)
    {
        double multiplyRes = values.FirstValue * values.SecondValue;
        ValidationResult(multiplyRes);
        return multiplyRes;
    }

    public double Pow(ValuesIncoming values)
    {
        double powRes = Math.Pow(values.FirstValue, values.SecondValue);
        ValidationResult(powRes);
        return powRes;
    }

    public double Root(ValuesIncoming values)
    {
        if (values.SecondValue == 0)
        {
            throw new ArgumentException("You can't take the root of zero degree");
        }
        
        double result;
        if (double.IsNegative(values.FirstValue))
        {
            throw new ArgumentException("You can't take the root with a negative base");
        }
        else
        {
            result = Math.Pow(values.FirstValue, 1 / values.SecondValue);
        }
        ValidationResult(result);
        return result;
    }

    public double Subtract(ValuesIncoming values)
    {
        double subRes = values.FirstValue - values.SecondValue;
        ValidationResult(subRes);
        return subRes;
    }

    public double Sum(ValuesIncoming values)
    {
        double sumRes = values.FirstValue + values.SecondValue;
        ValidationResult(sumRes);
        return sumRes;
    }

    private void ValidationResult(double result)
    {
        if (double.IsInfinity(result))
        {
            throw new ArgumentException("Result can not be infinity");
        }

        if (double.IsNaN(result))
        {
            throw new ArgumentException("Result can not be NaN");
        }
    }
}
