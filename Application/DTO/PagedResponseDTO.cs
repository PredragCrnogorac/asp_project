using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
	public class PagedResponseDTO<T>
	{
		public int CurrentPage { get; set; }
		public int PageCount { get; set; }
		public int TotallCount { get; set; }
		public IEnumerable<T> Data { get; set; }
	}
}
