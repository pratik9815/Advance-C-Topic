

using System.Numerics;

namespace DataProcessor;

public class MathOperation<T> where T : INumber<T>
{
    public T Add(T first, T second)
    {
        return first + second;
    }
}
