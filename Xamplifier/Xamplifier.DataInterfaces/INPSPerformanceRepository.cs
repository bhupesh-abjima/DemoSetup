using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamplifier.Domain;

namespace Xamplifier.DataInterfaces
{
    public  interface INPSPerformanceRepository : IRepository<NPSPerformanceDto>
    {
        Task<NPSPerformanceDto> GetAsync(int id);
        Task<NpsBreakdownDto> NpsBreakdownAsync();
        Task<NPSPerformanceDto> GetReputationAsync();
    }
}
