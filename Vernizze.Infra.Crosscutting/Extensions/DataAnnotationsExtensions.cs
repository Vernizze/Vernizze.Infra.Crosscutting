using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Vernizze.Infra.CrossCutting.Extensions
{
    public static class DataAnnotationsExtensions
    {
        public static string Description(this Enum enumerador)
        {
            var fi = enumerador.GetType().GetField(enumerador.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return enumerador.ToString();
        }

        public static string Description(this Type _class)
        {
            var attr = _class.GetCustomAttributes(typeof(DescriptionAttribute), false)
                             .FirstOrDefault()
                             as DescriptionAttribute;

            return attr.Description;
        }
    }
}
