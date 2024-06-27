using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Iterface
{
    public interface IGenericRepository<T>  : IDisposable
    {
        IEnumerable<T> GetAll(
            Expression<Func<T,bool>> filter=null,
            Func<IQueryable<T>,IOrderedQueryable<T>> orderby=null,
            string includeProperties=""
            );
        T GetById(object id);        
        
        Task<T> GetByIdAsync(object id);
        void Add(T entity);
        Task<T> AddAssync(T entity);
        bool Remove(int id);
        void Update(T entity);

        Task<T> UpdateAsync(T entity);
        void Delete(T entity);
        Task<T> DeleteAssync(T entity);
    }

}
