using Xamplifier.Model;

namespace Xamplifier.Api.Infrastructure.Handler.Interfaces
{
    public interface INPSPerformanceHandler
    {
        public Task<NPSPerformanceItem> HandleGetAsync(int id);
        public Task<NpsBreakdownItem> HandleNpsBreakdownAsync();
    }
}
