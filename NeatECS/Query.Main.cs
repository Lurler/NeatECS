namespace NeatECS;

public partial class Query
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
        // how many types have we found?
        var found = 0;

        // temporary results results
        List<ulong> temp = new();

        foreach (var t in types)
        {
            // if no components of given type are registered then proceed to next type
            if (!world.componentData.ContainsKey(t) || world.componentData[t].Count == 0)
                continue;

            // so, we found something
            found++;

            // include this data
            temp = temp.Union(world.componentData[t].Keys).ToList();
        }

        // if we haven't found at least one desired type, then this clause is not fulfilled, so make the results empty
        if (found > 0)
            elements = elements?.Intersect(temp).ToList() ?? temp;
        else
            elements = new();
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

}
