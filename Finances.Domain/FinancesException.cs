// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FinancesException.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The Finances exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <summary>
    /// The Finances exception.
    /// </summary>
    [Serializable]
    public class FinancesException : Exception
    {
        /// <summary>
        /// The guid error.
        /// </summary>
        private Guid guidError;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancesException"/> class.
        /// </summary>
        /// <param name="ex">
        /// The ex.
        /// </param>
        public FinancesException( string message, Exception ex )
            : base( message, ex )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancesException"/> class.
        /// </summary>
        /// <param name="info">
        /// The info object.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        [SecurityPermission( SecurityAction.Demand, SerializationFormatter = true )]
        protected FinancesException( SerializationInfo info, StreamingContext context ) : base( info, context )
        {
            this.guidError = new Guid( info.GetString( "FinancesException.guidError" ) );
        }

        /// <summary>
        /// Gets the Error Code.
        /// </summary>
        /// <value>
        /// The code value.
        /// </value>
        public Guid ErrorCode
        {
            get
            {
                if ( this.guidError == Guid.Empty )
                {
                    this.guidError = Guid.NewGuid();
                }

                return this.guidError;
            }
        }

        /// <summary>
        /// The get object data.
        /// </summary>
        /// <param name="info">
        /// The info object.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        [SecurityPermission( SecurityAction.Demand, SerializationFormatter = true )]
        public override void GetObjectData( SerializationInfo info, StreamingContext context )
        {
            base.GetObjectData( info, context );

            info.AddValue( "FinancesException.guidError", this.ErrorCode );
        }
    }
}
