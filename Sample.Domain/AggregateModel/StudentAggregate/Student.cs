using Sample.Domain.AggregateModel.SchoolAggregate;
using Sample.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Domain.AggregateModel.StudentAggregate
{
    public class Student : Entity<long>
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string BirthPlace { get; set; }
        public School School { get; set; }
    }
}
