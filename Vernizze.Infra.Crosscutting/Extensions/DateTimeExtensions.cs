using System;

namespace Vernizze.Infra.CrossCutting.Extensions
{
    public static class  DateTimeExtensions
    {
        public static bool InBetweenTimes(this DateTime compare, DateTime ini_date, DateTime end_date)
        {
            return (compare >= ini_date && compare <= end_date);
        }

        public static DateTime ReplaceHour(this DateTime base_date, DateTime hour_date)
        {
            return new DateTime(base_date.Year, base_date.Month, base_date.Day, hour_date.Hour, hour_date.Minute, hour_date.Second);
        }

        public static DateTime ReplaceHourWithoutSeconds(this DateTime base_date, DateTime hour_date)
        {
            return new DateTime(base_date.Year, base_date.Month, base_date.Day, hour_date.Hour, hour_date.Minute, 0);
        }

        public static DateTime ReplaceHourWithoutSeconds(this DateTime base_date, TimeSpan hour_date)
        {
            return new DateTime(base_date.Year, base_date.Month, base_date.Day, hour_date.Hours, hour_date.Minutes, 0);
        }

        public static long GetTimestamp(this DateTime value)
        {
            return (Int32)(value.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static long GetUTCTimestamp(this DateTime value)
        {
            return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
        
        public static DateTime DateFirstSecond(this DateTime base_date, DateTime date)
        {
            return date.Date;
        }

        public static DateTime DateLastSecond(this DateTime base_date, DateTime date)
        {
            return date.Date.AddDays(1).AddTicks(-1);
        }

        public static DateTime TodayFirstSecond(this DateTime base_date)
        {
            return DateFirstSecond(base_date, DateTime.UtcNow);
        }

        public static DateTime TodayLastSecond(this DateTime base_date)
        {
            return DateLastSecond(base_date, DateTime.UtcNow.Date);
        }

        public static DateTime TomorrowFirstSecond(this DateTime base_date)
        {
            return DateFirstSecond(base_date, DateTime.UtcNow.AddDays(1));
        }
    }
}
