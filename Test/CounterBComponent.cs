using NeatECS;

namespace Test;

public struct CounterBComponent : IComponent
{
    public int counter;

    public CounterBComponent(int counter)
    {
        this.counter = counter;
    }
}
