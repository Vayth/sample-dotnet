using Sample.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Domain.AggregateModel.SchoolAggregate
{
    public class School : Entity<long>
    {
        public string Name { get; set; }
        public string Area { get; set; }
    }
}
