using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamplifier.Model;

namespace Xamplifier.ServiceInterfaces
{
     public interface IReputationService
    {
        public Task<NPSPerformanceItem> GetAsync(int id);
    }
}
