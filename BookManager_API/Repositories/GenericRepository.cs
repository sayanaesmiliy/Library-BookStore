using BookManager_API.Abstracts;
using BookManager_API.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookManager_API.Repositories
{
    /// <summary>
    /// This class provides a generic implementation of the <see cref="IRepository{TEntity, TPKeyType}"/>
    /// interface for entities of type <typeparamref name="TEntity"/> which are uniquely 
    /// identified with a key of type <typeparamref name="TPKeyType"/>.
    /// <para> This class implementation is based on the entity framework, and actually 
    /// serves as a bridge which delegates the implementation to the EF. </para>
    /// </summary>
    /// <typeparam name="TEntity"> The type of entities managed in this repository.</typeparam>
    /// <typeparam name="TPKeyType"> The type of the primary key that uniquely identifies entities in this repostiory.</typeparam>

    public class GenericRepository<TEntity, TPKeyType> : IRepository<TEntity, TPKeyType> where TEntity : class
    {
        protected DbContext _db { get; }
        private readonly DbSet<TEntity> _dbSet;
        /// <summary>
        /// Constructs a repository of the given entity from the given context.
        /// </summary>
        public GenericRepository(DbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        public void Remove(TEntity entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);
        }
        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
        
        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public TEntity Get(TPKeyType id)
        {
            return _dbSet.Find(id);
        }

        public Task<TEntity> GetAsync(TPKeyType id)
        {
            return _dbSet.FindAsync(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }
        public Task<List<TEntity>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
        public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToListAsync();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return _dbSet.SingleOrDefault(predicate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return _dbSet.SingleOrDefaultAsync(predicate);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
