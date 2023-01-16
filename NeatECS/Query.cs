namespace NeatECS;

public class Query
{
    /// <summary>
    /// Reference to the world we are querrying
    /// </summary>
    private readonly World world;

    /// <summary>
    /// Current query result. Null means we have not pulled any data yet.
    /// </summary>
    private List<ulong>? elements = null;

    /// <summary>
    /// Query object cannot be created manually.
    /// </summary>
    internal Query(World world)
    {
        this.world = world;
    }

    /// <summary>
    /// Returns the final result in the form of list of entities.
    /// </summary>
    public List<Entity> Execute()
    {
        // return empty list if there are no results
        if (elements is null)
            return new();

        // otherwise create a list of entities from the IDs that we have
        return elements.Select(e => new Entity(world, e)).ToList();
    }

    /// <summary>
    /// Filter the result such that only entities that contain all specified component types remain.
    /// </summary>
    private void InternalAll(Type[] types)
    {
        foreach (var t in types)
        {
            // if no components of given type are registered then make the result empty and return
            if (!world.componentData.ContainsKey(t) || world.componentData[t].Count == 0)
            {
                elements = new();
                return;
            }

            // start filtering
            if (elements is null)
            {
                // if this is the first type checked, then use this set as the initial data
                elements = world.componentData[t].Keys.ToList();
                continue;
            }

            // otherwise intersect both sets and use the result as the new collection
            elements = elements.Intersect(world.componentData[t].Keys).ToList();
        }
    }

    /// <summary>
    /// Filter the result such that only entities that contain at least one of the specified component types remain.
    /// </summary>
    private void InternalAny(Type[] types)
    {
        foreach (var t in types)
        {
            // if no components of given type are registered then proceed to next type
            if (!world.componentData.ContainsKey(t) || world.componentData[t].Count == 0)
            {
                continue;
            }

            // start filtering
            if (elements is null)
            {
                // if this is the first type checked, then use this set as the initial data
                elements = world.componentData[t].Keys.ToList();
                continue;
            }

            // otherwise creates a new list that is union of both previous sets
            elements = elements.Union(world.componentData[t].Keys).ToList();
        }
    }

    /// <summary>
    /// Filter the result such that only entities that don't contain any of the specified component types remain.
    /// Must not be the first filter applied.
    /// </summary>
    private void InternalNone(Type[] types)
    {
        if (elements is null)
            throw new InvalidOperationException(@"""None"" filter cannot be the first filter applied to the query.");

        foreach (var t in types)
        {
            // if no components of given type are registered then proceed to next type
            if (!world.componentData.ContainsKey(t) || world.componentData[t].Count == 0)
            {
                continue;
            }

            // exclude elements of a given type
            elements = elements.Except(world.componentData[t].Keys).ToList();
        }
    }

    /// <inheritdoc cref="InternalAll"/>
    public Query All<T0>()
    where T0 : IComponent
    {
        var types = new Type[1] { typeof(T0) };
        InternalAll(types);
        return this;
    }

    /// <inheritdoc cref="InternalAll"/>
    public Query All<T0, T1>()
    where T0 : IComponent
    where T1 : IComponent
    {
        var types = new Type[2] { typeof(T0), typeof(T1) };
        InternalAll(types);
        return this;
    }

    /// <inheritdoc cref="InternalAll"/>
    public Query All<T0, T1, T2>()
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
    {
        var types = new Type[3] { typeof(T0), typeof(T1), typeof(T2) };
        InternalAll(types);
        return this;
    }

    /// <inheritdoc cref="InternalAll"/>
    public Query All<T0, T1, T2, T3>()
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
    where T3 : IComponent
    {
        var types = new Type[4] { typeof(T0), typeof(T1), typeof(T2), typeof(T3) };
        InternalAll(types);
        return this;
    }

    /// <inheritdoc cref="InternalAll"/>
    public Query All<T0, T1, T2, T3, T4>()
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
    where T3 : IComponent
    where T4 : IComponent
    {
        var types = new Type[5] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4) };
        InternalAll(types);
        return this;
    }

    /// <inheritdoc cref="InternalAny"/>
    public Query Any<T0>()
    where T0 : IComponent
    {
        var types = new Type[1] { typeof(T0) };
        InternalAny(types);
        return this;
    }

    /// <inheritdoc cref="InternalAny"/>
    public Query Any<T0, T1>()
    where T0 : IComponent
    where T1 : IComponent
    {
        var types = new Type[2] { typeof(T0), typeof(T1) };
        InternalAny(types);
        return this;
    }

    /// <inheritdoc cref="InternalAny"/>
    public Query Any<T0, T1, T2>()
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
    {
        var types = new Type[3] { typeof(T0), typeof(T1), typeof(T2) };
        InternalAny(types);
        return this;
    }

    /// <inheritdoc cref="InternalAny"/>
    public Query Any<T0, T1, T2, T3>()
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
    where T3 : IComponent
    {
        var types = new Type[4] { typeof(T0), typeof(T1), typeof(T2), typeof(T3) };
        InternalAny(types);
        return this;
    }

    /// <inheritdoc cref="InternalAny"/>
    public Query Any<T0, T1, T2, T3, T4>()
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
    where T3 : IComponent
    where T4 : IComponent
    {
        var types = new Type[5] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4) };
        InternalAny(types);
        return this;
    }

    /// <inheritdoc cref="InternalNone"/>
    public Query None<T0>()
    where T0 : IComponent
    {
        var types = new Type[1] { typeof(T0) };
        InternalNone(types);
        return this;
    }

    /// <inheritdoc cref="InternalNone"/>
    public Query None<T0, T1>()
    where T0 : IComponent
    where T1 : IComponent
    {
        var types = new Type[2] { typeof(T0), typeof(T1) };
        InternalNone(types);
        return this;
    }

    /// <inheritdoc cref="InternalNone"/>
    public Query None<T0, T1, T2>()
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
    {
        var types = new Type[3] { typeof(T0), typeof(T1), typeof(T2) };
        InternalNone(types);
        return this;
    }

    /// <inheritdoc cref="InternalNone"/>
    public Query None<T0, T1, T2, T3>()
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
    where T3 : IComponent
    {
        var types = new Type[4] { typeof(T0), typeof(T1), typeof(T2), typeof(T3) };
        InternalNone(types);
        return this;
    }

    /// <inheritdoc cref="InternalNone"/>
    public Query None<T0, T1, T2, T3, T4>()
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
    where T3 : IComponent
    where T4 : IComponent
    {
        var types = new Type[5] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4) };
        InternalNone(types);
        return this;
    }
}
