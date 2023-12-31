﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
	public record CategoryDto
	{
		public int CategoryId { get; init; }
		[Required(ErrorMessage = "CategoryName is required!")]
		public String? CategoryName { get; init; } = String.Empty;
	}
}
