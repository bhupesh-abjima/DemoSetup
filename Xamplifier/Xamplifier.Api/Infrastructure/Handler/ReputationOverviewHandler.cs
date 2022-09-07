using Xamplifier.Api.Infrastructure.Handler.Interfaces;
using Xamplifier.Model;
using Xamplifier.ServiceInterfaces;

namespace Xamplifier.Api.Infrastructure.Handler
{
    public class ReputationOverwiewHandler : IReputationOverviewHandler
    {
        
        private readonly ILogger<IReputationOverviewHandler> _logger;
        private readonly IReputationService _reputationService;
        public ReputationOverwiewHandler(ILogger<IReputationOverviewHandler> logger, IReputationOverviewHandler reputationService)
        {
            _logger = logger;
            _reputationService = reputationService;
        }
        public async Task<NPSPerformanceItem> HandleGetAsync()
        {
            return await _reputationService.GetAsync();
        }
      
    }
}

