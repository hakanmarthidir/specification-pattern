using Microsoft.EntityFrameworkCore;
using specification_pattern.Domain;
using specification_pattern.Domain.Specs;
using specification_pattern.Infrastructure.Persistence;

namespace specification_pattern.Application
{
    public class StudentService : IStudentService
    {
        //SpecificationDbContext _dbContext;
        IRepository<Student> _repository;
        
        public StudentService(IRepository<Student> repository)
        {
            this._repository = repository ?? throw new ArgumentNullException("Database Context can not be null.");
        }

        public async Task<Student> GetActiveStudentByIdAsync(int id)
        {            
            return await this._repository.GetById(id).ConfigureAwait(false);
            //return await this._dbContext.Students.AsQueryable().SingleAsync<Student>(x=>x.Id == id && x.Status == Status.Active).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Student>> GetAllStudentsByStatusAsync(Status status)
        {
            return await this._repository.GetAll(x=> x.Status == status).ConfigureAwait(false);
            //return await this._dbContext.Students.AsQueryable().Where(x => x.Status == Status.Active).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Student>> GetUsersBySpec(ISpec<Student> spec, CancellationToken cancellationToken = default)
        {
            //var specQuery = SetSpec(spec);
            //var students = await specQuery.ToListAsync().ConfigureAwait(false);
            var students = await this._repository.GetAllBySpecAsync(spec).ConfigureAwait(false);
            return students;
        }        

        //private IQueryable<Student> SetSpec(ISpec<Student> specification)
        //{
        //    return SpecHandler<Student>.GetQuery(_dbContext.Students.AsQueryable(), specification);
        //}
    }
}
