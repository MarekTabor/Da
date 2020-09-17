using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.DTOs
{
	public class UserForRegisterDto
	{
		[Required]
		public string Username { get; set; }
		[Required]
		[StringLength(8, MinimumLength =4, ErrorMessage ="Hasło musi posiadać od 4 do 8 znaków")]
		public string Password { get; set; }
	}
}
