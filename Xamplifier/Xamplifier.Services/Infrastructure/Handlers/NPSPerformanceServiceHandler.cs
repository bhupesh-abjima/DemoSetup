using System;
using Xamplifier.DataInterfaces;
using Xamplifier.Model;
using Xamplifier.Services.Infrastructure.Builders.Interfaces;
using Xamplifier.Services.Infrastructure.Handlers.Interfaces;

namespace Xamplifier.Services.Infrastructure.Handlers
{
    public class NPSPerformanceServiceHandler : INPSPerformanceServiceHandler
    {
        private readonly INPSPerformanceRepository _npsPerformanceRepository;
       private readonly INPSPerformanceBuilder _npsPerformanceBuilder;
        public NPSPerformanceServiceHandler(INPSPerformanceRepository npsPerformanceRepository, INPSPerformanceBuilder npsPerformanceBuilder)
        {
            _npsPerformanceRepository = npsPerformanceRepository;
            _npsPerformanceBuilder = npsPerformanceBuilder;
        }
        public async Task<NPSPerformanceItem> HandleGetAsync(int id)
        {
            var npsPerformanceDtos = await _npsPerformanceRepository.GetAsync(id);
            var npsPerformancItem = _npsPerformanceBuilder.Build(npsPerformanceDtos);
            return npsPerformancItem;
        }
        public async Task<NpsBreakdownItem> HandleNpsBreakdownAsync()
        {
            var npsBreakdownDtos = await _npsPerformanceRepository.NpsBreakdownAsync();
            var npsBreakdownItem = _npsPerformanceBuilder.Build(npsBreakdownDtos);
            return npsBreakdownItem;
        }
    }
}
