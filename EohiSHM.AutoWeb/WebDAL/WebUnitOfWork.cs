using EohiSHM.EF.Repositories;
using EohiSHM.EF;
using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EohiSHM.AutoWeb.WebDAL
{
    public class WebUnitOfWork<T>: UnitOfWork<T>  where T : class, new()
    {
       
    }


}