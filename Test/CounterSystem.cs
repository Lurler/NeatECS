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
        var result =
            world
                .Query()
                .One<CounterComponent>()
                .Execute();

        foreach (var item in result)
        {
            // get component
            var component = item.Get<CounterComponent>();

            // update it
            component.counter++;

            // set updated component back
            item.Set(component);
        }
    }
}
