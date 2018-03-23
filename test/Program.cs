using EohiSHM.EF;
using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork<Web_admin_account> Db = new UnitOfWork<Web_admin_account>();
            Web_admin_account web_Admin_Menu = new Web_admin_account()
            {
                     Accountname="admin"     ,
                     Psw="admin"
            };
            Db.GenericRepository.Insert(web_Admin_Menu);
            Db.Save();
        }
    }
}
