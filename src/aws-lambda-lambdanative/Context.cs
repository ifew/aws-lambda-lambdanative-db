using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace aws_lambda_lambdanative
{
    public class DistrictContext : DbContext
    {
        public DistrictContext(DbContextOptions<DistrictContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<DistrictModel> Districts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}