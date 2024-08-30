using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace home_pisos_vinilicos.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /*
        Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);
        Task<T> GetById(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task<bool> Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
        */
    }
}
