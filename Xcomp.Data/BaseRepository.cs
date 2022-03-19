using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace Xcomp.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> GetByIdAsync(string id);      
        Task<IEnumerable<TEntity>> GetAll();
        void Update(string id, TEntity obj);
        void Remove(string id);
        void RemoveAll();
        void DeleteOne(string id);
        void SetDomain(string domain);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> searchFilter);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> searchFilter);
        Task AddManyAsync(IEnumerable<TEntity> obj);
        Task<(IEnumerable<TEntity>, int)> GetListPagingAsync<TOrder>(Expression<Func<TEntity, bool>> searchFilter, Expression<Func<TEntity, TOrder>> order, int pageSize, int currentPage);
        Task<int> CountAsync([Optional] Expression<Func<TEntity, bool>> condition);
        Task<TEntity> GetLastAsync<TOrder>(Expression<Func<TEntity, bool>> searchFilter, Expression<Func<TEntity, TOrder>> order);
    }

    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<TEntity> DbSet;
        public string Domain { get; set; }

        protected BaseRepository(IMongoContext context)
        {
            Context = context;
            ConfigDbSet();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        public virtual void Add(TEntity obj)
        {
            Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        private void ConfigDbSet()
        {
            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            if (id == null) return null;
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id)));
            return data.SingleOrDefault();
        }

        

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = DbSet.AsQueryable();
            return await all.ToListAsync();
        }

        public virtual void Update(string id, TEntity obj)
        {
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id)), obj));
        }

        public virtual void Remove(string id)
        {
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id))));
        }

        public virtual void RemoveAll()
        {
            Context.AddCommand(() => DbSet.DeleteManyAsync(Builders<TEntity>.Filter.Empty));
        }

        public virtual void DeleteOne(string id)
        {
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", ObjectId.Parse(id))));
        }

        public void SetDomain(string domain)
        {
            Domain = domain;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> searchFilter)
        {
            var query = DbSet.AsQueryable().Where(searchFilter);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var query = DbSet.AsQueryable();
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> searchFilter)
        {
            return await DbSet.AsQueryable().Where(searchFilter).FirstOrDefaultAsync();
        }

        public Task AddManyAsync(IEnumerable<TEntity> obj)
        {
            Context.AddCommand(async () => await DbSet.InsertManyAsync(obj));
            return Task.CompletedTask;
        }

        public async Task<(IEnumerable<TEntity>, int)> GetListPagingAsync<TOrder>(Expression<Func<TEntity, bool>> searchFilter, Expression<Func<TEntity, TOrder>> order, int pageSize, int currentPage)
        {
            var query = DbSet.AsQueryable();
            query = query.Where(searchFilter);
            int count = await query.CountAsync();
            query = query.OrderBy(order).Skip((currentPage - 1) * pageSize).Take(pageSize);
            return (await query.ToListAsync(), count);
        }

        public async Task<TEntity> GetLastAsync<TOrder>(Expression<Func<TEntity, bool>> searchFilter, Expression<Func<TEntity, TOrder>> order)
        {
            var query = DbSet.AsQueryable();
            query = query.Where(searchFilter);
            return await query.OrderByDescending(order).FirstOrDefaultAsync();

        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> condition)
        {
            return await DbSet.AsQueryable().Where(condition).CountAsync();
        }
    }

}
