using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Vernizze.Infra.CrossCutting.Libraries.HttpClient
{
    public static class HttpRequestFactory
    {
        #region Get

        public static async Task<HttpResponseMessage> Get(string requestUri)
            => await Get(requestUri, string.Empty);

        public static async Task<HttpResponseMessage> Get(string requestUri, List<CustomHttpHeader> custom_headers)
            => await Get(requestUri, string.Empty, custom_headers);

        public static async Task<HttpResponseMessage> Get(string requestUri, string bearerToken)
            => await Get(requestUri, bearerToken, new List<CustomHttpHeader>());

        public static async Task<HttpResponseMessage> Get(string requestUri, string bearerToken, List<CustomHttpHeader> custom_headers)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Get)
                                .AddRequestUri(requestUri)
                                .AddCustomHeaders(custom_headers)
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        #endregion

        #region Post

        public static async Task<HttpResponseMessage> Post(string requestUri, object value)
            => await Post(requestUri, value, string.Empty, new List<CustomHttpHeader>());

        public static async Task<HttpResponseMessage> Post(
            string requestUri, object value, string bearerToken)
        {
            return await Post(requestUri, value, bearerToken, new List<CustomHttpHeader>());
        }

        public static async Task<HttpResponseMessage> Post(
            string requestUri, object value, List<CustomHttpHeader> custom_headers)
        {
            return await Post(requestUri, value, string.Empty, custom_headers);
        }

        public static async Task<HttpResponseMessage> Post(
            string requestUri, object value, string bearerToken, List<CustomHttpHeader> custom_headers)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddCustomHeaders(custom_headers)
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        #endregion

        #region Put

        public static async Task<HttpResponseMessage> Put(string requestUri, object value)
            => await Put(requestUri, value, string.Empty, new List<CustomHttpHeader>());

        public static async Task<HttpResponseMessage> Put(string requestUri, object value, List<CustomHttpHeader> custom_headers)
            => await Put(requestUri, value, string.Empty, custom_headers);

        public static async Task<HttpResponseMessage> Put(
            string requestUri, object value, string bearerToken, List<CustomHttpHeader> custom_headers)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Put)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddCustomHeaders(custom_headers)
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        #endregion

        #region Patch

        public static async Task<HttpResponseMessage> Patch(string requestUri, object value)
            => await Patch(requestUri, value, string.Empty);

        public static async Task<HttpResponseMessage> Patch(
            string requestUri, object value, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(new HttpMethod("PATCH"))
                                .AddRequestUri(requestUri)
                                .AddContent(new PatchContent(value))
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        #endregion

        #region Delete

        public static async Task<HttpResponseMessage> Delete(string requestUri)
            => await Delete(requestUri, string.Empty);

        public static async Task<HttpResponseMessage> Delete(
            string requestUri, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Delete)
                                .AddRequestUri(requestUri)
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        #endregion

        #region PostFile

        public static async Task<HttpResponseMessage> PostFile(string requestUri,
            string filePath, string apiParamName)
            => await PostFile(requestUri, filePath, apiParamName, string.Empty);

        public static async Task<HttpResponseMessage> PostFile(string requestUri,
            string filePath, string apiParamName, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddRequestUri(requestUri)
                                .AddContent(new FileContent(filePath, apiParamName))
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }

        #endregion
    }
}
