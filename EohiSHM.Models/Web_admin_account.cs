using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EohiSHM.Models
{
    [Table("web_admin_account")]
    public partial class Web_admin_account
    {
        public int Id { get; set; }
        public int? Isdelete { get; set; }
        /// <summary>
        /// 帐户名
        /// </summary>
        public string Accountname { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Psw { get; set; }
        /// <summary>
        /// 是否在用
        /// </summary>
        public int? Isenable { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        ///             注解
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 是否是管理员
        /// </summary>
        public int? Isadmin { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Cre_date { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Cre_man { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}
