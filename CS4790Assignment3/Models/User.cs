//https://www.codeproject.com/Articles/482546/Creating-a-custom-user-login-form-with-NET-Csharp

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CS4790Assignment3.Models
{
	public class User
	{
		public int UserID { get; set; }
		[Required]
		[Display(Name = "Username")]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public string Role { get; set; }

		//Not quite navigation properties... But... Yeah...
		//public List<Game> ShoppingCart { get; set; }
	}
}
