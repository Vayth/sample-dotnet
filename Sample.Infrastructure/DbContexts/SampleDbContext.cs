using Microsoft.EntityFrameworkCore;
using Sample.Domain.AggregateModel.SchoolAggregate;
using Sample.Domain.AggregateModel.StudentAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure.DbContexts
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options)
        : base(options)
        { }

        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
