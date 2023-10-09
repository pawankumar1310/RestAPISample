using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPISample.Models;

namespace RestAPISample.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{


    private readonly StudentDbDemoContext _context;
    private readonly ILogger<StudentController> _logger;

    public StudentController(StudentDbDemoContext context, ILogger<StudentController> logger)
    {
        _context = context;
        _logger = logger;
    }
    //Get all students records
    // GET api/students
    [HttpGet()]
    public async Task<IActionResult> SelectAsync()
    {
        try
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }
          catch (Exception)
            {
                return BadRequest("Error occurred !!");
            }
    }
    // Get student by Student ID
    // GET api/students/STDN00001
    [HttpGet("{StudentID}")]
    public async Task<IActionResult> SelectAsync(string student_Id)
    {
        try
        {
            var student = await _context.Students.FindAsync(student_Id);
            return Ok(student);
        }
        catch
        {
            throw;
        }

    }
    //Insert student records
    // POST api/students
    [HttpPost()]
    public async Task<IActionResult> InsertAsync([FromBody] Student _student)
    {
        try
        {
            var student = await _context.Students.FindAsync(_student.StudentId);
            if (student != null)
            {
                _context.SaveChanges();
                 return BadRequest("Already student exist.");
            }
            else
            {
                _context.Students.Add(_student);
                _context.SaveChanges();
                return Ok(true);
            }
        }
        catch
        {
            throw;
        }

    }
    //Delete Student records
    // DELETE api/students/STDN00001
    [HttpDelete("{StudentID}")]
    public async Task<IActionResult> DeleteAsync(string student_Id)
    {
        try
        {
            var student = await _context.Students.FindAsync(student_Id);
            if (student != null)
            {
                _context.Remove(student);
                _context.SaveChanges();
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
        catch
        {
            throw;
        }

    }
    //Update the student record
    // PUT api/students
    [HttpPut()]
    public async Task<IActionResult> UpdateAsync(String student_Id, [FromBody] Student _student)
    {
        try
        {
            _context.Update(_student);
            await _context.SaveChangesAsync();
            return Ok(_student);
        }
        catch
        {
            throw;
        }

    }

}
