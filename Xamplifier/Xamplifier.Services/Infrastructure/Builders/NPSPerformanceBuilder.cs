using AutoMapper;
using System;
using System.Collections.Generic;
using Xamplifier.Domain;
using Xamplifier.Model;
using Xamplifier.Services.Infrastructure.Builders.Interfaces;

namespace Xamplifier.Services.Infrastructure.Builders
{
    public class NPSPerformanceBuilder : INPSPerformanceBuilder
    {
        private readonly IMapper _mapper;
        public NPSPerformanceBuilder(IMapper mapper)
        {
            _mapper = mapper;
        }
        public NPSPerformanceItem Build(NPSPerformanceDto npsPerformanceDto)
        {
            return _mapper.Map<NPSPerformanceItem>(npsPerformanceDto);
        }

        public NPSPerformanceDto Build(NPSPerformanceItem npsPerformanceItem)
        {
            return _mapper.Map<NPSPerformanceDto>(npsPerformanceItem);
        }
        public NpsBreakdownItem Build(NpsBreakdownDto dto)
        {
            return _mapper.Map<NpsBreakdownItem>(dto);
        }

        public NpsBreakdownDto Build(NpsBreakdownItem item)
        {
            return _mapper.Map<NpsBreakdownDto>(item);
        }
    }
}
