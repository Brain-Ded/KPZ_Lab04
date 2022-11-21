using KPZ_Lab04.Models;
using Microsoft.AspNetCore.Mvc;

namespace KPZ_Lab04.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly KpzLab03DbContext _dbcontext;
        public UsersController(KpzLab03DbContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Student")]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                List<Student> students = _dbcontext.Students.ToList();
                if (students != null)
                {
                    return Ok(students);
                }
                return Ok("There are no Students in database");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("Teacher")]
        public async Task<IActionResult> GetTeachers()
        {
            try
            {
                List<Teacher> teachers = _dbcontext.Teachers.ToList();
                if (teachers != null)
                {
                    return Ok(teachers);
                }
                return Ok("There are no Students in database");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #region create
        [HttpPost]
        [Route("Student")]
        public async Task<IActionResult> AddStudent(string name, string surname, double MathAver,
            double EnglishAver, double PhilosophyAver, int TeacherID)
        {
            try
            {
                _dbcontext.Students.Add(new Student()
                {
                    Name = name,
                    Surname = surname,
                    AverageMath = MathAver,
                    AverageEnglish = EnglishAver,
                    AveragePhilosophy = PhilosophyAver,
                    TId = TeacherID
                });

                await _dbcontext.SaveChangesAsync();
                return Ok(_dbcontext.Students.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Route("Teacher")]
        public async Task<IActionResult> AddTeacher(string name, string surname)
        {
            try
            {
                _dbcontext.Teachers.Add(new Teacher()
                {
                    Name = name,
                    Surname = surname
                });

                await _dbcontext.SaveChangesAsync();
                return Ok(_dbcontext.Students.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion
    }
}