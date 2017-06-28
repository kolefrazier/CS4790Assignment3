using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790Assignment3.Models.ViewModels
{
	public class Checkout
	{
		[Required]
		public ShoppingCart Cart { get; set; }

		[Required]
		public User User { get; set; }
	}
}
