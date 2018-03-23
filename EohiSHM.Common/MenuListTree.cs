using EohiSHM.EF;
using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EohiSHM.Common
{
    /// <summary>
    /// 生成菜单树
    /// </summary>
    public class MenuListTree
    {
        UnitOfWork<Web_admin_menu> Db = new UnitOfWork<Web_admin_menu>();
        /// <summary>
        /// 创建菜单树
        /// </summary>
        /// <param name="menuid"></param>
        /// <returns></returns>
        public List<Web_admin_menu> CreateMenuModel( string menuid)
        {


            // 1. 根据menuName获取开始的根菜单

            // SysMenu itemRoot = unitOfWork.SysMenuRepository.Get(filter: m => m.Name == menuName).FirstOrDefault();
            Web_admin_menu itemRoot = Db.GenericRepository.FirstOrDefault(m => m.Menucode == menuid && m.Isuse == 0);
            if (itemRoot != null)
            {
                itemRoot.MenuChildren = new List<Web_admin_menu>();
                // 2. 依次添加枝叶菜单
                // 2.1 获取itemRoot的所有子菜单
                IEnumerable<Web_admin_menu> menus = Db.GenericRepository.GetAll(m => m.Parentcode == itemRoot.Menucode && m.Isuse == 0, m => m.MeId);
                // 2.2 对每个子菜单进行递归 AddChildNode
                foreach (var item in menus)
                {
                    itemRoot.MenuChildren.Add(item);
                    AddChildNode(item);
                }
            }
            return itemRoot.MenuChildren;
        }
        /// <summary>
        /// 递归执行：找到menu子成员并添加        /// </summary>
        /// <param name="menu"></param>
        //递归执行：找到menu子成员并添加
        private void AddChildNode(Web_admin_menu menu)
        {
            var menus = Db.GenericRepository.GetAll(m => m.Parentcode == menu.Menucode && m.Isuse == 0, m => m.MeId);
            foreach (var item in menus)
            {
                menu.MenuChildren.Add(item);
                AddChildNode(item);
            }

        }
    }
}
