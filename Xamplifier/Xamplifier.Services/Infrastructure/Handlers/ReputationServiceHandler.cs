using System;
using Xamplifier.DataInterfaces;
using Xamplifier.Model;
using Xamplifier.Services.Infrastructure.Builders.Interfaces;
using Xamplifier.Services.Infrastructure.Handlers.Interfaces;

namespace Xamplifier.Services.Infrastructure.Handlers
{
    public class ReputationServiceHandler : IReputationServiceHandler
    {
        private readonly INPSPerformanceRepository _npsPerformanceRepository;
       private readonly INPSPerformanceBuilder _npsPerformanceBuilder;
        public ReputationServiceHandler(INPSPerformanceRepository npsPerformanceRepository, INPSPerformanceBuilder npsPerformanceBuilder)
        {
            _npsPerformanceRepository = npsPerformanceRepository;
            _npsPerformanceBuilder = npsPerformanceBuilder;
        }
        public async Task<NPSPerformanceItem> HandleGetAsync()
        {
            var npsPerformanceDtos = await _npsPerformanceRepository.GetReputationAsync(id);
            var npsPerformancItem = _npsPerformanceBuilder.Build(npsPerformanceDtos);
            return npsPerformancItem;
        }
        
    }
}
