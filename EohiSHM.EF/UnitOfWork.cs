using EohiSHM.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EohiSHM.EF
{
    /// <summary>
    /// 数据处理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UnitOfWork<T> where T : class, new()
    {
        private DbContextFactory<T> dbContextFactory = new DbContextFactory<T>();
        private GenericRepository<T> _genericRepository;
        /// <summary>
        /// 数据操作方法
        /// </summary>
        public GenericRepository<T> GenericRepository
        {
            get
            {
                if (_genericRepository == null)
                {
                    _genericRepository = new GenericRepository<T>(dbContextFactory);
                }
                return _genericRepository;
            }
        }
        /// <summary>
        /// 保存对数据的修改并存入数据库
        /// </summary>
        public void Save()
        {
            dbContextFactory.GetDbContext().SaveChanges();
        }
    }
}
