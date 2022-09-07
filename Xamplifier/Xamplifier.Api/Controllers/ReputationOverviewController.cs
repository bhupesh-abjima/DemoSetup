using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xamplifier.Api.Infrastructure.Handler.Interfaces;
using Xamplifier.Api.Models.Response;
using Xamplifier.Model;

namespace Xamplifier.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ReputationOverviewController : ControllerBase
    {
        private readonly IReputationHandler _reputationHandler;
        private readonly ILogger<ReputationOverviewController> _logger;
        public ReputationOverviewController(ILogger<ReputationOverviewController> logger, IReputationHandler reputationHandler)
        {
            _logger = logger;
            _reputationHandler = reputationHandler;
        }

        [HttpGet]
        [Route("[controller]GetAllReviews")]
        public async Task<ResponseWrapper<NPSPerformanceItem>> GetAll(int id)
        {
            var response = new ResponseWrapper<NPSPerformanceItem>();
            try
            {
                response.Set(await _reputationHandler.HandleGetAsync(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Exception in Xamplifier/reputationOverview/GetAllReview");
                response.Set(e);
            }

            return response;
        }
    }
}
