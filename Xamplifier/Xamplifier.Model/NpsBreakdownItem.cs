using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamplifier.Model
{
    public class NpsBreakdownItem
    {
        public int Promotor { get; set; }
        public int Detractors { get; set; }
        public int Passive { get; set; }
        public int Total { get; set; }

    }
}
