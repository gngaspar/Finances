namespace Finances.Client.Common
{
    public interface IRestResult
    {
        string Content { get; }

        string ContentType { get; }

        int HttpStatus { get; }
    }
}