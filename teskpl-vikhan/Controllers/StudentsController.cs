using Microsoft.AspNetCore.Mvc;

namespace teskpl_vikhan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = LoadStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = FindStudentById(id);

            if (student == null)
                return NotFound(new { message = "Student not found" });

            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Students newStudent)
        {
            if (!IsValidStudent(newStudent))
                return BadRequest(new { message = "Invalid input" });

            var students = LoadStudents();
            newStudent.id = GenerateNewStudentId(students);
            students.Add(newStudent);

            SaveStudents(students);
            return CreatedAtAction(nameof(GetStudentById), new { id = newStudent.id }, newStudent);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Students updatedStudent)
        {
            var student = FindStudentById(id);

            if (student == null)
                return NotFound(new { message = "Student not found" });

            if (!IsValidStudent(updatedStudent))
                return BadRequest(new { message = "Invalid input" });

            UpdateStudentData(student, updatedStudent);
            SaveStudents(LoadStudents());

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var Students = JsonFileService.LoadData();
            var Student = Students.Find(s => s.id == id);

            if (Student == null)
                return NotFound(new { message = "Student not found" });

            Students.Remove(Student);
            JsonFileService.SaveData(Students);

            return NoContent();
        }

        private List<Students> LoadStudents()
        {
            return JsonFileService.LoadData();
        }

        private void SaveStudents(List<Students> students)
        {
            JsonFileService.SaveData(students);
        }

        private Students FindStudentById(int id)
        {
            var students = LoadStudents();
            return students.Find(s => s.id == id);
        }

        private bool IsValidStudent(Students student)
        {
            return !string.IsNullOrEmpty(student.Nama) && student.Umur > 0 && !string.IsNullOrEmpty(student.Jurusan);
        }

        private int GenerateNewStudentId(List<Students> students)
        {
            return students.Count > 0 ? students[^1].id + 1 : 1;
        }

        private void UpdateStudentData(Students existingStudent, Students updatedStudent)
        {
            existingStudent.Nama = updatedStudent.Nama;
            existingStudent.Umur = updatedStudent.Umur;
            existingStudent.Jurusan = updatedStudent.Jurusan;
        }
    }
}
