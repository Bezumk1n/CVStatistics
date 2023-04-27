using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Domain.Models
{
    public class MainStatistics
    {
        public string ID { get; set; }
        public string Message { get; set; }
        public Global Global { get; set; }
        public IEnumerable<CountryDetailed> Countries { get; set; }
        public DateTime Date { get; set; }
    }
}
