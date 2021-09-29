using Gridify;
using Gridify.Result;
using Microsoft.EntityFrameworkCore;
using Sample.Data;

namespace Sample.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public ServiceResult RetrieveStudents(GridRequest request)
        {
            var filteredStudents = _context.Students
                .Include(x => x.Department)
                .Gridify(request);

            return filteredStudents;
        }
    }
}
