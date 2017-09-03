namespace Finances.NUnit.Regression.Common
{
    using System.Configuration;

    /// <summary>
    /// The selector config element.
    /// </summary>
    public class SelectorConfigElement : ConfigurationElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectorConfigElement"/> class.
        /// </summary>
        public SelectorConfigElement()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectorConfigElement"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="selector">
        /// The selector.
        /// </param>
        public SelectorConfigElement(string name, string type, string selector)
        {
            this.Name = name;
            this.Type = type;
            this.Selector = selector;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "")]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true, DefaultValue = "Id")]
        public string Type
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }

        /// <summary>
        /// Gets or sets the selector.
        /// </summary>
        [ConfigurationProperty("selector", IsRequired = true, DefaultValue = "")]
        public string Selector
        {
            get { return (string)this["selector"]; }
            set { this["selector"] = value; }
        }
    }
}
