using CVStatistics.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.EntityFramework
{
    public class RepositoryContext : DbContext
    {
        public DbSet<MainStatistics> Statistics { get; set; }
        public RepositoryContext(DbContextOptions options) : base(options) { }
    }
}
