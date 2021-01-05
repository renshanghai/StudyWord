namespace Common.Domain.ValueObjects
{
    /// <summary>
    /// 值：重复入库详情
    /// </summary>
    public class WmsDuplicateInWarehouseDetail
    {
        /// <summary>
        /// 序列号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehouseName { get; set; }
    }
}
