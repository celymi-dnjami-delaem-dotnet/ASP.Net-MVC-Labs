using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Repository;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents() => await _studentsRepository.GetStudents();
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id) => await _studentsRepository.GetStudent(id);
        
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            await _studentsRepository.AddStudent(student);

            return Created("student", student);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {
            await _studentsRepository.UpdateStudent(student);

            return Ok(student);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveStudent(int id)
        {
            await _studentsRepository.RemoveStudent(id);

            return NoContent();
        }
    }
}