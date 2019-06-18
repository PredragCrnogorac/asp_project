using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EntityExistsException : Exception
    {
        public EntityExistsException()
        {

        }
        public EntityExistsException(string entity) : base(entity + " already exists.")
        {

        }
    }
}
