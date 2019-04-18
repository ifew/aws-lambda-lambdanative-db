using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace aws_lambda_lambdanative
{
    public class MemberContext : DbContext
    {
        public MemberContext(DbContextOptions<MemberContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<ProfileModel> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfileModel>()
                        .HasKey(m => m.Id);
        }

    }
}