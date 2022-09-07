using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamplifier.Model;

namespace Xamplifier.Services.Infrastructure.Handlers.Interfaces
{
    public interface INPSPerformanceServiceHandler
    {
        Task<NPSPerformanceItem> HandleGetAsync(int id);
        Task<NpsBreakdownItem> HandleNpsBreakdownAsync();
    }
}
