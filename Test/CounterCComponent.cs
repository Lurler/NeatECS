using NeatECS;

namespace Test;

public struct CounterCComponent : IComponent
{
    public int counter;

    public CounterCComponent(int counter)
    {
        this.counter = counter;
    }
}
