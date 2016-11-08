namespace Finances.Client.Common
{
    using System;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;

    public abstract class ClientBase
    {
        protected const string JsonAccept = "application/json";
        protected const string JsonContentType = "application/json";
        private readonly IRestSender sender;

        protected ClientBase(IRestSender sender)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));

            this.sender = sender;
        }

        internal static RestMessageContext CreateContextXml()
        {
            var context = new RestMessageContext
            {
                Accept = JsonAccept,
                ContentType = JsonContentType
            };
            return context;
        }

        internal async Task ExecuteSender<TRequest>(TRequest request, RestMessageContext context)
        {
            context.Content = this.SerializeJson(request);
            await this.Execute(context);
        }

        internal async Task<TResponse> ExecuteSender<TRequest, TResponse>(TRequest request, RestMessageContext context)
            where TRequest : class
            where TResponse : class
        {
            context.Content = this.SerializeJson(request);
            return await this.ExecuteSender<TResponse>(context);
        }

        internal async Task<TResponse> ExecuteSender<TResponse>(RestMessageContext context) where TResponse : class
        {
            var result = await Execute(context);

            return string.IsNullOrEmpty(result.Content) == false ? this.DeserializeJson<TResponse>(result.Content) : null;
        }

        internal async Task ExecuteSender(RestMessageContext context)
        {
            await Execute(context);
        }

        protected T DeserializeJson<T>(string textData)
        {
            if (string.IsNullOrEmpty(textData))
                throw new ArgumentNullException(nameof(textData));

            return new JavaScriptSerializer().Deserialize<T>(textData);
        }

        protected string SerializeJson<T>(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return new JavaScriptSerializer().Serialize(value);
        }

        private async Task<IRestResult> Execute(RestMessageContext context)
        {
            var result = await this.sender.CallServiceAsync(context);

            if (string.Equals(result.ContentType, context.Accept, StringComparison.OrdinalIgnoreCase) == false)
            {
                throw new SerializationException("Expected contentType:" + context.Accept);
            }

            return result;
        }
    }
}