using Common.Domain.Models;
using OneForAll.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Dtos;

namespace Common.Application.Interfaces
{
    /// <summary>
    /// 应用服务：节假日
    /// </summary>
    public interface IComHolidayService
    {
        /// <summary>
        /// 获取库存记录列表
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>实体</returns>
        Task<IEnumerable<ComHolidayDto>> GetListWithHolidayAsync(string name);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="tenantId">机构id</param>
        /// <param name="entity">节假日实体</param>
        /// <returns>添加结果</returns>
        Task<BaseErrType> AddAsync(Guid tenantId, ComHolidayForm entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>结果</returns>
        Task<BaseErrType> UpdateAsync(Guid tenatId,ComHolidayForm entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>结果</returns>
        Task<BaseErrType> DeleteAsync(Guid id);
    }
}
