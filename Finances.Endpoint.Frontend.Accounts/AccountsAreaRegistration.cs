namespace Finances.Endpoint.Frontend.Accounts
{
    using Finances.Endpoint.Frontend.Common;

    /// <summary>
    /// Accounts area registration.
    /// </summary>
    public class AccountsAreaRegistration : BaseAreaRegistration
    {
        /// <summary>
        /// Gets the name of the area to register.
        /// </summary>
        /// <value>Area name value.</value>
        public override string AreaName
        {
            get { return "Accounts"; }
        }
    }
}