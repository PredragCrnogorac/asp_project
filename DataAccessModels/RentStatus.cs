using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessModels
{
	public class RentStatus : BaseEntity
	{
		public string Name { get; set; }
		public ICollection<Rent> Rents { get; set; }
	}
}
