using System;

namespace Shared.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsBefore(this DateTime dt, DateTime otherTime)
        {
            return dt.CompareTo(otherTime) < 0;
        }
    }
}