using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EntityUnchangedException : Exception
    {
        public EntityUnchangedException()
        {

        }
        public EntityUnchangedException(string entity) : base(entity + " hasn't been changed")
        {

        }
    }
}
