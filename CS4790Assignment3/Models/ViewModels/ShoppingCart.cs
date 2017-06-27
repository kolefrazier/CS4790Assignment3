using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790Assignment3.Models.ViewModels
{
	public class ShoppingCart
	{
		public int TotalItems { get; set; }

		[DataType(DataType.Currency)]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public double SubTotal { get; set; }

		[DataType(DataType.Currency)]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public double TaxRate { get; set; }

		[DataType(DataType.Currency)]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public double TaxTotal { get; set; }

		[DataType(DataType.Currency)]
		[DisplayFormat(DataFormatString = "{0:c}")]
		public double GrandTotal { get; set; }

		public List<CartItem> Cart { get; set; }
	}
}
