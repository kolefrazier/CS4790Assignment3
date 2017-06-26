using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790Assignment3.Models.ViewModels
{
	public class ShoppingCart
	{
		public int TotalItems { get; set; }
		public double TotalCost { get; set; }
		public List<CartItem> Cart { get; set; }
	}
}
