// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserEntity.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The User representantion on the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Domain.Human
{
    using System;

    //Todo: move this to its own project

    /// <summary>
    /// The user entity.
    /// </summary>
    /// <seealso cref="Finances.Domain.EntityDateTimeBase"/>
    public class UserEntity : EntityDateTimeBase
    {
        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        /// <value>The code.</value>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Health Care.
        /// </summary>
        /// <value>The health care.</value>
        public string HealthCare { get; set; }

        /// <summary>
        /// Gets or sets the Health Care.
        /// </summary>
        /// <value>The health care expiration date.</value>
        public DateTime HealthCareExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the Id Number.
        /// </summary>
        /// <value>The identifier number.</value>
        public string IdNumber { get; set; }

        /// <summary>
        /// Gets or sets the Id Number.
        /// </summary>
        /// <value>The identifier number expiration date.</value>
        public DateTime IdNumberExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the NIF.
        /// </summary>
        /// <value>The NIF.</value>
        public string Nif { get; set; }

        /// <summary>
        /// Gets or sets the Id Number.
        /// </summary>
        /// <value>The passport.</value>
        public string Passport { get; set; }

        /// <summary>
        /// Gets or sets the Id Number.
        /// </summary>
        /// <value>The passport expiration date.</value>
        public DateTime PassportExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the Social Security.
        /// </summary>
        /// <value>The social security.</value>
        public string SocialSecurity { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>The surname.</value>
        public string Surname { get; set; }
    }
}