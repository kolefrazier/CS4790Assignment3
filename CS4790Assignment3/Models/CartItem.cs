//https://docs.microsoft.com/en-us/aspnet/web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/shopping-cart

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CS4790Assignment3.Models
{
	public class CartItem
	{
		[Key]
		public int ItemID { get; set; }
		public int CartID { get; set; }
		public int Quantity { get; set; }

		//Navigation Properties
		public int GameID { get; set; }
		public Game Game { get; set; }
	}
}
