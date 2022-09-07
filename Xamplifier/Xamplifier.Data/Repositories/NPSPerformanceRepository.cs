using Dapper;
using Microsoft.Extensions.Logging;
using Xamplifier.DataInterfaces;
using Xamplifier.Domain;

using System.Data;



namespace Xamplifier.Data.Repositories
{
    public class NPSPerformanceRepository :BaseRepository<NPSPerformanceDto>, INPSPerformanceRepository
    {
        private readonly ILogger<NPSPerformanceRepository> _logger;

        public NPSPerformanceRepository(ILogger<NPSPerformanceRepository> logger, IDatabaseFactory databaseFactory)
        : base(logger, databaseFactory)
        {
            _logger = logger;
        }

        public async Task<NPSPerformanceDto> GetAsync(int id)
        {
            return await DataContext.QueryFirstOrDefaultAsync<NPSPerformanceDto>($"select campaignid,userId,EnterpriseId,Name from [Campaign].[CampaignMaster] where campaignId={id}");

        }
        public async Task<NpsBreakdownDto> NpsBreakdownAsync()
        {

            return await DataContext.QueryFirstOrDefaultAsync<NpsBreakdownDto>("[Nps].[NpsBrewakdown]", commandType: CommandType.StoredProcedure);
            //Select
            //      sum(Case when rating in (1, 2) then(1) else 0 end) as Promotor,
            //      sum(Case when rating in (3) then 1 else 0 end) as Passive,
            //      sum(Case when rating in (4, 5) then 1 else 0 end) as Detractors,
            //      SUM(case when rating  between 1 and 5then 1 else 0 end) as Total
            //      from TestRating
        }
        public async Task<NPSPerformanceDto> GetReputationAsync()
        {
            return await DataContext.QueryFirstOrDefaultAsync<NPSPerformanceDto>($"select Name,Review,rating from testrating");

        }


    }

}
