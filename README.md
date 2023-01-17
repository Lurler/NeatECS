# NeatECS
**NeatECS** is a clean and easy to use Entity Component System (ECS) framework. It is developed in pure C# with no dependencies.

The goal of this framework is to make working with ECS in your projects as easy as it can possibly be. It offers a clean, minimalist, and fully documented API that is easy to learn and use.

## Installation
Use provided nuget package or download the source.

:wrench: Nuget: `dotnet add package NeatECS`

## Quick start
First, create a world and add some systems that you want to run in your game.

```cs
// create the world
World world = new();

// add some systems and initialize the world
world
	.AddSystem<TransformSystem>()
	.AddSystem<AISystem>()
	.AddSystem<PhysicsSystem>()
	.AddSystem<DamageSystem>()
	.Initialize();
```

Next, create some entities. Here's a an example how your entity could look.

```cs
var entity = world.NewEntity();
entity
	.Set(new NameComponent("Goblin"))
	.Set(new TransformComponent(5, 5))
	.Set(new HealthComponent(100))
	.Set(new DamageComponent(25))
	.Set(new AIComponent(AITypes.Aggressive));
```

And finally put the following inside your Update loop.

```cs
world.Update();
```

That's it!

## API explanation
Below is a detailed API explanation. You can also use comments included directly in the code when using the framework.

### World
First, create an instance of the world. You can have as many worlds as you want. They are completely separate and do not interact between each other.
```cs 
World world = new();
```

Next, you need to register one more more systems that will be run in this world. The order in which systems will be executed is the same in which they are added.
```cs
world
	.AddSystem<SystemA>()
	.AddSystem<SystemB>()
	.AddSystem<SystemC>();
```

Finally, you need to initialize the world. It will initialize all of the systems and prevent further alterations of the world configuration.
```cs
world.Initialize();
```

To run the world you need to call Update in the main loop of your game.
```cs
world.Update();
```

### Systems
Below is an example implementation of a system which simply increments a counter on an entity. As in this example your systems must inherit from `BaseSystem`.
```cs
public class CounterSystem : BaseSystem
{
	public override void OnInitialize()
	{
		// nothing to do
	}

	public override void OnUpdate(World world)
	{
		// get all entities that have "CounterComponent" attached
		var result =
			world.Query()
				.All<CounterComponent>()
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
```

Systems can be disabled and enabled at any time. For example if you have an AI or physics system but want to disable it for some reason during the execution of your game you can do so.
```cs
// disable a system
world.SetSystemState<SomeSystem>(false);

// enable a system
world.SetSystemState<SomeSystem>(true);
```

### Entity
Entity is a `struct` with only a few functions. You cannot directly create an instance of an entity, but you can ask the world to create one for you.
```cs
var entity = world.NewEntity();
```

Then you can attach components to it. Please note that adding a component of the same type will override the existing component. In fact, this is how you *should* modify you component's data. Components are structs and thus passed by value, so you cannot modify them by reference.
```cs
entity.Set(new TransformComponent(10, 10));
```

You can get a component of a particular type from an entity.
```cs
var component = entity.Get<SomeComponent>();
```

Finally, you can remove a particular component from an entity.
```cs
entity.Remove<SomeComponent>();
```

If you want to clear components of a particular type from ALL entities in the world you can use the following.
```cs
world.CleanComponent<SomeComponent>();
```

Entities can also be destroyed, which simply means that all attached components will be removed. When you call this method it will mark the entity as "Dead" but the actual removal happens at the end of each update cycle.
```cs
entity.Destroy();
```

You can check if a given entity is alive.
```cs
entity.IsAlive
```

### Components
To create a component you need to create a `struct` and inherit `IComponent` interface.
```cs
public struct CounterComponent : IComponent
{
    public int counter;

    public CounterComponent(int counter)
    {
        this.counter = counter;
    }
}
```

### Query
You can query components from the world by using `All`, `Any` and `None` clauses. These clauses can be combined and chained in any way. The only exception is you cannot start your query with the `None` clause.

Here's an example query that will return entities that contain both A and B, contain at least one C or D but don't contain Z. You can include several types in the same clause.
```cs
var result =
	world.Query()
		.All<ComponentA, ComponentB>()
		.Any<ComponentC, ComponentD>()
		.None<ComponentZ>()
		.Execute();
```

After you execute the query you will get a list of entities that fulfill the specified clauses.

## Performance
This framework is by no means the fastest. If you need to manage tens of thousands of entities with dozens of systems running concurrently it is recommended to use a more advanced framework. But if you are making a hobby project or a small game the performance it offers should be enough.

Below are two benchmarks with the following configuration:
 - Entities are randomly assigned between 1 and 4 components.
 - Two systems are running every frame.
 - Counter system: makes 3 queries, one for each component type (A, B, C), then it simply increments a counter on the corresponding component.
 - Mixer system: makes a complex query and gets all entities containing the mixer component and at least one counter component (A, B or C), then adds their value to the mixer component value.
 - The update call is run 1000 times to get a more accurate average time for a single update call.

Here's the benchmark for 1000 entities:
 - Initialization: < 1 ms.
 - Creating 1000 entities: ~1 ms.
 - Updating: ~0.5 ms

Here's the benchmark for 10,000 entities:
 - Initialization: < 1 ms.
 - Creating 10,000 entities: ~2 ms.
 - Updating: ~4.5 ms

As you can see the performance should be enough for the purposes this framework is created for. You can also run the test project included in the source to see the performance on your machine.

## Changes
 - v1.1 - Bugfixes & some improvements, updated documentation, updated test project.
 - v1.0 - Initial release.

## Contribution
Contributions are welcome!

You can start with submitting an [issue on GitHub](https://github.com/Lurler/NeatECS/issues).

## License
**NeatECS** is released under the [MIT License](../master/LICENSE).