using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EohiSHM.AutoWeb.ViewModels
{
    public class HomeModels
    {
        /// <summary>
        /// 新闻资讯
        /// </summary>
        public List<Web_cms_article> NewsInformations { get; set; }
        /// <summary>
        ///            优海课堂
        /// </summary>
        public List<Web_cms_article> YouhaiClassrooms { get; set; }
        /// <summary>
        /// 首页视频
        /// </summary>
        public Web_cms_article YHVideoFirst { get; set; }
        /// <summary>
        /// 产品服务
        /// </summary>
        //public List<Web_cms_article> ProductServices { get; set; }
        /// <summary>
        /// 典型案例 
        /// </summary>
        public List<Web_cms_article> TypicalCases { get; set; }
        /// <summary>
        /// 新闻详情
        /// </summary>
        public Web_cms_article NewsDetails { get; set; }
        /// <summary>
        /// 优海团队
        /// </summary>
        public List<Web_cms_article> TeamsYh { get; set; }
        /// <summary>
        /// 人才招聘
        /// </summary>
        public List<Web_Recruit> Webrec { get; set; }    
    }
}