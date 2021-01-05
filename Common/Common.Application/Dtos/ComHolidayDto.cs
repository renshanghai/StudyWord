using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Application.Dtos
{
    /// <summary>
    /// 实体：节假日信息
    /// </summary>
   public class ComHolidayDto
    {
        /// <summary>
        /// 节假日名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 总天数
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
