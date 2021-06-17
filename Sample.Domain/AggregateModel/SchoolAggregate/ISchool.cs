using Sample.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Domain.AggregateModel.SchoolAggregate
{
    public interface ISchool : IRepository<School, long>
    {
    }
}
