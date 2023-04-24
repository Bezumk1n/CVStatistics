using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Domain.Models.DTO
{
    public class RequestResultDTO
    {
        public string Message { get; set; }
        public bool isSuccess { get; set; }
        public IEnumerable<object> Value { get; set; }
    }
}
