using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EohiSHM.Models
{
    public class FilterModel
    {
        /// <summary>
        ///                   过滤条件中使用的数据列
        /// </summary>
        public string Column { get; set; }//过滤条件中使用的数据列
        /// <summary>
        ///            过滤条件中的操作:==、!=等
        /// </summary>
        public string Action { get; set; }//过滤条件中的操作:==、!=等
        /// <summary>
        ///                     过滤条件之间的逻辑关系：AND和OR
        /// </summary>
        public string Logic { get; set; }//过滤条件之间的逻辑关系：AND和OR
        /// <summary>
        ///                        过滤条件中的操作的值
        /// </summary>
        public string Value { get; set; }//过滤条件中的操作的值
        /// <summary>
        ///               过滤条件中的操作的字段的类型
        /// </summary>
        public string DataType { get; set; }//过滤条件中的操作的字段的类型
    }
}
