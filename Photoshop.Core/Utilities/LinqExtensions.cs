namespace Photoshop.Core.Utilities;

public static class LinqExtensions
{
    public static T Aggregate<T>(this IEnumerable<T> items,
                                 Func<T, T, T> aggregator,
                                 T start)
    {
        if (items == null)
            throw new ArgumentNullException(nameof(items));

        return items.Aggregate(start, aggregator);
    }
}