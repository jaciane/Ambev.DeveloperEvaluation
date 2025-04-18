using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Repository implementation for Sale entity, providing custom data access operations.
    /// </summary>
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleRepository"/> class.
        /// </summary>
        /// <param name="context">The EF DbContext used for database access.</param>
        public SaleRepository(DefaultContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a sale by its unique identifier, including its related sale items.
        /// </summary>
        /// <param name="id">The unique identifier of the sale.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>The sale with its items if found; otherwise, null.</returns>
        public async Task<Sale?> GetByIdWithItemsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Sales
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }
    }
}
