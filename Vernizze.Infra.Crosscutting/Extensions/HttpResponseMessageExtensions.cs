using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;

namespace Vernizze.Infra.CrossCutting.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async System.Threading.Tasks.Task<T> DeserializeContentAsync<T>(this HttpResponseMessage obj) where T : class
        {
            try
            {
                using (var responseStream = await obj.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    using (var streamReader = new StreamReader(responseStream))
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        return (T)JsonSerializer.CreateDefault().Deserialize(streamReader, typeof(T));
                    }
                }
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                return null;
            }
        }

        public static T DeserializeContent<T>(this HttpResponseMessage obj) where T : class
        {
            return obj.DeserializeContentAsync<T>().Result;
        }
    }
}