using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace api.Interfaces;

public interface IExpressionsOperators
{
    public double CalculateExpressions(ValuesExpression values);
}
