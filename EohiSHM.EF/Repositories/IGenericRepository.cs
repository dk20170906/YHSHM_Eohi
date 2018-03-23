using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EohiSHM.EF.Repositories
{
    interface IGenericRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> whereLambda = null);
        List<T> GetAll<Tkey>(Func<T, Tkey> orderingLamuda = null);
        List<T> GetAll<Tkey>(Expression<Func<T, bool>> whereLambda, Func<T, Tkey> orderbyLambda);
        List<T> GetAllDes<Tkey>(Expression<Func<T, bool>> whereLambda, Func<T, Tkey> orderbyLambda);
        int GetCount(Expression<Func<T, bool>> whereLambd = null);
        IQueryable<T> LoadPageItems<Tkey>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Func<T, Tkey> orderbyLambda, bool isAsc);
        List<T> Page<Tkey>(int pageIndex, int pageSize, out int rows, Func<T, Tkey> orderbyLambda, Expression<Func<T, bool>> whereLambda = null);

        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string IncludeProperties = "");

        T GetById(object Id);
        void Insert(T entity);
        void InsertRange(List<T> datas);
        void Delete(object Id);
        void Delete(Expression<Func<T, bool>> whereLambda);
        void Update(T entity);
        void Update(T model, List<string> proNames, bool isProUpdate = true);
        void Update(T model, params string[] proNames);
        void UpdateAll(List<T> models);
        void Update(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames);
        /// <summary>
        /// 回滚
        /// </summary>
        void RollBackChanges();

    }
}
