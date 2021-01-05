using WMS.Application;
using WMS.Domain.Models;
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
    public class WmsOutboundsController:BaseController
    {
        IWmsOutboundService _WmsOutboundService;

        WmsLoginUser loginUser = new WmsLoginUser { Id = new Guid(), Name = "测试", UserName = "test", IsDefault = false };

        public WmsOutboundsController(
            IWmsOutboundService WmsOutboundService
            )
        {
            _WmsOutboundService = WmsOutboundService;
        }
        /// <summary>
        /// 出库表导出
        /// </summary>
        /// <param name="WmsWarehouseId">仓库Id</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="condition">单号名称型号</param>
        /// <param name="SN">SN码</param>
        /// <returns></returns>
        /// <returns></returns>
        [HttpGet]
        [Route("Export")]
        public async Task<IActionResult> ExportListAsync([FromQuery]Guid WmsWarehouseId, [FromQuery] DateTime beginTime, [FromQuery] DateTime endTime, [FromQuery] string condition, [FromQuery] string SN)
        {
            var file = await _WmsOutboundService.ExportListAsync( WmsWarehouseId,  beginTime,  endTime,  condition,  SN);
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "出库信息表.xlsx");
        }

        /// <summary>
        /// 出库表分页
        /// </summary>
        /// <param name="WmsWarehouseId">仓库Id</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="condition">单号名称型号</param>
        /// <param name="SN">SN码</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{pageIndex}/{pageSize}")]
        public async Task<PageList<WmsOutboundDto>> GetPageAsync([FromQuery]Guid WmsWarehouseId, [FromQuery] DateTime beginTime, [FromQuery]DateTime endTime, [FromQuery]string condition, [FromQuery]string SN, int pageIndex, int pageSize)
        {
            return await _WmsOutboundService.GetPageAsync(WmsWarehouseId, beginTime, endTime, condition, SN, pageIndex, pageSize);
        }
    }
}
