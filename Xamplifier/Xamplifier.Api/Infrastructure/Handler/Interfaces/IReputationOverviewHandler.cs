using Xamplifier.Model;

namespace Xamplifier.Api.Infrastructure.Handler.Interfaces
{
    public interface IReputationOverviewHandler
    {
        public Task<NPSPerformanceItem> HandleGetAsync();
    }
}
