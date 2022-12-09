using BPApi.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BPApi.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> Table { get; }
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(string id);
        Task Delete(TEntity entity);
        Task<IList<TEntity>> GetAll();
        Task<TEntity> GetById(string id);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> whereExpression, bool forJustActiveRecords = true);
        IQueryable<TEntity> OrderBy<TKey>(Expression<Func<TEntity, TKey>> orderByExpression, OrderByType type = OrderByType.ASC);
        IQueryable<TEntity> IncludeMany(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> First(Expression<Func<TEntity, bool>> whereExpression);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> whereExpression);
    }
}
