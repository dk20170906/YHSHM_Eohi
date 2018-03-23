using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EohiSHM.Models
{
    [Table("web_recruit")]
 public  class Web_Recruit
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public int? IsVisibel { get; set; }
        public string IsVisibelStr { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string PositionJob { get; set; }
        /// <summary>
        /// 工作地点
        /// </summary>
        public string WorkingPlace { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Cre_Time { get; set; }
        public string Cre_date { get; set; }
        /// <summary>
        /// 有效时间 time
        /// </summary>
       public DateTime? Valid_Time { get; set; }
        /// <summary>
        /// 有效时间      str
        /// </summary>
        public string TermOfValidity { get; set; }
        /// <summary>
        /// 人数
        /// </summary>
        public int? CountInt { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string Providtext { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string Cytyidtext { get; set; }
        /// <summary>
        /// 区县
        /// </summary>
        public string Areaidtext { get; set; }
        public string AreaidtextLong { get; set; }
    }
}
