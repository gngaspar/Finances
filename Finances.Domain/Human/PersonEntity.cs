namespace Finances.Domain.Human
{
    using System;

    public class PersonEntity
    {
        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        public UserEntity Owner { get; set; }

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
        /// Gets or sets a value indicating whether is archived.
        /// </summary>
        public bool IsArchived { get; set; }

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
        public DateTime ChangeAt { get; set; }
    }
}
