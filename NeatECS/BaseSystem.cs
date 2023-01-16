namespace NeatECS;

/// <summary>
/// All user created systems must inherit from this class.
/// </summary>
public abstract class BaseSystem
{
    internal bool Active = true;

    /// <summary>
    /// Called once on system initialization.
    /// Could be used to prepare resources or load some data.
    /// </summary>
    public abstract void OnInitialize();

    /// <summary>
    /// Called every frame.
    /// </summary>
    public abstract void OnUpdate(World world);

}
