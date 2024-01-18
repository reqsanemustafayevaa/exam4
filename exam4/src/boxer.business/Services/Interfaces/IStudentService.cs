using boxer.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxer.business.Services.Interfaces
{
    public interface IStudentService
    {
        Task CreateAsync(Students students);
        Task UpdateAsync(Students students);
        Task Delete(int id);
        Task<List<Students>> GetAllAsync();
        Task<Students> GetByIdAsync(int id);



    }
}
