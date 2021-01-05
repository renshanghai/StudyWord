using AutoMapper;
using Common.Domain.AggregateRoots;
using Common.Domain.Interfaces;
using Common.Domain.Models;
using Common.Domain.Repositorys;
using OneForAll.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Dtos;
using Common.Application.Interfaces;

namespace Common.Application
{
    /// <summary>
    /// 领域服务:节假日
    /// </summary>
    public class ComHolidayService: IComHolidayService
    {
        private readonly IMapper _mapper;
        private readonly IComHolidayManager _comHolidayManager;
        private readonly IComHolidayRepository _comHolidayRepository;
        public ComHolidayService(
            IMapper mapper,
            IComHolidayManager comHolidayManager,
            IComHolidayRepository comHolidayRepository
            )
        {
            _mapper = mapper;
            _comHolidayManager = comHolidayManager;
            _comHolidayRepository = comHolidayRepository;


        }

        /// <summary>
        /// 根据物品Id查询是否含有该库存
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public async Task<IEnumerable<ComHolidayDto>> GetListWithHolidayAsync(string name)
        {
            var data = await _comHolidayRepository.GetListWithHolidayAsync(name);
            return _mapper.Map<IEnumerable<ComHoliday>, IEnumerable<ComHolidayDto>>(data);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="tenantId">机构id</param>
        /// <param name="entity">节假日实体</param>
        /// <returns>添加结果</returns>
        public async Task<BaseErrType> AddAsync(Guid tenantId, ComHolidayForm entity)
        {
            var data =await _comHolidayManager.AddAsync(tenantId,entity);
            return data;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>结果</returns>
        public async Task<BaseErrType> UpdateAsync(Guid tenantId, ComHolidayForm entity)
        {
            return await _comHolidayManager.UpdateAsync(tenantId, entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>结果</returns>
        public async Task<BaseErrType> DeleteAsync(Guid id)
        {
            return await _comHolidayManager.DeleteAsync(id);
        }
    }
}
