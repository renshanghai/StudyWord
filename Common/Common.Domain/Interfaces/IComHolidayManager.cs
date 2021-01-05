using Common.Domain.Models;
using OneForAll.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Interfaces
{
    /// <summary>
    /// 领域服务：节假日
    /// </summary>
    public interface IComHolidayManager
    {
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
        /// <param name="tenantId"></param>
        /// <param name="entity">实体</param>
        /// <returns>结果</returns>
        Task<BaseErrType> UpdateAsync(Guid tenantId, ComHolidayForm entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>结果</returns>
        Task<BaseErrType> DeleteAsync(Guid id);
    }
}
