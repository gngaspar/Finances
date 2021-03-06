﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HumanOut.cs" company="GNG">
//   GNG
// </copyright>
// <summary>
//   The human out.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Finances.Contract.Humans
{
    using System;

    /// <summary>
    /// The human out.
    /// </summary>
    public class HumanOut : HumanIn
    {
        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        /// <value>The code.</value>
        public Guid Code { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the change at.
        /// </summary>
        public DateTime? ChangeAt { get; set; }
    }
}