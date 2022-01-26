using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VAZ.Domain.Common;

namespace VAZ.Infrastructure.Persistence
{
	public interface IRepository<T> where T : BaseEntity
	{
		T GetById(int id);
		Task<T> GetByIdAsync(int id);
		IQueryable<T> GetAll { get; }
		IQueryable<T> GetAllNoTracking { get; }
		T Get(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
		Task<T> GetAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
		IQueryable<T> GetMany(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
		T InsertWithoutCommit(T entity);
		Task<T> InsertAsync(T entity);
		T Insert(T entity);
		int InsertBulk(IEnumerable<T> entities);
		int Update(T entity);
		Task<int> UpdateAsync(T entity);
		int UpdateWithoutCommit(T entity);
		int Delete(T entity);
		Task<int> DeleteAsync(T entity);
		int Remove(T entity);
		int Commit();
		Task<int> CommitAsync();
		int DeleteBulk(IEnumerable<T> entities);
		bool Any(Expression<Func<T, bool>> expression);


	}
}
