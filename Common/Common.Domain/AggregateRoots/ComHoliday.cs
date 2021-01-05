using OneForAll.Core;
using OneForAll.Core.DDD;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Domain.AggregateRoots
{
    /// <summary>
    /// 节假日
    /// </summary>
   public class ComHoliday : AggregateRoot<Guid>, ITenant<Guid>
    {
        public Guid TenantId { get; set; }

        /// <summary>
        /// 节假日名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Date { get; set; }

        /// <summary>
        /// 总天数
        /// </summary>
        [Required]
        public int Day { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
         [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
    }
}
