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
    public class NPSPerformanceController : ControllerBase
    {
        private readonly INPSPerformanceHandler _npsPerformanceHandler;
        private readonly ILogger<NPSPerformanceController> _logger;
        public NPSPerformanceController(ILogger<NPSPerformanceController> logger, INPSPerformanceHandler npsPerformanceHandler)
        {
            _logger = logger;
            _npsPerformanceHandler = npsPerformanceHandler;
        }

        [HttpGet]
        [Route("[controller]GetAll")]
        public async Task<ResponseWrapper<NPSPerformanceItem>> Get(int id)
        {
            var response = new ResponseWrapper<NPSPerformanceItem>();
            try
            {
                response.Set(await _npsPerformanceHandler.HandleGetAsync(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Exception in Xamplifier/NPSPerformance/Get. Data:{id}");
                response.Set(e);
            }

            return response;
        }


        [HttpGet]
        [Route("[controller]NpsBreakdown")]
        public async Task<ResponseWrapper<NpsBreakdownItem>> NpsBreakdown()
        {
            var response = new ResponseWrapper<NpsBreakdownItem>();
            try
            {
                response.Set(await _npsPerformanceHandler.HandleNpsBreakdownAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Exception in Xamplifier/NPSPerformance/HandleNpsBreakdown");
                response.Set(e);
            }

            return response;
        }
    }
}
