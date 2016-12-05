namespace Finances.Contract.Humans
{
    using System;

    /// <summary>
    /// The human out.
    /// </summary>
    public class HumanOut : HumanIn
    {
        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        /// <value>The code.</value>
        public Guid Code { get; set; }
    }
}