namespace NeatECS;

public partial class Query
{
    # region All

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

    /// <inheritdoc cref="InternalAll"/>
    public Query All<T0, T1, T2, T3, T4, T5>()
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
    where T3 : IComponent
    where T4 : IComponent
    where T5 : IComponent
    {
        var types = new Type[6] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) };
        InternalAll(types);
        return this;
    }

    /// <inheritdoc cref="InternalAll"/>
    public Query All<T0, T1, T2, T3, T4, T5, T6>()
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
    where T3 : IComponent
    where T4 : IComponent
    where T5 : IComponent
    where T6 : IComponent
    {
        var types = new Type[7] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) };
        InternalAll(types);
        return this;
    }

    #endregion

    #region Any

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

    /// <inheritdoc cref="InternalAny"/>
    public Query Any<T0, T1, T2, T3, T4, T5>()
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
    where T3 : IComponent
    where T4 : IComponent
    where T5 : IComponent
    {
        var types = new Type[6] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4) , typeof(T5) };
        InternalAny(types);
        return this;
    }

    /// <inheritdoc cref="InternalAny"/>
    public Query Any<T0, T1, T2, T3, T4, T5, T6>()
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
    where T3 : IComponent
    where T4 : IComponent
    where T5 : IComponent
    where T6 : IComponent
    {
        var types = new Type[7] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) };
        InternalAny(types);
        return this;
    }

    #endregion

    #region None

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

    /// <inheritdoc cref="InternalNone"/>
    public Query None<T0, T1, T2, T3, T4, T5>()
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
    where T3 : IComponent
    where T4 : IComponent
    where T5 : IComponent
    {
        var types = new Type[6] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) };
        InternalNone(types);
        return this;
    }

    /// <inheritdoc cref="InternalNone"/>
    public Query None<T0, T1, T2, T3, T4, T5, T6>()
    where T0 : IComponent
    where T1 : IComponent
    where T2 : IComponent
    where T3 : IComponent
    where T4 : IComponent
    where T5 : IComponent
    where T6 : IComponent
    {
        var types = new Type[7] { typeof(T0), typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) };
        InternalNone(types);
        return this;
    }

    #endregion

}
