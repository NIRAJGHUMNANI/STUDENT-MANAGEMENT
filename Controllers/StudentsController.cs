using Microsoft.AspNetCore.Mvc;
using StudentManagementRestAPI.Models;
using StudentManagementRestAPI.Services;

namespace StudentManagementRestAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService) => _studentService = studentService;

    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetAll() => Ok(_studentService.GetAll());

    [HttpGet("{id:int}")]
    public ActionResult<Student> GetById(int id)
    {
        var student = _studentService.GetById(id);
        return student is null ? NotFound(new { message = $"Student with ID {id} was not found." }) : Ok(student);
    }

    [HttpPost]
    public ActionResult<Student> Create([FromBody] Student student)
    {
        var created = _studentService.Add(student);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] Student student)
    {
        if (!_studentService.Update(id, student))
            return NotFound(new { message = $"Student with ID {id} was not found." });
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (!_studentService.Delete(id))
            return NotFound(new { message = $"Student with ID {id} was not found." });
        return NoContent();
    }
}
