using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamplifier.Domain;
using Xamplifier.Model;

namespace Xamplifier.Services.Infrastructure.Builders.Interfaces
{
    public interface INPSPerformanceBuilder
    {
        NPSPerformanceItem Build(NPSPerformanceDto adminDto);
        NPSPerformanceDto Build(NPSPerformanceItem getAdminItem);
        NpsBreakdownItem Build(NpsBreakdownDto dto);
        NpsBreakdownDto Build(NpsBreakdownItem item);
    }
}
