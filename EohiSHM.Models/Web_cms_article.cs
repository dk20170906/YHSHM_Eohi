using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EohiSHM.Models
{
    [Table("web_cms_article")]
    public partial class Web_cms_article
    {
        /// <summary>
        /// 文章id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public int? IsVisibel { get; set; }
        public string IsVisibelStr { get; set; }
        /// <summary>
        /// 文章类型
        /// </summary>
        public int? TypeNote { get; set; }
      ////  文章类型
        public string TypeNoteStr { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string Usetype { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string Fromtype { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 副标题
        /// </summary>
        public string Subtitle { get; set; }
        /// <summary>
        /// 预览图
        /// </summary>
        public string Previewimg { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Txt { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? Pubdate { get; set; }
        /// <summary>
        /// 发布时间Str
        /// </summary>
        public string PubdateStr { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Cre_date { get; set; }
        /// <summary>
        /// 创建时间str
        /// </summary>
        public string Cre_Time { get; set; }
        /// <summary>
        /// 活动举办时间
        /// </summary>
        public DateTime? ConductsTime { get; set; }
        /// <summary>
        /// 活动举办时间str
        /// </summary>
        public string ConductsTimestr { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Cre_man { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? Mod_date { get; set; }
        /// <summary>
        /// 修改时间str
        /// </summary>
        public string Mod_Time { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string Mod_man { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 打开多少次
        /// </summary>
        public int? CountNo { get; set; }
        /// <summary>
        /// 本期封面人物
        /// </summary>
        public string PeriodCover { get; set; }
        /// <summary>
        /// 本期封面人物职务
        /// </summary>
        public string PeriodCoverJob { get; set; }
        /// <summary>
        /// 本期封面人物简介
        /// </summary>
        public string PeriodCoverSummary { get; set; }
        /// <summary>
        /// 行业杂志封面人物 发展史;
        /// </summary>
        public string Phylogeny { get; set; }
        /// <summary>
        /// 超链接
        /// </summary>
        public string Hyperlink { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public string AppendixName { get; set; }
        /// <summary>
        /// 是否已上传附件
        /// </summary>
        public string AppendixStr { get; set; }
        /// <summary>
        /// 视频文件
        /// </summary>
        public string VideoFile { get; set; }
    }
}
