// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Beneficiarie.cs" company="">
//   
// </copyright>
// <summary>
//   The beneficiarie.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract
{
    using System;

    /// <summary>
    /// The Beneficiary.
    /// </summary>
    public class Beneficiary 
    {
        /// <summary>
        /// Gets or sets the Created By.
        /// </summary>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public int Order { get; set; }


        /// <summary>
        /// Gets a value indicating whether is main.
        /// </summary>
        public bool IsMain
        {
            get
            {
                return this.Order == 0;
            }
        }

        /// <summary>
        /// Gets or sets the bank guid.
        /// </summary>
        public Guid PersonCode { get; set; }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        public Person Person { get; set; }

        public bool IsArchived { get; set; }

        public Person CreatedBy { get; set; }

        public Person ChangeBy { get; set; }
    }
}