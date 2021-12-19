﻿namespace Photoshop.Core.Utilities;

public static class ByteExtensions
{
    public static byte ToByte(this int number)
    {
        return number switch
        {
            > byte.MaxValue => byte.MaxValue,
            < 0 => 0,
            _ => (byte) number
        };
    }
}