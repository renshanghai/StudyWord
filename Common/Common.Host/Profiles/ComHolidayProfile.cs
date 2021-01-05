using AutoMapper;
using Common.Domain.AggregateRoots;
using Common.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Application.Dtos;

namespace Common.Host.Profiles
{
    public class ComHolidayProfile : Profile
    {
        public ComHolidayProfile()
        {
            CreateMap<ComHoliday, ComHolidayDto>();

            CreateMap<ComHolidayForm, ComHoliday>();

        }
    }
}
