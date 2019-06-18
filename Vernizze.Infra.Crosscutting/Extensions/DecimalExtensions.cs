using System;

namespace Vernizze.Infra.CrossCutting.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal TruncDuasCasasDecimais(this decimal value)
        {
            var result = 0M;

            result = Math.Truncate(100 * value) / 100;

            return result;
        }
    }
}
