using System;

namespace Vernizze.Infra.CrossCutting.Extensions
{
    public static class BooleanExtensions
    {
        public static bool Parse2(this bool compare, string value)
        {
            bool result = false;

            result = !string.IsNullOrEmpty(value);
            
            if (result)
            {
                if (value.Equals("1"))
                    result = true;
                else if (value.Equals("0"))
                    result = false;
                else
                {
                    var res_parse = bool.TryParse(value, out result);

                    if (!res_parse)
                        throw new Exception("Invalid Boolean value!");
                }
            }

            return result;
        }
        public static void Swap(this ref bool original) => original = !original;
    }
}
