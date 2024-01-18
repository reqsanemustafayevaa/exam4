using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxer.business.Exceptions
{
    public class InvalidImageSizeException:Exception
    {
        public string PropertyyName { get; set; }
        public InvalidImageSizeException()
        {

        }
        public InvalidImageSizeException(string? message) : base(message)
        {

        }
        public InvalidImageSizeException(string? propertyname, string? message) : base(message)
        {
            PropertyyName = propertyname;
        }
    }
}
