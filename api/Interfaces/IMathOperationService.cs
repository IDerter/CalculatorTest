using api.Request;

namespace api.Interfaces;

public interface IMathOperationService
{
        public double Sum(ValuesIncoming values);
        public double Subtract(ValuesIncoming values);
        public double Divide(ValuesIncoming values);
        public double Multiply(ValuesIncoming values);
        public double Pow(ValuesIncoming values);
        public double Root(ValuesIncoming values);
}
