namespace Finances.NUnit.Regression.Common
{
    using System.Collections.Generic;
    using System.Configuration;

    /// <summary>
    /// The page collection.
    /// </summary>
    public class PageCollection : ConfigurationElementCollection ////, IList<PageConfigElement> //TODO: Implement the IList to be able to linq values
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageCollection"/> class.
        /// </summary>
        public PageCollection()
        {
            var details = (PageConfigElement)this.CreateNewElement();
            if (details.Name != string.Empty)
            {
                this.Add(details);
            }
        }
        
        /// <summary>
        /// Gets the collection type.
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;
        
        /// <summary>
        /// Gets the element name.
        /// </summary>
        protected override string ElementName => "page";
        
        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The <see cref="PageConfigElement"/>.
        /// </returns>
        public PageConfigElement this[int index]
        {
            get
            {
                return (PageConfigElement)this.BaseGet(index);
            }

            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }

                this.BaseAdd(index, value);
            }
        }

        /// <summary>
        /// The this.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="PageConfigElement"/>.
        /// </returns>
        new public PageConfigElement this[string name] => (PageConfigElement)BaseGet(name);

        /// <summary>
        /// The index of.
        /// </summary>
        /// <param name="details">
        /// The details.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int IndexOf(PageConfigElement details)
        {
            return this.BaseIndexOf(details);
        }
        
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="details">
        /// The details.
        /// </param>
        public void Add(PageConfigElement details)
        {
            this.BaseAdd(details);
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="details">
        /// The details.
        /// </param>
        public void Remove(PageConfigElement details)
        {
            if (this.BaseIndexOf(details) >= 0)
            {
                this.BaseRemove(details.Name);
            }
        }

        /// <summary>
        /// The remove at.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        public void RemoveAt(int index)
        {
            this.BaseRemoveAt(index);
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public void Remove(string name)
        {
            this.BaseRemove(name);
        }

        /// <summary>
        /// The clear.
        /// </summary>
        public void Clear()
        {
            this.BaseClear();
        }

        /// <summary>
        /// The create new element.
        /// </summary>
        /// <returns>
        /// The <see cref="ConfigurationElement"/>.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new PageConfigElement();
        }

        /// <summary>
        /// The base add.
        /// </summary>
        /// <param name="element">
        /// The element.
        /// </param>
        protected override void BaseAdd(ConfigurationElement element)
        {
            this.BaseAdd(element, false);
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
            return ((PageConfigElement)element).Name;
        }
    }
}
