using System;
using System.Linq;

namespace Vernizze.Infra.CrossCutting.Extensions
{
    public static class EnumExtensions
    {
        public static Enum ParseExact<TEnum>(this Enum root, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var values = Enum.GetValues(typeof(TEnum)).Cast<Enum>();

                values.ToList().ForEach(i =>
                {
                    int value_compare = 0;

                    int.TryParse(value, out value_compare);

                    if (i.GetHashCode().Equals(value_compare))
                        root = i;
                });
            }

            return root;
        }
    }
}
