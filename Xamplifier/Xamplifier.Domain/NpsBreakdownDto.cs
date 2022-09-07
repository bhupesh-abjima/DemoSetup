using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamplifier.Domain
{
    public class NpsBreakdownDto
    {
        public int Promotor { get; set; }
        public int Detractors { get; set; }
        public int Passive { get; set; }
        public int Total { get; set; }
    }
}
