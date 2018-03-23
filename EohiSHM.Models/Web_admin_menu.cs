using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EohiSHM.Models
{
    [Table("web_admin_menu")]
    public partial class Web_admin_menu
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        public int MeId { get; set; }
        /// <summary>
        /// 菜单编号
        /// </summary>
        public string Menucode { get; set; }
        /// <summary>
        /// 菜单名
        /// </summary>
        public string Menuname { get; set; }
        /// <summary>
        /// 菜单路径
        /// </summary>
        public string Menuurl { get; set; }
        /// <summary>
        /// 父菜单编号
        /// </summary>
        public string Parentcode { get; set; }
        /// <summary>
        /// 是否重排
        /// </summary>
        public int? Reorder { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int? Isuse { get; set; }
        /// <summary>
        /// 菜单层
        /// </summary>
        public int? Menulevel { get; set; }
        /// <summary>
        /// 菜单注解
        /// </summary>
        public string Menunote { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Cre_man { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Cre_date { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string Mod_man { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? Mod_date { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string IconImage { get; set; }
        /// <summary>
        /// 子菜单集合
        /// </summary>
        public List<Web_admin_menu> MenuChildren = new List<Web_admin_menu>();


        public string Remarks { get; set; }
    }
}
