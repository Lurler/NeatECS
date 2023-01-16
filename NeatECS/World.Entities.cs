namespace NeatECS;

public partial class World
{
    /// <summary>
    /// There is a dictionary for each type of components.
    /// When a component of new type is added a new dictionary is created.
    /// Structure is:
    ///     [component-type, [entity-id, component-instance] ]
    /// </summary>
    internal readonly Dictionary<Type, Dictionary<ulong, IComponent>> componentData = new();

    /// <summary>
    /// ID for the next entity to be created.
    /// </summary>
    private ulong nextID = 0;

    /// <summary>
    /// Collection of dead entities.
    /// All dead entities will be cleaned from the world at the end of update cycle.
    /// </summary>
    private readonly HashSet<ulong> deadEntities = new();

    /// <summary>
    /// Creates a new entity and returns it.
    /// </summary>
    public Entity NewEntity()
    {
        return new Entity(this, nextID++);
    }

    /// <summary>
    /// Adds a component to an entity or replaces it with a new copy.
    /// </summary>
    internal void SetComponent(ulong id, IComponent component)
    {
        // create the dictionary for this particular component type if it doesn't exists
        if (!componentData.ContainsKey(component.GetType()))
            componentData[component.GetType()] = new();

        // now handle this particular component instance
        componentData[component.GetType()][id] = component;
    }

    /// <summary>
    /// Returns a component of a given type or null if no such component exists.
    /// </summary>
    public T? GetComponent<T>(ulong id) where T : IComponent
    {
        if (!componentData.ContainsKey(typeof(T)) || !componentData[typeof(T)].ContainsKey(id))
            return default;

        return (T)componentData[typeof(T)][id];
    }

    /// <summary>
    /// Removes a component from the entity (if it was present).
    /// </summary>
    internal void RemoveComponent<T>(ulong id) where T : IComponent
    {
        // check if this type of components have been initialized
        if (!componentData.ContainsKey(typeof(T)))
            return;

        // now remove the component if it's present
        componentData[typeof(T)].Remove(id);
    }

    /// <summary>
    /// Removes a particular component type from all entities.
    /// </summary>
    public World CleanComponent<T>() where T : IComponent
    {
        // clear this component type, but only if it has already been initialized
        if (componentData.ContainsKey(typeof(T)))
            componentData[typeof(T)].Clear();

        return this;
    }

    /// <summary>
    /// Checks if entity is alive.
    /// </summary>
    internal bool IsEntityAlive(ulong id)
    {
        return !deadEntities.Contains(id);
    }

    /// <summary>
    /// Adds entity to the dead list to be cleaned at the end of update cycle.
    /// </summary>
    internal void DestroyEntity(ulong id)
    {
        deadEntities.Add(id);
    }

    /// <summary>
    /// Start entity query for this world.
    /// Sequence:
    ///     start query -> apply desired filters -> get result
    /// </summary>
    public Query Query()
    {
        return new Query(this);
    }

}
