using NeatECS;

namespace Test;

public struct CounterAComponent : IComponent
{
    public int counter;

    public CounterAComponent(int counter)
    {
        this.counter = counter;
    }
}
