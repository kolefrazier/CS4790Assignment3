//https://docs.microsoft.com/en-us/aspnet/web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/shopping-cart

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CS4790Assignment3.Models.ViewModels
{
	public class CartItem
	{
		[Display(Name = "Quantity")]
		public int Quantity { get; set; }

		//Navigation Properties
		[Display(Name = "Game ID")]
		public int GameID { get; set; }
		[Display(Name = "Game Name")]
		public string Name { get; set; }
		[Display(Name = "Price Per Copy")]
		public double Price { get; set; }
	}
}
