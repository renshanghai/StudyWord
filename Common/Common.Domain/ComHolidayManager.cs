using AutoMapper;
using Common.Domain.AggregateRoots;
using Common.Domain.Interfaces;
using Common.Domain.Models;
using Common.Domain.Repositorys;
using OneForAll.Core;
using OneForAll.Core.DDD;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    /// <summary>
    /// 领域服务：节假日
    /// </summary>
    public class ComHolidayManager : BaseManager, IComHolidayManager
    {
        private readonly IMapper _mapper;
        private readonly IComHolidayRepository _comHolidayRepository;
        public ComHolidayManager(
            IMapper mapper,
            IComHolidayRepository comHolidayRepository
            )
        {
            _mapper = mapper;
            _comHolidayRepository = comHolidayRepository;
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="tenantId">机构id</param>
        /// <param name="entity">节假日实体</param>
        /// <returns>添加结果</returns>
        public async Task<BaseErrType> AddAsync(Guid tenantId, ComHolidayForm entity) 
        {
            var data  = _mapper.Map<ComHolidayForm, ComHoliday>(entity);
            data.TenantId = tenantId;
            data.Id = Guid.NewGuid();
            data.CreateDate = DateTime.Now;
            return await ResultAsync(() => _comHolidayRepository.AddAsync(data));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>结果</returns>
        public async Task<BaseErrType> UpdateAsync(Guid tenantId, ComHolidayForm entity)
        {
            var data = await _comHolidayRepository.GetAsync(w=>w.Id.Equals(entity.Id));
            if (data == null) return BaseErrType.DataNotFound;
            data.TenantId = tenantId;
            data= _mapper.Map<ComHolidayForm, ComHoliday>(entity);
            data.CreateDate = DateTime.Now;
            return await ResultAsync(() => _comHolidayRepository.UpdateAsync(data));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>结果</returns>
        public async Task<BaseErrType> DeleteAsync(Guid id) {
            var data = await _comHolidayRepository.FindAsync(id);
            if (data == null) return BaseErrType.DataNotFound;
       
            return await ResultAsync(() => _comHolidayRepository.DeleteAsync(data));
        }
    }
}
