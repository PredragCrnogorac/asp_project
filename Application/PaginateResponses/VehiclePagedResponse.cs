using System;
using System.Collections.Generic;
using System.Text;

namespace Application.PaginateResponses
{
	public class VehiclePagedResponse<T>
	{
		public int TotalPages { get; set; }
		public int TotallCount { get; set; }
		public int CurrentPage { get; set; }
		public ICollection<T> Data { get; set; }
	}
}
