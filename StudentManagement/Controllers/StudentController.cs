using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace StudentManagement.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> _student = new List<Student>();
        private static List<Course> _courses = new List<Course>();

        [HttpGet("api/courses")]
        public IActionResult GetCourses()
        {
            return Ok(_courses);
        }

        [HttpGet("api/courses/{id}")]
        public IActionResult GetCourseById(string id)
        {
            var course = _courses.SingleOrDefault(x => x.Id == id);
            if (course == null)
                return NotFound();
            return Ok(course);
        }

        [HttpPost("api/courses")]
        public IActionResult CreateCourse(Course course)
        {
            var courseToBeAdded = new Course
            {
                Id = new string(course.Name.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.First()).ToArray()) + Convert.ToString(course.Year),
                Name = course.Name,
                Duration = course.Duration,
                Year = course.Year
            };
            _courses.Add(courseToBeAdded);
            return Ok(courseToBeAdded.Id);
        }

        [HttpPut("api/courses/{id}")]
        public IActionResult EditCourse(string id, Course course)
        {
            var courseId = _courses.SingleOrDefault(x => x.Id == id);
            if (courseId == null)
                return NotFound();
            courseId.Name = course.Name;
            courseId.Year = course.Year;
            courseId.Duration = course.Duration;
            return Ok(courseId);
        }

        [HttpDelete("api/courses/{id}")]
        public IActionResult DeleteCourse(string id)
        {
            var course = _courses.SingleOrDefault(x => x.Id == id);
            if (course == null)
                return NotFound();
            _courses.Remove(course);
            return Ok();
        }

        [HttpGet("api/students")]
        public IActionResult GetStudents()
        {
            return Ok(_student);
        }

        [HttpGet("api/students/{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _student.SingleOrDefault(x => x.Id == id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost("api/students")]
        public IActionResult CreateStudent(Student student)
        {
            DateTime date1, date2;
            if (DateTime.TryParseExact(student.Dob, new[] { "dd-MMM-yyyy" }, null, DateTimeStyles.None, out date1))
                String.Format("{0:dd-mmm-yyyy}", date1);
            else
                return Conflict();
            if (DateTime.TryParseExact(student.EnrollmentDate, new[] { "dd-MMM-yyyy" }, null, DateTimeStyles.None, out date2))
                String.Format("{0:dd-mmm-yyyy}", date2);
            else
                return Conflict();
            if ((Convert.ToDateTime(student.Dob) > DateTime.Now) || (Convert.ToDateTime(student.EnrollmentDate) > DateTime.Now))
                return Conflict();
            var courseId = _courses.Exists(x => x.Name == student.Course);
            if (courseId == true)
            {
                int id;
                var lastStudent = _student.OrderBy(x => x.Id).LastOrDefault();
                id = lastStudent == null ? 1 : lastStudent.Id + 1;
                var studentToBeAdded = new Student
                {
                    Id = id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Dob = student.Dob,
                    Address = student.Address,
                    PhoneNumber = student.PhoneNumber,
                    EnrollmentDate = student.EnrollmentDate,
                    Course = student.Course
                };
                _student.Add(studentToBeAdded);
                return Ok();
            }
            return Conflict();
        }

        [HttpPut("api/students/{id}")]
        public IActionResult EditStudent(int id, Student student)
        {
            if ((Convert.ToDateTime(student.Dob) > DateTime.Now) || (Convert.ToDateTime(student.EnrollmentDate) > DateTime.Now))
                return Conflict();
            var courseId = _courses.Exists(x => x.Name == student.Course);
            if (courseId == true)
            {
                var studentId = _student.SingleOrDefault(x => x.Id == id);
                if (studentId == null)
                    return NotFound();
                studentId.FirstName = student.FirstName;
                studentId.LastName = student.LastName;
                studentId.PhoneNumber = student.PhoneNumber;
                studentId.EnrollmentDate = student.EnrollmentDate;
                studentId.Course = student.Course;
                studentId.Dob = student.Dob;
                studentId.Address = student.Address;
                return Ok();
            }
            return Conflict();
            
        }

        [HttpDelete("api/students/{id}")]
        public IActionResult Delete(int id)
        {
            var student = _student.SingleOrDefault(x => x.Id == id);
            if (student == null)
                return NotFound();
            _student.Remove(student);
            return Ok();
        }

        [HttpGet("api/students/list")]
        public IActionResult ListStudents()
        {
            var studentList = _student.Select(x => new { x.FirstName, x.LastName });
            return Ok(studentList);
        }

        [HttpGet("api/courses/list")]
        public IActionResult GetCourseDetails()
        {
            /*var courseList = from C in _courses
                             join S in _student on C.Name equals S.Course into cs
                             from docIfNull in cs.DefaultIfEmpty()
                             group docIfNull by C.Name into g
                             select new { CourseName = g.Key, docCount = g.Count(S => S != null) };*/
            var courseList = _courses.GroupJoin(_student, c => c.Name, s => s.Course, (c, s) => new { courseName = c.Name, students = s.Count() });
            /*var courseList = from c in _courses
                             join s in _student on c.Name equals s.Course into stud
                             select new
                             {
                                 courseName = c.Name,
                                 Count = stud.Count()
                             };*/
            return Ok(courseList);
        }
    }
}
