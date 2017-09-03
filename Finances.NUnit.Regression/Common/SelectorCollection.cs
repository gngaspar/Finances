namespace Finances.NUnit.Regression.Common
{
    using System.Collections.Generic;
    using System.Configuration;

    /// <summary>
    /// The selector collection.
    /// </summary>
    public class SelectorCollection : ConfigurationElementCollection ////, IList<SelectorConfigElement>  //TODO: Implement the IList to be able to linq values
    {
        /// <summary>
        /// Gets the collection type.
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;
        
        /// <summary>
        /// The element name.
        /// </summary>
        protected override string ElementName => "selector";

        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="SelectorConfigElement"/>.
        /// </returns>
        public new SelectorConfigElement this[string name]
        {
            get
            {
                if (this.IndexOf(name) < 0)
                {
                    return null;
                }

                return (SelectorConfigElement)this.BaseGet(name);
            }
        }

        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The <see cref="SelectorConfigElement"/>.
        /// </returns>
        public SelectorConfigElement this[int index] => (SelectorConfigElement)this.BaseGet(index);
        
        /// <summary>
        /// The index of.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int IndexOf(string name)
        {
            name = name.ToLower();

            for (var idx = 0; idx < base.Count; idx++)
            {
                if (this[idx].Name.ToLower() == name)
                {
                    return idx;
                }
            }

            return -1;
        }
        
        /// <summary>
        /// The create new element.
        /// </summary>
        /// <returns>
        /// The <see cref="ConfigurationElement"/>.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new SelectorConfigElement();
        }

        /// <summary>
        /// The get element key.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SelectorConfigElement)element).Name;
        }
    }
}
