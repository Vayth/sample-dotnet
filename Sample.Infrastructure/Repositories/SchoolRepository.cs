using Microsoft.EntityFrameworkCore;
using Sample.Domain.AggregateModel.SchoolAggregate;
using Sample.Domain.SeedWork;
using Sample.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure.Repositories
{
    public class SchoolRepository : Repository<School, long>, ISchool
    {
        public SchoolRepository(SampleDbContext context) : base(context)
        {

        }
    }
}
