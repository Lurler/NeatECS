using NeatECS;

namespace Test;

public class CounterSystem : BaseSystem
{
    public override void OnInitialize()
    {
        // nothing to do
    }

    public override void OnUpdate(World world)
    {
        var result = world.Query().All<CounterAComponent>().Execute();
        foreach (var item in result)
        {
            var component = item.Get<CounterAComponent>();
            component.counter++;
            item.Set(component);
        }

        result = world.Query().All<CounterBComponent>().Execute();
        foreach (var item in result)
        {
            var component = item.Get<CounterBComponent>();
            component.counter++;
            item.Set(component);
        }

        result = world.Query().All<CounterCComponent>().Execute();
        foreach (var item in result)
        {
            var component = item.Get<CounterCComponent>();
            component.counter++;
            item.Set(component);
        }
    }
}
