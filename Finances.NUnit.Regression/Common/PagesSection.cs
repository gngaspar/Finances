// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagesSection.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The pages section.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.NUnit.Regression.Common
{
    using System.Collections.Generic;
    using System.Configuration;

    /// <summary>
    /// The pages section.
    /// </summary>
    public class PagesSection : ConfigurationSection
    {
        /// <summary>
        /// The instance.
        /// </summary>
        private static PagesSection instance;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static PagesSection Instance
        {
            get
            {
                return instance ?? ( instance = ConfigurationManager.GetSection( "pagesSection" ) as PagesSection );
            }
        }

        /// <summary>
        /// Gets the selectors.
        /// </summary>
        [ConfigurationProperty( "", IsDefaultCollection = true )]
        public PageCollection Selectors
        {
            get
            {
                var pageCollection = (PageCollection) base[ string.Empty ];
                return pageCollection;
            }
        }
    }
}
