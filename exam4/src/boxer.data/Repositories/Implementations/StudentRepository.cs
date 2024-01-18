using boxer.core.Models;
using boxer.core.Repositories.Interfaces;
using boxer.data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxer.data.Repositories.Implementations
{
    public class StudentRepository : GenericRepository<Students>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
