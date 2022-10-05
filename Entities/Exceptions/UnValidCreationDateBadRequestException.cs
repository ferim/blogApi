using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class UnValidCreationDateBadRequestException : BadRequestException
    {
        public UnValidCreationDateBadRequestException() : base("Article creation date must between blog publish date and now!")
        {

        }
    }
}
