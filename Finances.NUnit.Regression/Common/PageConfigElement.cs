namespace Finances.NUnit.Regression.Common
{
    using System.Configuration;

    /// <summary>
    /// The page config element.
    /// </summary>
    public class PageConfigElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        [StringValidator(InvalidCharacters = "  ~!@#$%^&*()[]{}/;’\"|\\")]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        /// <summary>
        /// The selectors.
        /// </summary>
        [ConfigurationProperty("selectors", IsDefaultCollection = false)]
        public SelectorCollection Selectors => (SelectorCollection)base["selectors"];
    }
}
