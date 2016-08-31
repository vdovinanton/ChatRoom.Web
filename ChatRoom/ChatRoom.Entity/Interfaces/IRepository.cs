using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace ChatRoom.Entity.Interfaces
{
    /// <summary>
    /// Represents <see cref="TEntity"/> repository
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity actions</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// Get single <see cref="TEntity"/> element by Id
        /// </summary>
        /// <param name="id"><see cref="TEntity"/> Identifier</param>
        /// <returns>Single <see cref="TEntity"/> object</returns>
        TEntity Get(int id);

        /// <summary>
        /// Get all <see cref="TEntity"/> elements
        /// </summary>
        /// <returns><see cref="TEntity"/> collection</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Get the objects found in the <see cref="TEntity"/> collection
        /// </summary>
        /// <param name="predicate">Search criterias</param>
        /// <returns>Found elements</returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get the objects found in the <see cref="TEntity"/> collection
        /// </summary>
        /// <param name="predicate">Search criterias</param>
        /// <returns>Found elements</returns>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Add object to <see cref="TEntity"/> collection 
        /// </summary>
        /// <param name="entity">Single <see cref="TEntity"/> object</param>
        void Add(TEntity entity);

        /// <summary>
        /// Add collection <see cref="TEntity"/> in the end collection
        /// </summary>
        /// <param name="entitys"><see cref="TEntity"/> collection</param>
        void AddRange(IEnumerable<TEntity> entitys);

        /// <summary>
        /// Remove <see cref="TEntity"/> element from the collection
        /// </summary>
        /// <param name="entity">Single <see cref="TEntity"/> object</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Remove collection <see cref="TEntity"/> from the collection
        /// </summary>
        /// <param name="entitys"><see cref="TEntity"/> collection</param>
        void RemoveRange(IEnumerable<TEntity> entitys);

    }
}