// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionResponse.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The action response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract
{
    /// <summary>
    /// The action response.
    /// </summary>
    /// <typeparam name="T">
    /// The Type.
    /// </typeparam>
    public class ActionResponse<T>
    {
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        public T Results { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether has error.
        /// </summary>
        public bool HasError { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string ErrorGuid { get; set; }
    }
}