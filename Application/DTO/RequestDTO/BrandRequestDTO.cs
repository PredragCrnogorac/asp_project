using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO.RequestDTO
{
    public class BrandRequestDTO
    {
		[Required(ErrorMessage ="This field is required")]
		[MinLength(3, ErrorMessage ="Minimun lenght of brand is 3 characters")]
        public string Name { get; set; }
    }
}
