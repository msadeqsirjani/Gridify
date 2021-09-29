using Gridify;
using Gridify.Result;

namespace Sample.Repository
{
    public interface IStudentRepository
    {
        ServiceResult RetrieveStudents(GridRequest request);
    }
}
