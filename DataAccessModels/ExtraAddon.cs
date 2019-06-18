using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessModels
{
    public class ExtraAddon : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
		public ICollection<RentExtraAddon> RentExtraAddons { get; set; }
	}
}
