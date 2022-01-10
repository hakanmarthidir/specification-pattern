using Microsoft.AspNetCore.Mvc;
using specification_pattern.Domain;
using specification_pattern.Domain.Specs.StudentSpecs;
using specification_pattern.Application;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace specification_pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var spec = new ActiveStudentSpec(Domain.Status.Active);
            var result = await this._studentService.GetUsersBySpec(spec).ConfigureAwait(false);          
            return Ok(result);
        }

        [HttpGet("age")]
        public async Task<IActionResult> Get(int age)
        {
            var spec = new AgeGreaterThanFilterStudentSpec(age);
            var result = await this._studentService.GetUsersBySpec(spec).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
