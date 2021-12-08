namespace Photoshop.Core.Utilities;

public static class ByteExtensions
{
    public static byte ToByte(this int number)
    {
        if (number > byte.MaxValue)
            return byte.MaxValue;
        if (number < 0)
            return 0;
        return (byte)number;
    }
}