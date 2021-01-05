using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Domain.Models
{
    /// <summary>
    /// 表单：节假日
    /// </summary>
   public class ComHolidayForm
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 节假日名称
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Date { get; set; }

        /// <summary>
        /// 总天数
        /// </summary>
        [Required]
        public int Day { get; set; }
    }
}
