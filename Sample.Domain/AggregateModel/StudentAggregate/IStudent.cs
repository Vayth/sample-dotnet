using Sample.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.AggregateModel.StudentAggregate
{
    public interface IStudent : IRepository<Student, long>
    {
    }
}
