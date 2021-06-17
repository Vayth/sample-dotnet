using Sample.Application.SchoolServices.Dto;
using Sample.Domain.AggregateModel.SchoolAggregate;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Application.SchoolService
{
    public interface ISchoolService
    {
        Task<IEnumerable<School>> GetSchool(int page, int count);
        Task<School> GetSchool(long id);
        Task<School> AddSchool(AddSchoolDto schoolDto, string username);
        Task<School> UpdateSchool(UpdateSchoolDto schoolDto, string username);
        Task<bool> DeleteSchool(long id, string username);
    }
}
