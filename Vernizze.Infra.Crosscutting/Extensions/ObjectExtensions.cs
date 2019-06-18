using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Vernizze.Infra.CrossCutting.Extensions
{
    public static class ObjectExtensions
    {
        public static string FromHexToDec(this string value)
        {
            long conversao = long.Parse(value, NumberStyles.HexNumber);

            return conversao.ToString();
        }

        public static void AdjustGlobalization(this CultureInfo value)
        {
            Thread.CurrentThread.CurrentCulture = value;
        }

        public static bool HaveAny(this IEnumerable<object> value)
        {
            return EnumerableExtensions.HaveAny<object>(value);
        }

        #region Validações de conteúdos

        public static bool IsNull(this object value)
        {
            return (value == null);
        }

        public static bool IsNull<T>(this T value)
        {
            return (value == null);
        }

        public static bool IsNotNull(this object value)
        {
            return !IsNull(value);
        }

        public static bool IsNotNull<T>(this T value)
        {
            return !IsNull(value);
        }

        public static bool IsDate(this object value)
        {
            DateTime returnValue;
            return DateTime.TryParse(value.ToString(), out returnValue);
        }

        public static bool IsNotDate(this object value)
        {
            return !IsDate(value);
        }

        public static bool IsNumeric(this object value)
        {
            decimal returnValue;
            return decimal.TryParse(value.ToString(), out returnValue);
        }

        public static bool IsNotNumeric(this object value)
        {
            return !IsNumeric(value);
        }

        #endregion


        #region Serialização e Deserialização JSON

        public static string ToJson<T>(this T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                return null;
            }
        }

        public static T JsonToObject<T>(this string str) where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(str);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                return null;
            }
        }

        public static T JsonToObject<T>(this string str, JsonSerializerSettings settings) where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(str, settings);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                return null;
            }
        }

        public static T JsonToObject_KeyValuePairConverter<T>(this string jsonString) where T : class
        {
            T result = null;

            if (!String.IsNullOrEmpty(jsonString))
            {
                result = JsonConvert.DeserializeObject<T>(jsonString, new KeyValuePairConverter());
            }

            return result;
        }

        #endregion


        public static T InicializaValores<T>(this T item)
        {
            // obtem todas propriedades, campos...
            var propriedades = item.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            // para cada propriedade
            foreach (var propriedade in propriedades)
            {
                // pega o atributo DefaultValue
                var atributos = propriedade
                    .GetCustomAttributes(typeof(DefaultValueAttribute), true)
                    .OfType<DefaultValueAttribute>().ToArray();

                TypeCode tipo = Type.GetTypeCode(propriedade.PropertyType);

                var value = propriedade.GetValue(item);

                switch (tipo)
                {
                    case TypeCode.Empty:
                        break;
                    case TypeCode.Object:

                        break;
                    case TypeCode.DBNull:
                        break;
                    case TypeCode.Boolean:
                        if (value == null)
                            propriedade.SetValue(item, false, null);
                        break;
                    case TypeCode.Char:
                        if (value == null)
                            propriedade.SetValue(item, ' ', null);
                        break;
                    case TypeCode.SByte:
                        if (value == null)
                            propriedade.SetValue(item, 0, null);
                        break;
                    case TypeCode.Byte:
                        if (value == null)
                            propriedade.SetValue(item, 0, null);
                        break;
                    case TypeCode.Int16:
                        if (value == null)
                            propriedade.SetValue(item, 0, null);
                        break;
                    case TypeCode.UInt16:
                        if (value == null)
                            propriedade.SetValue(item, 0, null);
                        break;
                    case TypeCode.Int32:
                        if (value == null)
                            propriedade.SetValue(item, 0, null);
                        break;
                    case TypeCode.UInt32:
                        if (value == null)
                            propriedade.SetValue(item, 0, null);
                        break;
                    case TypeCode.Int64:
                        if (value == null)
                            propriedade.SetValue(item, 0, null);
                        break;
                    case TypeCode.UInt64:
                        if (value == null)
                            propriedade.SetValue(item, 0, null);
                        break;
                    case TypeCode.Single:
                        if (value == null)
                            propriedade.SetValue(item, 0, null);
                        break;
                    case TypeCode.Double:
                        if (value == null)
                            propriedade.SetValue(item, 0D, null);
                        break;
                    case TypeCode.Decimal:
                        if (value == null)
                            propriedade.SetValue(item, 0M, null);
                        break;
                    case TypeCode.DateTime:
                        if ((DateTime)value == null || (DateTime.MinValue == (DateTime)value))
                            propriedade.SetValue(item, new DateTime(1901, 1, 1), null);
                        break;
                    case TypeCode.String:
                        if (string.IsNullOrEmpty((string)value))
                            propriedade.SetValue(item, string.Empty, null);
                        break;
                    default:
                        break;
                }
            }
            return item;
        }

        public static IEnumerable<T> InicializaValores<T>(this IEnumerable<T> list)
        {
            if (list != null && list.Count() > 0)
            {
                foreach (var item in list)
                {
                    item.InicializaValores();
                }
            }

            return list;
        }

        public static T Clone<T>(this T obj)
            where T : class
        {
            object result = null;

            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();

                bf.Serialize(ms, obj);

                ms.Position = 0;

                result = bf.Deserialize(ms);

                ms.Close();
            }

            return (T)result;
        }

        public static string HashCode(this object obj)
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}