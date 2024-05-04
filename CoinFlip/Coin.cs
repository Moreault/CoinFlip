namespace ToolBX.CoinFlip;

/// <summary>
/// Simple methods that return a random result out of two options.
/// </summary>
public static class Coin
{
    /// <summary>
    /// Randomly returns either true or false.
    /// </summary>
    public static bool Flip() => Flip(true, false);

    /// <summary>
    /// Randomly returns one of two options.
    /// </summary>
    public static T? Flip<T>(T? heads, T? tails)
    {
        var result = Random.Shared.Next(0, 2);
        return result == 0 ? heads : tails;
    }

    /// <summary>
    /// Randomly returns one of two options.
    /// </summary>
    public static T? Flip<T>(Func<T?> heads, Func<T?> tails)
    {
        if (heads is null) throw new ArgumentNullException(nameof(heads));
        if (tails is null) throw new ArgumentNullException(nameof(tails));

        var result = Random.Shared.Next(0, 2);
        return result == 0 ? heads.Invoke() : tails.Invoke();
    }

    /// <summary>
    /// Randomly executes one of two actions.
    /// </summary>
    public static void Flip(Action heads, Action tails)
    {
        if (heads is null) throw new ArgumentNullException(nameof(heads));
        if (tails is null) throw new ArgumentNullException(nameof(tails));

        var result = Random.Shared.Next(0, 2);
        if (result == 0) heads.Invoke();
        else tails.Invoke();
    }

    /// <summary>
    /// Randomly returns a value or its default (possibly null).
    /// </summary>
    public static T? FlipOrDefault<T>(T heads) => Flip(heads, default);

    /// <summary>
    /// Randomly returns a result or default (possibly null).
    /// </summary>
    public static T? FlipOrDefault<T>(Func<T> heads) => Flip(heads, () => default);

    /// <summary>
    /// Randomly executes an action or not.
    /// </summary>
    public static void Flip(Action heads) => Flip(heads, () => {});
}