using Gridify;
using Microsoft.AspNetCore.Mvc;
using Sample.Repository;

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
        public IActionResult Index(GridRequest request)
        {
            var filteredStudents = _studentRepository.RetrieveStudents(request).InitSchema<StudentGridResponse>(request);

            return Ok(filteredStudents);
        }
    }
}