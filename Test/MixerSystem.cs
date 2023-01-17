using NeatECS;

namespace Test;

public class MixerSystem : BaseSystem
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
                .All<MixerComponent>()
                .Any<CounterAComponent, CounterBComponent, CounterCComponent>()
                .Execute();

        foreach (var item in result)
        {
            var sumComponent = item.Get<MixerComponent>();

            if (item.Has<CounterAComponent>())
                sumComponent.sum += item.Get<CounterAComponent>().counter;

            if (item.Has<CounterBComponent>())
                sumComponent.sum += item.Get<CounterBComponent>().counter;

            if (item.Has<CounterCComponent>())
                sumComponent.sum += item.Get<CounterCComponent>().counter;

            // set updated component back
            item.Set(sumComponent);
        }
    }
}
