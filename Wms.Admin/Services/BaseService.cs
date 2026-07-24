using Wms.Admin.IRepositorys;
using Wms.Admin.IServices;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Admin.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        private IBaseRepository<TEntity> db;            //这个注入是从子类来的

        public BaseService(IBaseRepository<TEntity> repository)
        {
            db = repository;
        }
        public async Task<bool> AddAsync(TEntity entity)
        {
            return await db.AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return await db.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await db.DeleteAsync(id);
        }

        public async Task<TEntity> QueryAsync(int id)
        {
            return await db.QueryAsync(id);
        }

        public virtual async Task<List<TEntity>> QueryListAsync()
        {

            return await db.QueryListAsync();
        }

        public async Task<List<TEntity>> QueryListAsync(Expression<Func<TEntity, bool>> func)
        {
            return await db.QueryListAsync(func);
        }

        public async Task<List<TEntity>> QueryListAsync(int page, int size, RefAsync<int> total)
        {
            return await db.QueryListAsync(page, size, total);
        }

        public async Task<List<TEntity>> QueryListAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total)
        {
            return await db.QueryListAsync(page, size, total);
        }

        public async Task<TEntity> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
            return await db.QueryAsync(func);
        }
    }
}
