// A part of the C# Language Syntactic Sugar suite.

using System;

namespace CLSS
{
  public static partial class IComparableInRange
  {
    /// <summary>
    /// Returns whether the source value is within the bound of
    /// <paramref name="min"/> to <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The <see cref="IComparable{T}"/> type of the values
    /// being compared.</typeparam>
    /// <param name="value">The value being checked to be in a range.</param>
    /// <param name="min">The lower bound to check
    /// <paramref name="value"/> against. By default, <paramref name="min"/>
    /// bound is inclusive.</param>
    /// <param name="max">The exclusive upper bound to check
    /// <paramref name="value"/> against. By default, <paramref name="max"/>
    /// bound is exclusive.</param>
    /// <param name="minInclusive">A value that specifies whether the range for
    /// comparison is inclusive of <paramref name="min"/>.</param>
    /// <param name="maxInclusive">A value that specifies whether the range for
    /// comparison is inclusive of <paramref name="max"/>.</param>
    /// <returns>Whether the source value is within the bound of
    /// <paramref name="min"/> to <paramref name="max"/>.</returns>
    public static bool InRange<T>(this T value, T min, T max,
      bool minInclusive = true, bool maxInclusive = false)
      where T : IComparable<T>
    {
      var minCompareRes = value.CompareTo(min);
      var maxCompareRes = value.CompareTo(max);
      return (minCompareRes > 0 || (minInclusive == (minCompareRes == 0)))
        && (maxCompareRes < 0 || (maxInclusive == (maxCompareRes == 0)));
    }

#if NETSTANDARD2_0_OR_GREATER
    /// <inheritdoc cref="InRange{T}(T, T, T, bool, bool)"/>
    /// <param name="range">A range struct containing the lower and upper bounds
    /// to check <paramref name="value"/> against. By default, it is
    /// min-inclusive and max-exclusive.</param>
    public static bool InRange<T>(this T value, ValueRange<T> range,
      bool minInclusive = true, bool maxInclusive = false)
      where T : IComparable<T>
    { return value.InRange(range.Min, range.Max, minInclusive, maxInclusive); }
#endif
  }
}