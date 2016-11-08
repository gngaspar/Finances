namespace Finances.Client.Common
{
    using System.Net.Http;

    public interface IRestMessageContext
    {
        string Accept { get; }
        string Content { get; }

        string ContentType { get; }
        HttpMethod HttpMethod { get; }
        ServiceMethod ServiceMethod { get; }
        string UrlPath { get; }
    }
}