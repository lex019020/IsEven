namespace IsEven.Services;

public interface IEvenCalculator
{
    public ValueTask<bool> IsEven(int number);
}