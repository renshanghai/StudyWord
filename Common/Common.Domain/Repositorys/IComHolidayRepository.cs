using Common.Domain.AggregateRoots;
using OneForAll.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Repositorys
{
    /// <summary>
    /// 仓储：节假日
    /// </summary>
    public interface IComHolidayRepository : IEFCoreRepository<ComHoliday>
    {
        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="name">节假日名称</param>
        /// <returns>查询结果</returns>
        Task<IEnumerable<ComHoliday>> GetListWithHolidayAsync(string name);
    }
}
