namespace NeatECS;

public partial class World
{
    /// <summary>
    /// List which stores all systems for this world.
    /// Order of execution for all systems is the order in which they are added.
    /// </summary>
    private readonly List<BaseSystem> systems = new();

    /// <summary>
    /// Add a new system to the world.
    /// </summary>
    public World AddSystem<T>() where T : BaseSystem
    {
        // check if the world has already been initialized
        if (IsInitialized)
            throw new InvalidOperationException("World has already been initialized. Further systems changes are not allowed.");

        // check if system is already added
        if (systems.OfType<T>().Any())
            throw new ArgumentException("System of specified type is already registered in the world.");

        // create an instance of this system
        var system = Activator.CreateInstance<T>();

        // add it to the list of systems for this world
        systems.Add(system);

        return this;
    }

    /// <summary>
    /// Enable of disable a particular system.
    /// </summary>
    public World SetSystemState<T>(bool active) where T : BaseSystem
    {
        // check if system of specified type exists
        if (!systems.OfType<T>().Any())
            throw new ArgumentException("Specified system is not registered in the world.");

        // enable or disable this system
        systems.OfType<T>().First().Active = active;

        return this;
    }

}
