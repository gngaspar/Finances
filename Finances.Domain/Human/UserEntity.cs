namespace Finances.Domain.Human
{
    using System;

    public class UserEntity : EntityDateTimeBase
    {
        /// <summary>
        /// Gets or sets the CodeName.
        /// </summary>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Health Care.
        /// </summary>
        public string HealthCare { get; set; }

        /// <summary>
        /// Gets or sets the Health Care.
        /// </summary>
        public DateTime HealthCareExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the Id Number.
        /// </summary>
        public string IdNumber { get; set; }

        /// <summary>
        /// Gets or sets the Id Number.
        /// </summary>
        public DateTime IdNumberExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the nif.
        /// </summary>
        public string Nif { get; set; }

        /// <summary>
        /// Gets or sets the Id Number.
        /// </summary>
        public string Passport { get; set; }

        /// <summary>
        /// Gets or sets the Id Number.
        /// </summary>
        public DateTime PassportExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the Social Security.
        /// </summary>
        public string SocialSecurity { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        public string Surname { get; set; }
    }
}