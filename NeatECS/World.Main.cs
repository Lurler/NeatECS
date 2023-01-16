namespace NeatECS;

public partial class World
{
    public bool IsInitialized { get; private set; } = false;

    /// <summary>
    /// Create a new ECS world.
    /// </summary>
    public World()
    {

    }

    public World Initialize()
    {
        // initializes all systems one by one
        foreach (var system in systems)
        {
            system.OnInitialize();
        }

        // prevent further modification of the systems list
        IsInitialized = true;

        return this;
    }

    /// <summary>
    /// Updates all systems registered for this world one by one and processes the entities.
    /// Only applies to systems that have not been deactivated.
    /// </summary>
    public void Update()
    {
        // update all active systems
        foreach (var system in systems) 
        {
            if (system.Active)
                system.OnUpdate(this);
        }

        // clean dead entities
        foreach (var entityId in deadEntities)
        {
            // check each component type
            foreach (var components in componentData.Values)
            {
                // remove all components belonging to this entity from the data
                components.Remove(entityId);
            }
        }

        // after removing dead entities clear the dead entities list
        deadEntities.Clear();
    }

}
