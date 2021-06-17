using AutoMapper;
using Sample.Application.SchoolServices.Dto;
using Sample.Domain.AggregateModel.SchoolAggregate;
using Sample.Domain.AggregateModel.StudentAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Application.AutoMap
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<School, AddSchoolDto>();
            CreateMap<AddSchoolDto, School>();

            CreateMap<School, UpdateSchoolDto>();
            CreateMap<UpdateSchoolDto, School>();

            // CreateMap<Student, AddStudentDto>();
            // CreateMap<AddStudentDto, Student>();

            // CreateMap<Student, UpdateStudentDto>();
            // CreateMap<UpdateStudentDto, Student>();
        }
    }
}
