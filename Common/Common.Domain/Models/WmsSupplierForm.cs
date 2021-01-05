using OneForAll.Core.DDD;
using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Domain.Models
{
    /// <summary>
    /// 表单：供应商表
    /// </summary>
    public class WmsSupplierForm : Entity<Guid>
    {
        /// <summary>
        /// 供应商名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        ///<summary>
        /// 品牌
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Brand { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Contacts { get; set; }

        ///<summary>
        ///联系电话
        /// </summary>
        [StringLength(20)]
        public string Phone { get; set; }

        ///<summary>
        ///QQ号码
        /// </summary>
        [StringLength(20)]
        public string QQ { get; set; }

        ///<summary>
        ///邮箱
        /// </summary>
        [StringLength(30)]
        public string Mailbox { get; set; }

        ///<summary>
        ///联系地址
        /// </summary>
        [StringLength(30)]
        public string Address { get; set; }

        /// <summary>
        /// 产品范围
        /// </summary>
        [StringLength(500)]
        public string ProductScope { get; set; }

    }
}
