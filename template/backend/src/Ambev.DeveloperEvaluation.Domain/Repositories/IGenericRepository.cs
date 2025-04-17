using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Generic repository for basic CRUD operations.
    /// </summary>
    /// <typeparam name="T">Type of entity that the repository will manage.</typeparam>
    public interface IGenericRepository<T> where T : class
    {

        /// <summary>
        /// Creates a new entity in the repository
        /// </summary>
        /// <param name="entity">The entity to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created entity</returns>
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a entity by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the entity</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The entity if found, null otherwise</returns>
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);


        /// <summary>
        /// Deletes a entity from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the entity was deleted, false if not found</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all entities
        /// </summary>
        /// <returns>The entities if found, null otherwise</returns>
        Task<IEnumerable<T?>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a entity in the repository
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated entity</returns>
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    }
}
