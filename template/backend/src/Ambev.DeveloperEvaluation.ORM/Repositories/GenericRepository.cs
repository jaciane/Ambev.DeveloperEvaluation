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
    /// Generic repository for basic CRUD operations.
    /// </summary>
    /// <typeparam name="T">Type of entity that the repository will manage.</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DefaultContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DefaultContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        /// <summary>
        /// Creates a new entity in the database
        /// </summary>
        /// <param name="entity">The entity to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created entity</returns>
        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        /// <summary>
        /// Deletes a entity from the database
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the entity was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet.FindAsync(id, cancellationToken);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// Retrieves all entity from the database
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The entities if found, null otherwise</returns>
        public async Task<IEnumerable<T?>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a entity by their unique identifier from the database
        /// </summary>
        /// <param name="id">The unique identifier of the entity</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The entity if found, null otherwise</returns>
        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Updates a entity in the repository from the database
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated entity</returns>
        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
