using Common.Domain.AggregateRoots;
using Common.Domain.Repositorys;
using Microsoft.EntityFrameworkCore;
using OneForAll.Core.ORM;
using OneForAll.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    /// <summary>
    /// 仓储：节假日
    /// </summary>
   public class ComHolidayRepository : Repository<ComHoliday>, IComHolidayRepository
    {
        public ComHolidayRepository(DbContext context) : base(context) { }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="name">节假日名称</param>
        /// <returns></returns>
        public async Task<IEnumerable<ComHoliday>> GetListWithHolidayAsync(string name)
        {
            var predicate = PredicateBuilder.Create<ComHoliday>(w => true);
            if (!string.IsNullOrEmpty(name))
            {
                predicate = predicate.And(w =>w.Name.Contains(name));
            }
            return await DbSet
               .Where(predicate)
               .ToListAsync();
        }

    }
    }
