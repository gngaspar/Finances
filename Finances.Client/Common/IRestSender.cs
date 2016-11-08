namespace Finances.Client.Common
{
    using System.Threading.Tasks;

    public interface IRestSender
    {
        Task<IRestResult> CallServiceAsync(IRestMessageContext message);
    }
}