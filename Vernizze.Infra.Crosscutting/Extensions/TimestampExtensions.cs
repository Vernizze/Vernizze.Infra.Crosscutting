using System;

namespace Vernizze.Infra.CrossCutting.Extensions
{
    public static class TimestampExtensions
    {
        public static double ToTimestamp(this DateTime date)
        {
            return (double)(date.Subtract(DateTime.UtcNow)).TotalSeconds;
        }

        public static TimeSpan ToUTCTimeSpan(this DateTime date)
        {
            return date.Subtract(DateTime.UtcNow);
        }

        public static TimeSpan ToTimeSpan(this DateTime date)
        {
            return date.Subtract(DateTime.Now);
        }

        public static bool IsNull(this DateTime? date)
        {
            return !(date.HasValue && (date >= new DateTime(1970, 1, 1, 1, 1, 1)));
        }
    }
}
