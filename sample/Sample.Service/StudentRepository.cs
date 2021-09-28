using Fop;
using Microsoft.EntityFrameworkCore;
using Sample.Data;
using Sample.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> RetrieveStudents(IGridRequest request)
        {
            var filteredStudents = _context.Students.Include(x => x.Department).Gridify(request);
            return await filteredStudents.ToListAsync();
        }
    }
}
