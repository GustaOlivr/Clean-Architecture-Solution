using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Domain.Interfaces
{
    /// <summary>
    /// Represents the Unit of Work pattern for coordinating the writing of changes to the database.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commits all changes made in the current transaction.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Commit(CancellationToken cancellationToken);
    }
}
