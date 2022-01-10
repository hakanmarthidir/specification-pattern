using specification_pattern.Domain;
using specification_pattern.Domain.Specs;

namespace specification_pattern.Application
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsByStatusAsync(Status status);
        Task<Student> GetActiveStudentByIdAsync(int id);
        Task<IEnumerable<Student>> GetUsersBySpec(ISpec<Student> spec, CancellationToken cancellationToken = default);
    }
}
