using boxer.business.Exceptions;
using boxer.business.Extentions;
using boxer.business.Services.Interfaces;
using boxer.core.Models;
using boxer.core.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxer.business.Services.Implementations
{
   
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment _env;

        public StudentService(IStudentRepository studentRepository
                             ,IWebHostEnvironment env)
        {
            _studentRepository = studentRepository;
           _env = env;
        }
        public async Task CreateAsync(Students students)
        {
            if (students == null)
            {
                throw new StudentNotFoundException();
            }
            if (students.ImageFile != null)
            {
                if(students.ImageFile.ContentType!="image/png" && students.ImageFile.ContentType != "image/jpeg")
                {
                    throw new ImageContentException("ImageFile","File must be .jpeg or .png");
                }
                if (students.ImageFile.Length > 2097152)
                {
                    throw new InvalidImageSizeException("ImageFile","File must be lower than 1mb!");
                }
                students.ImageUrl = students.ImageFile.SaveFile(_env.WebRootPath, "uploads/students");
            }
            students.CreatedDate = DateTime.UtcNow;
            students.UpdatedDate = DateTime.UtcNow; 
            await _studentRepository.CreateAsync(students);
            await _studentRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var student = await _studentRepository.GetByIdAsync(x => x.Id == id);
            if (student == null)
            {
                throw new StudentNotFoundException();
            }
            _studentRepository.Delete(student);
            await _studentRepository.CommitAsync();
        }

        public async Task<List<Students>> GetAllAsync()
        {
           return await _studentRepository.GetAllAsync().ToListAsync();
        }

        public async Task<Students> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(x => x.Id == id);
            if(student == null)
            {
                throw new StudentNotFoundException();
            }
            return student;
        }

        public async Task UpdateAsync(Students students)
        {
            var existstudent=await _studentRepository.GetByIdAsync(x=>x.Id == students.Id);
            if (existstudent == null)
            {
                throw new StudentNotFoundException();
            }
            if (students.ImageFile != null)
            {
                if (students.ImageFile.ContentType != "image/png" && students.ImageFile.ContentType != "image/jpeg")
                {
                    throw new ImageContentException("ImageFile", "File must be .jpeg or .png");
                }
                if (students.ImageFile.Length > 2097152)
                {
                    throw new InvalidImageSizeException("ImageFile", "File must be lower than 1mb!");
                }
                Helper.DeleteFile(_env.WebRootPath, "uploads/students", existstudent.ImageUrl);
               
                students.ImageUrl = students.ImageFile.SaveFile(_env.WebRootPath, "uploads/students");

            }
            existstudent.Name = students.Name;
            existstudent.Description = students.Description;
            existstudent.UpdatedDate = students.UpdatedDate;
            existstudent.IsDeleted = false;
            await _studentRepository.CommitAsync();
            



        }
    }
}
