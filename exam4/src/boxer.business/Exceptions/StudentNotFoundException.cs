using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxer.business.Exceptions
{
    public class StudentNotFoundException:Exception
    {

        public string PropertyName {  get; set; }
        public StudentNotFoundException()
        {
                
        }
        public StudentNotFoundException(string? message):base(message) 
        {
            
        }
        public StudentNotFoundException(string propertyname,string? message):base(message) 
        {
            PropertyName = propertyname;
        }
    }
}
