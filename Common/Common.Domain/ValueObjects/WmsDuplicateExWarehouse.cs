using System;
using System.Collections.Generic;

namespace Common.Domain.ValueObjects
{
    /// <summary>
    /// 值：重复出库记录
    /// </summary>
    public class WmsDuplicateExWarehouse
    {
        /// <summary>
        /// 库存id
        /// </summary>
        public Guid InventoryId { get; set; }

        /// <summary>
        /// 重复的序列号集合
        /// </summary>
        public ICollection<WmsDuplicateExWarehouseDetail> Details { get; set; }
    }
}
