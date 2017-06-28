using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CS4790Assignment3.Models.ViewModels;

namespace CS4790Assignment3
{
	/// <summary>
	/// A really simple, static shopping cart.
	/// It's far from ideal. But it works and is session-specific, as the Canvas requirements specify.
	/// In a world with more time, I would've figured out why the database method wasn't working and would have used a persistent DB table to store entries, instead.
	/// </summary>
	public class SimpleShoppingCart
	{
		static SimpleShoppingCart()
		{
			ShoppingCart = new List<CartItem>();
		}

		public static List<CartItem> ShoppingCart { get; set; }

		private static int _TotalQuantity = 0;
		public static int TotalQuantity
		{
			get { return _TotalQuantity; }
		}

		public static void EmptyCart()
		{
			ShoppingCart = new List<CartItem>();
		}

		public static void AddToCart(CartItem Item)
		{
			_TotalQuantity += Item.Quantity;

			if (ShoppingCart.Any(i => i.GameID == Item.GameID))
			{
				var ExistingItem = ShoppingCart.First(i => i.GameID == Item.GameID);
				ExistingItem.Quantity += Item.Quantity;

				//--- Maybe move this logic down to UpdateCart?? ---
				//if (Item.Quantity == ExistingItem.Quantity)
				//{
				//	ExistingItem.Quantity += Item.Quantity;
				//} else if(Item.Quantity > ExistingItem.Quantity)
				//{
				//	ExistingItem.Quantity += (Item.Quantity - ExistingItem.Quantity);
				//} else if (Item.Quantity < ExistingItem.Quantity)
				//{
				//	ExistingItem.Quantity += (ExistingItem.Quantity - Item.Quantity);
				//} else
				//{
				//	ExistingItem.Quantity = Item.Quantity;
				//}
			} else
			{
				ShoppingCart.Add(Item);
			}
		}

		public static void UpdateCart(CartItem Item)
		{
			//Check how to update Count.
			int tmpCartItem = ShoppingCart.FirstOrDefault<CartItem>(c => c.GameID == Item.GameID).Quantity;
			if(tmpCartItem < Item.Quantity)
			{
				_TotalQuantity -= (Item.Quantity - tmpCartItem);
			} else if (tmpCartItem > Item.Quantity)
			{
				_TotalQuantity += (tmpCartItem - Item.Quantity);
			}

			//Update cart item's quantity
			if (Item.Quantity > 0)
			{
				ShoppingCart.FirstOrDefault<CartItem>(c => c.GameID == Item.GameID).Quantity = Item.Quantity;
			}
		}

		public static void RemoveItem(int id)
		{
			var Item = ShoppingCart.First(i => i.GameID == id);
			_TotalQuantity -= Item.Quantity;
			ShoppingCart.Remove(Item);
		}

		public static void RemoveAll()
		{
			_TotalQuantity = 0;
			ShoppingCart.Clear();
		}
	}
}
