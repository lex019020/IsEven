namespace IsEven.Services;

public class MultiThreadEvenCalculator : IEvenCalculator
{
    public ValueTask<bool> IsEven(int number)
    {
        var isEven = true;
        object locker = new();

        Parallel.For(0, number, (i, state) =>
            {
                lock (locker)
                {
                    isEven = !isEven;
                }
            });

        return ValueTask.FromResult(isEven);
    }
}