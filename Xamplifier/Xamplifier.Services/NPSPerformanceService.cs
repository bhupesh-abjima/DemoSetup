using Xamplifier.Model;
using Xamplifier.ServiceInterfaces;
using Xamplifier.Services.Infrastructure.Handlers.Interfaces;

namespace Xamplifier.Services
{
    public class NPSPerformanceService : INPSPerformanceService
    {
        private readonly INPSPerformanceServiceHandler _npsPerformanceServiceHandler;
        public NPSPerformanceService(INPSPerformanceServiceHandler npsPerformanceServiceHandler)
        {
            _npsPerformanceServiceHandler = npsPerformanceServiceHandler;
        }
        public async Task<NPSPerformanceItem> GetAsync(int id)
        {
            return await _npsPerformanceServiceHandler.HandleGetAsync(id);
        }
        public async Task<NpsBreakdownItem> NpsBreakdownAsync()
        {
            return await _npsPerformanceServiceHandler.HandleNpsBreakdownAsync();
        }
    }
}
