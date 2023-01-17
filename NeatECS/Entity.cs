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

    /// <inheritdoc cref="World.SetComponent(ulong, IComponent)"/>
    public Entity Set(IComponent component)
    {
        world.SetComponent(id, component);
        return this;
    }

    /// <inheritdoc cref="World.HasComponent{T}(ulong)"/>
    public bool Has<T>() where T : IComponent
    {
        return world.HasComponent<T>(id);
    }

    /// <inheritdoc cref="World.GetComponent{T}(ulong)"/>
    public T Get<T>() where T : IComponent
    {
        return world.GetComponent<T>(id);
    }

    /// <inheritdoc cref="World.RemoveComponent{T}(ulong)"/>
    public Entity Remove<T>() where T : IComponent
    {
        world.RemoveComponent<T>(id);
        return this;
    }

    /// <inheritdoc cref="World.DestroyEntity(ulong)"/>
    public void Destroy()
    {
        world.DestroyEntity(id);
    }

}
