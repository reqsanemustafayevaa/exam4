using boxer.business.Exceptions;
using boxer.business.Services.Interfaces;
using boxer.core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace boxer.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    //[Authorize(Roles ="SuperAdmin")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<IActionResult> Index()
        {
            var students=await _studentService.GetAllAsync();
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(Students students)
        {
            if(!ModelState.IsValid)
            {
                return View(students);
            }
            try
            {
                await _studentService.CreateAsync(students);
            }
            catch(ImageContentException ex)
            {
                ModelState.AddModelError(ex.PropertyyName, ex.Message);
                return View(students);
            }
            catch(InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyyName, ex.Message);
                return View(students);
            }
            catch(StudentNotFoundException ex)
            {
                throw new StudentNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if(student == null)
            {
                throw new StudentNotFoundException();
            }
            return View(student);

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult>Update(Students students)
        {
            if(!ModelState.IsValid)
            {
                return View(students);
            }
            try
            {
                await _studentService.UpdateAsync(students);
            }
            catch (ImageContentException ex)
            {
                ModelState.AddModelError(ex.PropertyyName, ex.Message);
                return View(students);
            }
            catch (InvalidImageSizeException ex)
            {
                ModelState.AddModelError(ex.PropertyyName, ex.Message);
                return View(students);
            }
            catch (StudentNotFoundException ex)
            {
                throw new StudentNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("Index");
        }
        public async  Task<ActionResult> Delete(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                throw new StudentNotFoundException();
            }
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Students students)
        {
            try
            {
                await _studentService.Delete(students.Id);
            }
            catch(Exception ex)
            {
                throw;
            }
            return RedirectToAction("index");
        }
    }
}
