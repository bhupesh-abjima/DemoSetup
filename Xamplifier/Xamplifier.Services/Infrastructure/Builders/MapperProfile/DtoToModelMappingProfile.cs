using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamplifier.Domain;
using Xamplifier.Model;

namespace Xamplifier.Services.Infrastructure.Builders.MapperProfile
{
    public class DtoToModelMappingProfile : Profile
    {
        public DtoToModelMappingProfile()
        {
            CreateMap<NPSPerformanceDto, NPSPerformanceItem>();

            CreateMap<NpsBreakdownDto, NpsBreakdownItem>();
        }
    }
}
