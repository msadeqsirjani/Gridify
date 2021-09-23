using Fop;
using Sample.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> RetrieveStudents(IGridRequest request);
    }
}
