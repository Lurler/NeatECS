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
    /// Filters the query result to only include entities which contain the specified component.
    /// </summary>
    public Query One<T>() where T : IComponent
    {
        // If no components of given type are registered then make the result empty
        if (!world.componentData.ContainsKey(typeof(T)) || world.componentData[typeof(T)].Count == 0)
            elements = new();

        if (elements is null)
        {
            // if this is the first query, then use this set as the initial data
            elements = world.componentData[typeof(T)].Keys.ToList();
        }
        else
        {
            // otherwise intersect both sets and use the result as the new collection
            elements = elements.Intersect(world.componentData[typeof(T)].Keys).ToList();
        }

        return this;
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
}
