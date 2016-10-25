using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Domain.Human
{
    public class UserEntity
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
        /// Gets or sets the Email.
        /// </summary>
        public string Email { get; set; }

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
        /// Gets or sets the Id Number.
        /// </summary>
        public string Passport { get; set; }

        /// <summary>
        /// Gets or sets the Id Number.
        /// </summary>
        public DateTime PassportExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the Created At.
        /// </summary>
        private DateTime? createdAt;

        public DateTime CreatedAt
        {
            get
            {
                if (createdAt == null)
                {
                    createdAt = DateTime.Now;
                }
                return createdAt.Value;
            }

            set { createdAt = value; }
        }

        /// <summary>
        /// Gets or sets the change at.
        /// </summary>
        public DateTime? ChangeAt { get; set; }
    }
}
