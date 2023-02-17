using Microsoft.AspNetCore.Mvc;
using Student_Registration.DbContexts;
using Student_Registration.Model;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly RegistrationDbContext dbContext;
        public StudentController(RegistrationDbContext _dbcontext)
        {
            dbContext = _dbcontext;
        }
        // GET: api/<StudentController>
        // GET api/<StudentController>/5
        [HttpGet("{gid}")]
        public async Task<IActionResult> Get([MaxLength(5)][MinLength(5)] string gid)
        {

            try
            {
                Student_data data = await dbContext.students.FindAsync(gid);
                Final_student_data final_data  = new Final_student_data();
                final_data.surname = data.surname;
                final_data.father = data.father;
                final_data.room = data.room;
                final_data.village = data.village;
                final_data.name = data.name;
                final_data.cup_no = data.cup_no;   
                final_data.stndard = data.stndard;
                final_data.gid= data.gid;
                final_data.id = data.id;
                final_data.url = new Uri("http://10.0.2.13/assets/students/"+data.gid+".jpg");
                return Ok(final_data);
            }
            catch (Exception ex) {
                return Ok(new Student_data());
            }

            

        }


    }
}
