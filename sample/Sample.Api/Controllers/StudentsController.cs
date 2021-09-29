using Microsoft.AspNetCore.Mvc;
using Sample.Api.Models;
using Sample.Entity;
using Sample.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gridify;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] GridRequest request)
        {
            var filteredStudents = await _studentRepository.RetrieveStudents(request);

            return Ok(filteredStudents);
        }

        // You can implement paged result strategy depends on your strategy
        // It's simple 
        // you can contribute to improve it
        [HttpGet("PagedResult")]
        public async Task<IActionResult> PagedResult([FromQuery] GridRequest request)
        {
            var filteredStudents = await _studentRepository.RetrieveStudents(request);

            var response = new PagedResult<List<Student>>(filteredStudents, request.Pagination.PageNumber, request.Pagination.PageSize);

            return Ok(response);
        }
    }
}