using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        /// <summary>
        /// Retrieves a sale by its unique identifier, including its related sale items.
        /// </summary>
        /// <param name="id">The unique identifier of the sale.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The sale with its items if found; otherwise, null.</returns>
        Task<Sale?> GetByIdWithItemsAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
