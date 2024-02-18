using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Number_Sorter.Models;

namespace Number_Sorter.Data
{
    public class Number_SorterContext : DbContext
    {
        public Number_SorterContext (DbContextOptions<Number_SorterContext> options)
            : base(options)
        {
        }

        public DbSet<Number_Sorter.Models.NumberSort> NumberSort { get; set; } = default!;
    }
}
