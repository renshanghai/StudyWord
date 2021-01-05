using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Domain.Models
{
    /// <summary>
    /// 表单：仓库表
    /// </summary>
    public class WmsWarehouseForm
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 所在地点
        /// </summary>
        [Required]
        [StringLength(300)]
        public string Place { get; set; }

        /// <summary>
        /// 负责人员
        /// </summary>
        [Required]
        [StringLength(20)]
        public string PersonName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(100)]
        public string Remark { get; set; }
    }
}
