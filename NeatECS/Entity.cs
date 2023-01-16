namespace NeatECS;

public readonly struct Entity
{
    private readonly ulong id;
    private readonly World world;

    /// <summary>
    /// Check if this entity is still alive.
    /// </summary>
    public bool IsAlive => world.IsEntityAlive(id);

    /// <summary>
    /// Entity object cannot be created manually.
    /// </summary>
    internal Entity(World world, ulong id)
    {
        this.world = world;
        this.id = id;
    }

    /// <summary>
    /// Adds a new component to the entity or replaces an existing one.
    /// </summary>
    public Entity Set(IComponent component)
    {
        world.SetComponent(id, component);
        return this;
    }

    /// <summary>
    /// Returns a component of a given type or null if no such component exists.
    /// </summary>
    public T? Get<T>() where T : IComponent
    {
        return world.GetComponent<T>(id);
    }

    /// <summary>
    /// Removes a component from the entity (if it was present).
    /// </summary>
    public Entity Remove<T>() where T : IComponent
    {
        world.RemoveComponent<T>(id);
        return this;
    }

    /// <summary>
    /// Marks this entity as "deleted" for removal at the end of the next update cycle.
    /// To be more specific it removes all components that are associated with this entity ID.
    /// </summary>
    public void Destroy()
    {
        world.DestroyEntity(id);
    }

}
