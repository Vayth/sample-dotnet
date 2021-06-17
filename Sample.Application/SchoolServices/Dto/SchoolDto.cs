using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Application.SchoolServices.Dto
{
    public class AddSchoolDto
    {
        public string Name { get; set; }
        public string Area { get; set; }
    }

    public class UpdateSchoolDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
    }
}
