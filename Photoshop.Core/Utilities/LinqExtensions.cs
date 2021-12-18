namespace Photoshop.Core.Utilities;

public static class LinqExtensions
{
    public static T Aggregate<T>(this IEnumerable<T> items,
                                 Func<T, T, T> aggregator,
                                 T start)
    {
        if (items == null)
            throw new ArgumentNullException(nameof(items));
        var startValue = start;
        foreach (var item in items)
        {
            startValue = aggregator(startValue, item);
        }

        return startValue;
    }
}