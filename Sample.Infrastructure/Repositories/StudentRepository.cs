using Microsoft.EntityFrameworkCore;
using Sample.Domain.AggregateModel.StudentAggregate;
using Sample.Domain.SeedWork;
using Sample.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Repositories
{
    public class StudentRepository : Repository<Student, long>, IRepository<Student, long>
    {
        private readonly SampleDbContext _context;

        public StudentRepository(SampleDbContext context) : base(context)
        {
        }
    }
}
