using EohiSHM.EF.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EohiSHM.EF.Repositories
{
    public class DbContextFactory<T> where T : class, new()
    {
        public DbContext GetDbContext()
        {
            string key = "EohiSHMDbContext";
            DbContext dbContext = CallContext.GetData(key) as DbContext; if (dbContext == null)
            {
                dbContext = new GDBContext<T>();

                CallContext.SetData(key, dbContext);
            }
            return dbContext;
        }


    }
}
