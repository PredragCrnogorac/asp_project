using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessModels
{
	public class RentExtraAddon
	{
		public int IsDeleted { get; set; }
		public int RentId { get; set; }
		public Rent Rent { get; set; }
		public int ExtraAddonId { get; set; }
		public ExtraAddon ExtraAddon { get; set; }
		//Saving extra add-on prices in this table because price might be changed in future
		public double Price { get; set; }
	}
}
