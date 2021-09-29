using Gridify;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.Models;
using Sample.Entity;
using Sample.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<IActionResult> Index(GridRequest request)
        {
            var filteredStudents = await _studentRepository.RetrieveStudents(request);

            return Ok(filteredStudents);
        }

        // You can implement paged result strategy depends on your strategy
        // It's simple 
        // you can contribute to improve it
        [HttpPost("PagedResult")]
        public async Task<IActionResult> PagedResult(GridRequest request)
        {
            var filteredStudents = await _studentRepository.RetrieveStudents(request);

            var response = new PagedResult<List<Student>>(filteredStudents, request.Pagination.PageNumber, request.Pagination.PageSize);

            return Ok(response);
        }
    }
}