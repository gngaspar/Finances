namespace Finances.Domain.Human
{
    using System;

    public class PersonEntity : EntityDateTimeBase
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
        /// Gets or sets a value indicating whether is archived.
        /// </summary>
        public bool IsArchived { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is the user it self.
        /// </summary>
        public bool IsMe => this.Code == this.OwnerCode;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the CodeName.
        /// </summary>
        public Guid OwnerCode { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        public string Surname { get; set; }
    }
}