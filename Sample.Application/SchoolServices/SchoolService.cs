using AutoMapper;
using Sample.Application.SchoolServices.Dto;
using Sample.Domain.AggregateModel.SchoolAggregate;
using Sample.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.SchoolService
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchool _schoolRepository;
        private readonly IMapper _mapper;
        public SchoolService(ISchool schoolRepository, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<School>> GetSchool(int page = 1, int count= 10)
        {
            return await _schoolRepository.GetAllAsync(page, count);
        }

        public async Task<School> GetSchool(long id)
        {
            return await _schoolRepository.GetAsync(id);
        }

        public async Task<School> AddSchool(AddSchoolDto addSchoolDto, string username)
        {
            School school = _mapper.Map<School>(addSchoolDto);
            return await _schoolRepository.AddAsync(school, username);
        }

        public async Task<School> UpdateSchool(UpdateSchoolDto updateschoolDto, string username)
        {
            School school = _mapper.Map<School>(updateschoolDto);
            return await _schoolRepository.UpdateAsync(school, username);
        }

        public async Task<bool> DeleteSchool(long id, string username)
        {
            return await _schoolRepository.DeleteAsync(id, username);
        }
    }
}
