using Institute_Management.DTOs;
using Institute_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Institute_Management.Models.CourseModule;

namespace Institute_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly InstituteContext _context;

        public AdminController(InstituteContext context)
        {
            _context = context;
        }

        #region Students Management

        // GET: api/admin/students
        [HttpGet("students")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudents()
        {
            var students = await _context.Students
                .Include(s => s.User)
                .Include(s => s.Batch)
                .Include(s => s.Enrollments)
                //.Include(s => s.Course)
                .Select(s => new StudentDTO
                {
                    StudentId = s.StudentId,
                    UserId = s.UserId,
                    BatchId = s.BatchId,
                    User = new UserDTO
                    {
                        UserId = s.User.UserId,
                        Name = s.User.Name,
                        Email = s.User.Email,
                        Role = s.User.Role,
                        ContactDetails = s.User.ContactDetails
                    },
                   Batch = new BatchDTO
                   {
                       BatchName = s.Batch.BatchName,
                       BatchTiming = s.Batch.BatchTiming,
                       BatchType = s.Batch.BatchType
                   },
                    Enrollments = s.Enrollments.Select(e => new EnrollmentDTO
                    {
                        StudentId = e.StudentId,
                        CourseId = e.CourseId,
                        Course = new CourseDTO
                        {
                            CourseId = e.Course.CourseId,
                            CourseName = e.Course.CourseName,
                            Description = e.Course.Description
                        }
                    }).ToList()
                })
                .ToListAsync();

            return Ok(students);
        }

        // POST: api/admin/students
        [HttpPost("students")]
        public async Task<ActionResult<StudentDTO>> CreateStudent([FromBody] StudentDTO studentDto)
        {
            var student = new StudentModule.Student
            {
                UserId = studentDto.UserId,
                BatchId = studentDto.BatchId
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllStudents), new { id = student.StudentId }, studentDto);
        }

        // PUT: api/admin/students/{id}
        [HttpPut("students/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDTO studentDto)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            student.UserId = studentDto.UserId;
            student.BatchId = studentDto.BatchId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/admin/students/{id}
        [HttpDelete("students/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Teacher Management

        // GET: api/admin/teachers
        [HttpGet("teachers")]
        public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetAllTeachers()
        {
            var teachers = await _context.Teachers
                .Include(t => t.User)
                .Select(t => new TeacherDTO
                {
                    TeacherId = t.TeacherId,
                    UserId = t.UserId,
                    SubjectSpecialization = t.SubjectSpecialization,
                    User = new UserDTO
                    {
                        UserId = t.User.UserId,
                        Name = t.User.Name,
                        Email = t.User.Email,
                        Role = t.User.Role,
                        ContactDetails = t.User.ContactDetails
                    }
                })
                .ToListAsync();

            return Ok(teachers);
        }

        // POST: api/admin/teachers
        [HttpPost("teachers")]
        public async Task<ActionResult<TeacherDTO>> CreateTeacher([FromBody] TeacherDTO teacherDto)
        {
            var teacher = new TeacherModule.Teacher
            {
                UserId = teacherDto.UserId,
                SubjectSpecialization = teacherDto.SubjectSpecialization
            };

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllTeachers), new { id = teacher.TeacherId }, teacherDto);
        }

        // PUT: api/admin/teachers/{id}
        [HttpPut("teachers/{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] TeacherDTO teacherDto)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();

            teacher.UserId = teacherDto.UserId;
            teacher.SubjectSpecialization = teacherDto.SubjectSpecialization;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/admin/teachers/{id}
        [HttpDelete("teachers/{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return NotFound();

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Course Management

        // GET: api/admin/courses
        [HttpGet("courses")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAllCourses()
        {
            var courses = await _context.Courses
                .Include(c => c.Teacher)
                .Select(c => new CourseDTO
                {
                    CourseId = c.CourseId,
                    CourseName = c.CourseName,
                    Description = c.Description,
                    //TeacherId = c.TeacherId,
                    Teacher = new TeacherDTO
                    {
                        TeacherId = c.Teacher.TeacherId,
                        UserId = c.Teacher.UserId,
                        SubjectSpecialization = c.Teacher.SubjectSpecialization
                    }
                })
                .ToListAsync();

            return Ok(courses);
        }

        // POST: api/admin/courses
        [HttpPost("courses")]
        public async Task<ActionResult<CourseDTO>> CreateCourse([FromBody] CourseDTO courseDto)
        {
            var course = new CourseModule.Course
            {
                CourseName = courseDto.CourseName,
                Description = courseDto.Description,
                //TeacherId = courseDto.TeacherId
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllCourses), new { id = course.CourseId }, courseDto);
        }

        // PUT: api/admin/courses/{id}
        [HttpPut("courses/{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseDTO courseDto)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            course.CourseName = courseDto.CourseName;
            course.Description = courseDto.Description;
            //course.TeacherId = courseDto.TeacherId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/admin/courses/{id}
        [HttpDelete("courses/{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Batch Management

        // GET: api/admin/batches
        [HttpGet("batches")]
        public async Task<ActionResult<IEnumerable<BatchDTO>>> GetAllBatches()
        {
            var batches = await _context.Batches
                .Include(b => b.Course)
                .Select(b => new BatchDTO
                {
                    BatchId = b.BatchId,
                    BatchName = b.BatchName,
                    BatchTiming = b.BatchTiming,
                    BatchType = b.BatchType,
                    //CourseId = b.CourseId,
                    Course = new CourseDTO
                    {
                        CourseId = b.Course.CourseId,
                        CourseName = b.Course.CourseName,
                        Description = b.Course.Description
                    }
                })
                .ToListAsync();

            return Ok(batches);
        }

        // POST: api/admin/batches
        [HttpPost("batches")]
        public async Task<ActionResult<BatchDTO>> CreateBatch([FromBody] BatchDTO batchDto)
        {
            var batch = new BatchModule.Batch
            {
                BatchName = batchDto.BatchName,
                BatchTiming = batchDto.BatchTiming,
                BatchType = batchDto.BatchType,
                //CourseId = batchDto.CourseId
            };

            _context.Batches.Add(batch);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllBatches), new { id = batch.BatchId }, batchDto);
        }

        // PUT: api/admin/batches/{id}
        [HttpPut("batches/{id}")]
        public async Task<IActionResult> UpdateBatch(int id, [FromBody] BatchDTO batchDto)
        {
            var batch = await _context.Batches.FindAsync(id);
            if (batch == null) return NotFound();

            batch.BatchName = batchDto.BatchName;
            batch.BatchTiming = batchDto.BatchTiming;
            batch.BatchType = batchDto.BatchType;
            //batch.CourseId = batchDto.CourseId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/admin/batches/{id}
        [HttpDelete("batches/{id}")]
        public async Task<IActionResult> DeleteBatch(int id)
        {
            var batch = await _context.Batches.FindAsync(id);
            if (batch == null) return NotFound();

            _context.Batches.Remove(batch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Reporting

        // GET: api/admin/reports/students
        [HttpGet("reports/students")]
        public async Task<IActionResult> GetStudentReports()
        {
            // This is a simplified view of student reports, you can enhance it as per your requirement.
            var studentReports = await _context.Students
                .Select(s => new
                {
                    StudentId = s.StudentId,
                    UserName = s.User.Name,
                    BatchName = s.Batch.BatchName,
                    EnrolledCourses = _context.StudentCourses.Count(sc => sc.StudentId == s.StudentId)
                })
                .ToListAsync();

            return Ok(studentReports);
        }

        // Similar reporting methods can be added for Teachers, Courses, and Batches

        #endregion
    }
}