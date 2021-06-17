using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Application.SchoolService;
using Sample.Application.SchoolServices.Dto;
using Sample.Domain.AggregateModel.SchoolAggregate;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ILogger<SchoolController> _logger;
        private readonly ISchoolService _schoolService;

        public SchoolController(ILogger<SchoolController> logger, ISchoolService schoolService)
        {
            _logger = logger;
            _schoolService = schoolService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<School>>> GetSchoolsAsync(int page = 1, int count = 10)
        {
            try
            {
                IEnumerable<School> schools = await _schoolService.GetSchool(page, count);
                return Ok(schools);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<School>>> GetSchoolAsync(long id)
        {
            try
            {
                School school = await _schoolService.GetSchool(id);
                if (school == null) return NotFound(school);

                return Ok(school);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<School>> AddSchool(AddSchoolDto addSchoolDto)
        {
            try
            {
                string actionBy = "admin";
                School school = await _schoolService.AddSchool(addSchoolDto, actionBy);
                return Ok(school);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<School>> UpdateSchool(UpdateSchoolDto updateSchoolDto)
        {
            try
            {
                string actionBy = "admin";
                School school = await _schoolService.UpdateSchool(updateSchoolDto, actionBy);
                return Ok(school);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteSchool(long id)
        {
            try
            {
                string actionBy = "admin";
                bool result = await _schoolService.DeleteSchool(id, actionBy);
                if (result) return Ok("Item deleted");
                else return NotFound(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}