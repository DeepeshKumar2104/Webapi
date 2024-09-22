using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Models;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitController : ControllerBase
    {
        List<String> fruits = new List<string>
        {
            "Apple", "Banana", "Mango", "Orange", "Grapes"

        };
        public FruitController()
        {
            
        }
        [HttpGet]
        public List<string> getFruits()
        {
            return fruits;
        }
        [HttpGet("{id}")]
        public string getFruit(int id)
        {
            return fruits.ElementAt(id);
        }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentdbContext student;

        public StudentController(StudentdbContext student)
        {
            this.student = student;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllstudent()
        {
            var stud = await student.Students.ToListAsync();
            return Ok(stud);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentByID(int id )
        {
            var stud = await student.Students.FindAsync(id);
            if (stud == null)
            {
                return NotFound();
            }
            else { return Ok(stud); }
            
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student std )
        {
            if (ModelState.IsValid)
            {
                await student.Students.AddAsync(std);
                await student.SaveChangesAsync();
               
            }
            return Ok(std);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int ? id ,Student std)
        {
            if (id == null || student.Students == null) return NotFound();
            var stud = await student.Students.FirstOrDefaultAsync(x =>x.StudentId == id);
            if(stud != null)
            {
                student.Students.Update(std);
                await student.SaveChangesAsync();
            }
            return Ok(stud);
        }

        [HttpDelete]

        public async Task<ActionResult<Student>> DeleteStudent(int? id)
        {
            if (id == null || student.Students == null) return NotFound();
            var stud = await student.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (stud != null)
            {
                student.Students.Remove(stud);
            }
            await student.SaveChangesAsync();
            return Ok("user Delete Successfully");
        }


    }

}
