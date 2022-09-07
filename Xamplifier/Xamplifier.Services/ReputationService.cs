using Xamplifier.Model;
using Xamplifier.ServiceInterfaces;
using Xamplifier.Services.Infrastructure.Handlers.Interfaces;

namespace Xamplifier.Services
{
    public class ReputationService : IReputationService
    {
        private readonly IReputationServiceHandler _reputationServiceHandler;
        public ReputationService(IReputationServiceHandler reputationServiceHandler)
        {
            _reputationServiceHandler = reputationServiceHandler;
        }
        public async Task<NPSPerformanceItem> GetAsync(int id)
        {
            return await _reputationServiceHandler.HandleGetAsync(id);
        }
       
    }
}
