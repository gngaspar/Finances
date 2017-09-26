// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DecimalPrecisionAttribute.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The decimal Precision attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Extensions
{
    using System;

    /// <summary>
    /// The decimal Precision attribute.
    /// </summary>
    /// <seealso cref="System.Attribute"/>
    [AttributeUsage( AttributeTargets.Property, Inherited = false, AllowMultiple = false )]
    public sealed class DecimalPrecisionAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecimalPrecisionAttribute"/> class.
        /// </summary>
        /// <param name="precision">The precision.</param>
        /// <param name="scale">The scale.</param>
        public DecimalPrecisionAttribute( byte precision, byte scale )
        {
            this.Precision = precision;
            this.Scale = scale;
        }

        /// <summary>
        /// Gets or sets the precision.
        /// </summary>
        /// <value>The precision.</value>
        public byte Precision { get; set; }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>The scale.</value>
        public byte Scale { get; set; }
    }
}