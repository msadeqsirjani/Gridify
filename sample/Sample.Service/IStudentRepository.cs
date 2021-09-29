using Sample.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gridify;

namespace Sample.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> RetrieveStudents(IGridRequest request);
    }
}
