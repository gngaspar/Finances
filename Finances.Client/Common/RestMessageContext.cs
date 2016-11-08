namespace Finances.Client.Common
{
    using System.Net.Http;

    internal class RestMessageContext : IRestMessageContext
    {
        public string Accept { get; set; }
        public string Content { get; set; }

        public string ContentType { get; set; }
        public HttpMethod HttpMethod { get; set; }
        public ServiceMethod ServiceMethod { get; set; }
        public string UrlPath { get; set; }
    }
}