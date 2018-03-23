using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EohiSHM.Models
{
    /// <summary>
    /// 评论表
    /// </summary>
    [Table("web_commentary")]
  public   class Web_Commentary
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 文章id
        /// </summary>
        public int ArticleId { get; set; }
        /// <summary>
        /// 用户地址
        /// </summary>
        public string UserAddress { get; set; }
        /// <summary>
        /// 当前用户ip地址
        /// </summary>
        public string UserIpAddress { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
       public DateTime ? Cre_Time { get; set; }
        /// <summary>
        /// 创建 时间Str
        /// </summary>
        public string Cre_TimeStr { get; set; }
        /// <summary>
        /// 发表内容 
        /// </summary>
        public string PublicationContent { get; set; }
        /// <summary>
        /// 赞次数
        /// </summary>
        public int ALaud { get; set; }
        /// <summary>
        /// 当前用户是否已点赞
        /// </summary>
        public int HYLI { get; set; }
    }
}
