using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Domain.Models
{
    public class MainStatistics : Entity
    {
        public string Message { get; set; }
        public Global Global { get; set; }
        public IEnumerable<CountryDetailed> Countries { get; set; }
        public DateTime Date { get; set; }
    }
}
