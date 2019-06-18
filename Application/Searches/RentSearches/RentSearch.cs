using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches.RentSearches
{
	public class RentSearch
	{
		public int? CurrentPage { get; set; }
		public int? PerPage { get; set; }
		public string Username { get; set; }
		public string Model { get; set; }
		public string Email { get; set; }
		public string Brand { get; set; }
	}
}
