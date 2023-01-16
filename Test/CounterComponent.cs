using NeatECS;

namespace Test;

public struct CounterComponent : IComponent
{
    public int counter;

    public CounterComponent(int counter)
    {
        this.counter = counter;
    }
}
