// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DecimalPrecisionAttributeConvention.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The decimal precision attribute convention.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.DataLayer.Conventions
{
    using System;
    using System.Data.Entity.ModelConfiguration.Configuration;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Finances.Domain.Extensions;

    /// <summary>
    /// The decimal precision attribute convention.
    /// </summary>
    public class DecimalPrecisionAttributeConvention : PrimitivePropertyAttributeConfigurationConvention<DecimalPrecisionAttribute>
    {
        /// <summary>
        /// The apply.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <param name="attribute">
        /// The attribute.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// The invalid operation exception.
        /// </exception>
        public override void Apply( ConventionPrimitivePropertyConfiguration configuration, DecimalPrecisionAttribute attribute )
        {
            if ( attribute.Precision < 1 || attribute.Precision > 38 )
            {
                throw new InvalidOperationException( "Precision must be between 1 and 38." );
            }

            if ( attribute.Scale > attribute.Precision )
            {
                throw new InvalidOperationException( "Scale must be between 0 and the Precision value." );
            }

            configuration.HasPrecision( attribute.Precision, attribute.Scale );
        }
    }
}