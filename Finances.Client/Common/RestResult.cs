namespace Finances.Client.Common
{
    public class RestResult : IRestResult
    {
        public string Content { get; set; }

        public string ContentType { get; set; }

        public int HttpStatus { get; set; }
    }
}