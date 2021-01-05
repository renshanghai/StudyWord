using WMS.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using OneForAll.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMS.Application.Interfaces;

namespace WMS.Host.Controllers
{

    [Route("api/[controller]")]
    public class WmsStocksController : BaseController
    {
        IWmsStockService _WmsStockService;

        public WmsStocksController(
           IWmsStockService WmsStockService
           )
        {
            _WmsStockService = WmsStockService;
        }

        /// <summary>
        /// 分类查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("WmsClassifiCation")]
        public  async Task<IEnumerable<WmsGoodTypesDto>> GetListWithClassifiCationAsync() 
        {
            return await _WmsStockService.GetListWithClassifiCationAsync();
        }

        /// <summary>
        /// 仓库查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("WmsWarehouse")]
        public async Task<IEnumerable<WmsWarehouseDto>> GetListWithWarehouseAsync() 
        {
            return await _WmsStockService.GetListWithWarehouseAsync();
        }

        /// <summary>
        /// 库存表分页查询
        /// </summary>
        /// <param name="classifiCationId">分类id</param>
        /// <param name="goodsid"></param>
        /// <param name="warehouseId">仓库id</param>
        /// <param name="condition">名称型号条件</param>
        /// <param name="SN">SN码</param>
        /// <param name="amount">数量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{pageIndex}/{pageSize}")]
        public async Task<PageList<WmsStockDto>> GetPageList([FromQuery]Guid classifiCationId,[FromQuery]Guid goodsid,[FromQuery]IEnumerable<Guid> warehouseId,[FromQuery]string condition, [FromQuery]string SN, [FromQuery]decimal amount, int pageIndex, int pageSize)
        {
            return await _WmsStockService.GetPageAsync(classifiCationId, goodsid, warehouseId, condition,  SN,  amount,  pageIndex,  pageSize);
        }

        /// <summary>
        /// 库存表导出
        /// </summary>
        /// <param name="condition">名称型号条件</param>
        /// <param name="SN">SN码</param>
        /// <param name="amount">数量</param>
        ///  /// <param name="classifiCationId">分类id</param>
        /// <param name="goodsId">物品Id</param>
        /// <param name="warehouseId">仓库id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Export")]
        public async Task<IActionResult> ExportListAsync([FromQuery]Guid classifiCationId,[FromQuery] Guid goodsId, [FromQuery]IEnumerable< Guid> warehouseId, [FromQuery]string condition, [FromQuery] decimal amount, [FromQuery] string SN)
        {
            var file = await _WmsStockService.ExportListAsync(classifiCationId,goodsId, warehouseId, condition,  amount,  SN);
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "库存信息表.xlsx");
        }
    }
}
