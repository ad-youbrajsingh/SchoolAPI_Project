using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Project.Application.Commands.Student;
using SchoolAPI.Project.Application.Queries.Student;

namespace SchoolAPI.Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents([FromQuery] GetAllStudentsQuery query)
        {
            var students = await _mediator.Send(query);
            if (students.Data == null || !students.Data.Any())
            {
                return NoContent();
            }
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery { Id = id });
            if (student == null)
            {
                return NoContent();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetStudentById), new { id }, new { id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] UpdateStudentCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id Mismatch!");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var result = await _mediator.Send(new DeleteStudentCommand { Id = id });
            return Ok(result);
        }
    }
}
