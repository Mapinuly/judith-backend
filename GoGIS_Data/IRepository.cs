using System.Collections.Generic;
using System.Linq;

namespace GoGIS_Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(object Id);
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        IEnumerable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
        long InsertAndGetId(T entity);
    }
}
