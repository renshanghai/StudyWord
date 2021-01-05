using WMS.Application.Dtos;
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
    public class WmsWarehousingsController:BaseController
    {
        IWmsWarehousingService _WmsWarehousingService;

        WmsLoginUser loginUser = new WmsLoginUser { Id = new Guid(), Name = "测试", UserName = "test", IsDefault = false };

        public WmsWarehousingsController(
            IWmsWarehousingService WmsWarehousingService
            )
        {
            _WmsWarehousingService = WmsWarehousingService;
        }
        /// <summary>
        /// 入库添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<BaseMessage> AddAsync([FromBody]WmsWarehousingForm entity)
        {
            var msg = new BaseMessage();
            if (ModelState.IsValid)
            {
                msg.ErrType = await _WmsWarehousingService.AddAsync(loginUser, entity);
                switch (msg.ErrType)
                {
                    case BaseErrType.Success: return msg.Success("添加成功");
                    case BaseErrType.DataNotMatch: return msg.Fail("数量不能为空");
                    case BaseErrType.DataNotFound: return msg.Fail("未找到仓库或者未找到物品");
                    case BaseErrType.DataEmpty: return msg.Fail("入库时间不能为空");
                    case BaseErrType.NotAllow: return msg.Fail("SN码存在类型与库存不符");
                    default: return msg.Fail("添加失败");
                }
            }
            else
            {
                return msg.Fail(BaseErrType.DataError, GetModelStateFirstError(ModelState));
            }
        }

        /// <summary>
        /// 获取物品信息
        /// </summary>
        /// <param name="condition">物品编号\规格型号\物品名称条件</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetGoods")]
        public async Task<IEnumerable<WmsGoodsDto>> GetListWithGoods([FromQuery]string condition)
        {
            return await _WmsWarehousingService.GetListAsync(condition);
        }

        /// <summary>
        /// 获取仓库信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetWarehouse")]
        public async Task<IEnumerable<WmsWarehouseDto>> GetWithWarehouse()
        {
            return await _WmsWarehousingService.GetWithWarehouse();
        }

        /// <summary>
        /// 入库物品表分页查询
        /// </summary>
        /// <param name="warehouseId">仓库id</param>
        /// <param name="condition">型号名称备注条件</param>
        /// <param name="SN">SN码</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{pageIndex}/{pageSize}")]
        public async Task<PageList<WmsWarehousingGoodsDto>> GetPageList([FromQuery]Guid warehouseId,[FromQuery] string condition,[FromQuery]string SN, [FromQuery] DateTime startTime, [FromQuery] DateTime endTime, int pageIndex, int pageSize) 
        {
            return await _WmsWarehousingService.GetPageAsync(warehouseId, condition, SN, startTime, endTime, pageIndex, pageSize);
        }

        /// <summary>
        /// 入库表导出
        /// </summary>
        /// <param name="warehouseId">仓库Id</param>
        /// <param name="condition">型号名称备注条件</param>
        /// <param name="SN">SN码</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Export")]
        public async Task<IActionResult> ExportListAsync([FromQuery]Guid warehouseId, [FromQuery]string condition, [FromQuery]string SN, [FromQuery] DateTime startTime, [FromQuery]DateTime endTime) 
        {
            var file = await _WmsWarehousingService.ExportListAsync(warehouseId, condition, SN, startTime, endTime);
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "入库信息表.xlsx");
        }

        /// <summary>
        /// 入库物品删除
        /// </summary>
        /// <param name="id">入库物品Id</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("WarehousingGoods/{id}")]
        public async Task<BaseMessage> DeleteAsync(Guid id) 
        {
            var msg = new BaseMessage();
            msg.ErrType = await _WmsWarehousingService.DeleteAsync(loginUser, id);
            switch (msg.ErrType) 
            {
                case BaseErrType.Success: return msg.Success("删除成功");
                case BaseErrType.DataNotFound:return msg.Fail("该入库物品记录未找到");
                default: return msg.Fail("删除失败");
            }
        }

        /// <summary>
        /// 入库物品SN删除
        /// </summary>
        /// <param name="id">入库物品SN表Id</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("SN/{id}")]
        public async Task<BaseMessage> DeleteWithSNAsync(Guid id)
        {
            var msg = new BaseMessage();
            msg.ErrType = await _WmsWarehousingService.DeleteWithSNAsync(loginUser, id);
            switch (msg.ErrType)
            {
                case BaseErrType.Success: return msg.Success("删除成功");
                case BaseErrType.DataNotFound: return msg.Fail("该入库物品SN未找到");
                default: return msg.Fail("删除失败");
            }
        }

       
    }
}
