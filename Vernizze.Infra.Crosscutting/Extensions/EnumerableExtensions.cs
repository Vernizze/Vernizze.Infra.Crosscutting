using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vernizze.Infra.CrossCutting.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool HaveAny<T>(this IEnumerable<T> value)
        {
            var result = !ObjectExtensions.IsNull(value);

            if (result)
            {
                result = result && (value.Any());
            }

            return result;
        }

        public static bool NotContains<T>(this IEnumerable<T> value, T item)
        {
            return !value.Contains(item);
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> values, int parts)
        {
            var result = new List<List<T>>();

            if (values.HaveAny())
            {
                if (parts > values.Count())
                {
                    parts = values.Count();
                }

                if (parts > 1)
                {
                    var count = values.Count();
                    var qtt = count / parts;
                    var last_qtt = qtt + (count % parts);
                    var pos_ini = 0;

                    for (int i = 0; i < parts; i++)
                    {
                        pos_ini = qtt * i;

                        if (i == parts - 1)
                        {
                            result.Add(values.GetPart(pos_ini, last_qtt).ToList());
                        }
                        else
                        {
                            result.Add(values.GetPart(pos_ini, qtt).ToList());
                        }
                    }
                }
                else
                {
                    result.Add(values.ToList());
                }
            }

            return result;
        }

        public static IEnumerable<T> GetPart<T>(this IEnumerable<T> values, int index, int qtt)
        {
            return values.ToList().GetRange(index, qtt);
        }
    }
}
