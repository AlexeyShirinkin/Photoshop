namespace Photoshop.Core.Iterators;

public class PixelWrapper<T>
{
    public T Item { get; }

    public int X { get; }

    public int Y { get; }

    public PixelWrapper(int x, int y, T item)
    {
        Y = y;
        X = x;
        Item = item;
    }
}