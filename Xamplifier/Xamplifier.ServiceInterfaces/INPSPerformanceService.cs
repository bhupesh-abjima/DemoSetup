using Xamplifier.Model;

namespace Xamplifier.ServiceInterfaces
{
    public interface INPSPerformanceService
    {
        public Task<NPSPerformanceItem> GetAsync(int id);
        public Task<NpsBreakdownItem> NpsBreakdownAsync();
    }
    
}