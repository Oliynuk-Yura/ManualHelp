using ManualHelp.Common.Database.MsSqlDatabase.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ManualHelp.Common.Database.MsSqlDatabase.Implementation
{
    public class MsSqlDbRepository<TEntity, Context> : IMsSqlDbRepository<TEntity, Context> 
        where TEntity : Identifiable where Context : DbContext
    {
        private readonly Context _context;

        public MsSqlDbRepository(Context context)
        {
            _context = context;
        }

        public Context DbContext
        {
            get { return _context; }
        }

        public async Task AddAsync(TEntity entity)
        {
           await DbContext.Set<TEntity>().AddAsync(entity);
           await DbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
