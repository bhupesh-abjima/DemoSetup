using Xamplifier.Api.Infrastructure.Handler.Interfaces;
using Xamplifier.Model;
using Xamplifier.ServiceInterfaces;

namespace Xamplifier.Api.Infrastructure.Handler
{
    public class NPSPerformanceHandler : INPSPerformanceHandler
    {
        
        private readonly ILogger<INPSPerformanceHandler> _logger;
        private readonly INPSPerformanceService _npsPerformanceService;
        public NPSPerformanceHandler(ILogger<INPSPerformanceHandler> logger, INPSPerformanceService npsPerformanceService )
        {
            _logger = logger;
            _npsPerformanceService = npsPerformanceService;
        }
        public async Task<NPSPerformanceItem> HandleGetAsync(int id)
        {
            return await _npsPerformanceService.GetAsync(id);
        }
        public async Task<NpsBreakdownItem> HandleNpsBreakdownAsync()
        {
            return await _npsPerformanceService.NpsBreakdownAsync();
        }
    }
}

