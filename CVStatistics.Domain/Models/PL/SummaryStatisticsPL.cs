using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Domain.Models.PL
{
    public class SummaryStatisticsPL
    {
        public string ID { get; set; }
        public string Message { get; set; }
        public GlobalPL Global { get; set; }
        public IEnumerable<CountryDetailsPL> Countries { get; set; } = Enumerable.Empty<CountryDetailsPL>();
        public DateTime Date { get; set; }
    }
}
