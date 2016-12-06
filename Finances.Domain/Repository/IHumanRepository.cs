namespace Finances.Domain.Repository
{
    using System;
    using System.Threading.Tasks;

    using Finances.Contract.Humans;

    /// <summary>
    /// The HumanRepository interface.
    /// </summary>
    public interface IHumanRepository : IDisposable
    {
        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> Add(Guid owner, Guid code, HumanIn input);

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> Edit(Guid code, HumanIn input);

        /// <summary>
        /// The exist.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<bool> Exist(Guid input);

        /// <summary>
        /// The exist owner.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<bool> ExistOwner(Guid input);

        /// <summary>
        /// The is he owner.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<bool> IsHeOwner(Guid owner, Guid code);

        /// <summary>
        /// The list.
        /// </summary>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<HumanListResponse> List(Guid owner, HumanListRequest input);
    }
}