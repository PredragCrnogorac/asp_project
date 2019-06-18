using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessModels
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? IsDeleted { get; set; }
    }
}
