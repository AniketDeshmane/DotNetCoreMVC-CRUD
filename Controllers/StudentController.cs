using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;
using StudentManagement.Models.Domain;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        //Add async method
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentModel addStudentModel)
        {
            var student = new StudentModel()
            {
                ID = Guid.NewGuid(),
                Name = addStudentModel.Name,
                Address = addStudentModel.Address,
                Phone = addStudentModel.Phone,
                Email = addStudentModel.Email,
                Class = addStudentModel.Class,
                DateOfBirth = addStudentModel.DateOfBirth
            };
            await studentDbContext.Students.AddAsync(student);
            await studentDbContext.SaveChangesAsync();
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var employee = await studentDbContext.Students.ToListAsync();

            return View(employee);
        }

        [HttpGet]
        public async Task <IActionResult> Update(Guid ID)
        {
            var student = await studentDbContext.Students.FirstOrDefaultAsync(x => x.ID == ID);
            var ViewModel = new UpdateStudentModel()
            {
                ID = student.ID,
                Name = student.Name,
                Address = student.Address,
                Phone = student.Phone,
                Email = student.Email,
                Class = student.Class,
                DateOfBirth = student.DateOfBirth

            };

            return View(ViewModel);
        
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateStudentModel updateStudentModel)
        {
            var employee = await studentDbContext.Students.FindAsync(updateStudentModel.ID);
            if (employee != null)
            {
                
                employee.Name = updateStudentModel.Name;
                employee.Address = updateStudentModel.Address;
                employee.Phone = updateStudentModel.Phone;
                employee.Email = updateStudentModel.Email;
                employee.Class = updateStudentModel.Class;
                employee.DateOfBirth= updateStudentModel.DateOfBirth;   
                await studentDbContext.SaveChangesAsync();
                return RedirectToAction("List");
            };
            return RedirectToAction("Add");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateStudentModel updateStudentModel)
        {
            var employees = await studentDbContext.Students.FindAsync(updateStudentModel.ID);
            studentDbContext.Students.Remove(employees);
            await studentDbContext.SaveChangesAsync();
            return RedirectToAction("List");
        }
    } 
}
           