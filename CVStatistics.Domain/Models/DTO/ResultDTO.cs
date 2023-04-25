using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Domain.Models.DTO
{
    public class ResultDTO
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public object Value { get; set; }
    }
}
