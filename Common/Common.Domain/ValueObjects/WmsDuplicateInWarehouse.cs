using System;
using System.Collections.Generic;

namespace Common.Domain.ValueObjects
{
    /// <summary>
    /// 值：重复入库记录
    /// </summary>
    public class WmsDuplicateInWarehouse
    {
        /// <summary>
        /// 物品id
        /// </summary>
        public Guid GoodsId { get; set; }

        /// <summary>
        /// 重复的序列号集合
        /// </summary>
        public ICollection<WmsDuplicateInWarehouseDetail> Details { get; set; }
    }
}
