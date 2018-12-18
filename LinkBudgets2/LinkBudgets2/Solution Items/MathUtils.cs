using System;

/// <summary>
/// Helper class for math stuff
/// </summary>
public static class MathUtils
{
    /// <summary>
    /// Calculate x to the power of 2, doing explicit casting
    /// </summary>
    /// <param name="x">X</param>
    /// <returns></returns>
    public static float Pow2Float(float x)
    {
        return (float)Math.Pow((double)x, (double)2.0f);
    }

    /// <summary>
    /// Calculate 10 to the power of x, doing explicit casting
    /// </summary>
    /// <param name="x">X</param>
    /// <returns></returns>
    public static float TenPowXFloat(float x)
    {
        return (float)Math.Pow((double)10.0f, (double)x);
    }

    /// <summary>
    /// Calculate base 10 log of x, doing explicit casting
    /// </summary>
    /// <param name="x">X</param>
    /// <returns></returns>
    public static float Log10Float(float x)
    {
        return (float)Math.Log10((double)x);
    }
}
