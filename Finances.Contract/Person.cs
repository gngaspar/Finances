// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="">
//   
// </copyright>
// <summary>
//   The person.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract
{
    using System;

    /// <summary>
    /// The person.
    /// </summary>
    public class Person 
    {
        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the nif.
        /// </summary>
        public string Nif { get; set; }

        /// <summary>
        /// Gets or sets the Social Security.
        /// </summary>
        public string SocialSecurity { get; set; }

        /// <summary>
        /// Gets or sets the Health Care.
        /// </summary>
        public string HealthCare { get; set; }
        
        public string IdNumber { get; set; }
    }
}