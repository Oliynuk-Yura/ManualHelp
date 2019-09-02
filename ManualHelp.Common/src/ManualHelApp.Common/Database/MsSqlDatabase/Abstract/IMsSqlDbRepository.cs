using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ManualHelp.Common.Database.MsSqlDatabase.Abstract
{
    public interface IMsSqlDbRepository<TEntity, Context> where TEntity : Identifiable  where Context : DbContext
    {
        Task<TEntity> GetAsync(Guid id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);        
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
