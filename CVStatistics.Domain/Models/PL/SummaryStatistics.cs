using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Domain.Models.PL
{
    public class SummaryStatistics
    {
        public string ID { get; set; }
        public string Message { get; set; }
        public Global Global { get; set; }
        public IEnumerable<CountryDetails> Countries { get; set; } = Enumerable.Empty<CountryDetails>();
        public DateTime Date { get; set; }
    }
}
