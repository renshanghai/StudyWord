using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneForAll.Core;
using OneForAll.Core.Upload;
using Common.Domain.Models;
using Common.Host.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application.Interfaces;
using Common.Application.Dtos;

namespace Common.Host.Controllers
{
    /// <summary>
    /// 控制器：节假日
    /// </summary>
    [Route("api/[controller]")]
    //[Authorize(Roles = UserRoleType.ADMIN)]
    public class ComHolidaysController : BaseController
    {

        private readonly IComHolidayService _ComHolidayService;
        public ComHolidaysController(
           IComHolidayService ComHolidayService
            )
        {
            _ComHolidayService = ComHolidayService;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>查询结果</returns>
        [HttpGet]
        public async Task<IEnumerable<ComHolidayDto>> GetAsyncs(
          [FromQuery] string name
            )
        {
            return await _ComHolidayService.GetListWithHolidayAsync(name);
        }

        /// <summary>
        /// 添加
        /// </summary>
        [HttpPost]
        public async Task<BaseMessage> AddAsync([FromBody] ComHolidayForm entity)
        {
            var msg = new BaseMessage();
            msg.ErrType = await _ComHolidayService.AddAsync(TenantId, entity);

            switch (msg.ErrType)
            {
                case BaseErrType.Success: return msg.Success("添加成功");
                default: return msg.Fail("添加失败");
            }
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>结果</returns>
        [HttpPut]
        public async Task<BaseMessage> UpdateAsync([FromBody] ComHolidayForm entity)
        {
            var msg = new BaseMessage();
            msg.ErrType = await _ComHolidayService.UpdateAsync(TenantId,entity);
            switch (msg.ErrType)
            {
                case BaseErrType.Success: return msg.Success("修改成功");
                case BaseErrType.DataNotFound: return msg.Fail("未找到该纪录");
                default: return msg.Fail("失败");
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public async Task<BaseMessage> DeleteAsync(Guid id)
        {
            var msg = new BaseMessage();
            msg.ErrType = await _ComHolidayService.DeleteAsync(id);
            switch (msg.ErrType)
            {
                case BaseErrType.Success: return msg.Success("删除成功");
                case BaseErrType.NotAllow: return msg.Fail("该记录不存在");
                default: return msg.Fail("删除失败");
            }
        }

    }
}
