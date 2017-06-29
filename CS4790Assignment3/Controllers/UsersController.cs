using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CS4790Assignment3.Data;
using CS4790Assignment3.Models;
using CS4790Assignment3.Models.ViewModels;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Html;
using System.Net;
using System.IO;
using System.Net.Http;

namespace CS4790Assignment3.Views.Users
{
	public class UsersController : Controller
	{
		private readonly GameContext _context;

		public UsersController(GameContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return RedirectToAction("Login");
		}

		// GET: Login
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		// POST: Index
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Login(User user)
		{
			if (user.Username != "" && user.Password != "")
			{
				if (ValidateUser(user))
				{
					//Re-get the user after validation
					var ValidationUser = _context.Users.SingleOrDefault<User>(u => u.Username == user.Username);

					//User is valid, set session data.
					//Far form proper for user authentication. 
					//	But it "works" for this assignment with what we've been shown in class.
					HttpContext.Session.SetString("validated", "true");
					HttpContext.Session.SetString("username", ValidationUser.Username);
					HttpContext.Session.SetInt32("userid", ValidationUser.UserID);
					HttpContext.Session.SetString("role", ValidationUser.Role);
					return RedirectToAction("Index", "Games");
				}
				else
				{
					ModelState.AddModelError("", "Username or password is incorrect.");
				}
			}

			return View(user);
		}

		// GET: Users/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Users/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("UserID,Username,Password,EmailAddress,Role,Address,City,State,Zipcode,PhoneNumber")] User user)
		{
			user.Role = "User"; //Default to user. Admins will manually update the DB to add other Administrators. (Or Version 2.0 feature?)
			if (ModelState.IsValid)
			{
				if (_context.Users.Any<User>(u => u.Username == user.Username) || _context.Users.Any<User>(u => u.EmailAddress == user.EmailAddress))
				{
					//If username or email are already in use.
					return View(user);
				}
				else
				{
					_context.Add(user);
					await _context.SaveChangesAsync();
					return RedirectToAction("Index");
				}
			}
			return View(user);
		}

		// GET: Users/Create
		public IActionResult ViewCart()
		{
			SetUserData();
			double tmpTotalCost = SimpleShoppingCart.ShoppingCart.Sum(i => (i.Quantity * i.Price));
			int tmpTotalItems = SimpleShoppingCart.ShoppingCart.Sum(i => i.Quantity);
			var temporaryCart = new ShoppingCart
			{
				Cart = SimpleShoppingCart.ShoppingCart,
				SubTotal = tmpTotalCost,
				TotalItems = tmpTotalItems
			};
			return View(SimpleShoppingCart.ShoppingCart);
		}

		// GET: Users/EmptyCart
		public IActionResult EmptyCart()
		{
			SetUserData();
			SimpleShoppingCart.EmptyCart();
			return RedirectToAction("ViewCart", "Users", SimpleShoppingCart.ShoppingCart);
		}

		// POST: Users/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddItemToCart(GameDetails Item)
		{
			SetUserData();
			CartItem NewEntry = new CartItem
			{
				GameID = Item.Game.GameID,
				Quantity = Item.Quantity,
				Name = Item.Game.Name,
				Price = Item.Game.Price
			};

			SimpleShoppingCart.AddToCart(NewEntry);
			return View("ViewCart", SimpleShoppingCart.ShoppingCart);
		}

		// POST: Users/RemoveItemFromCart
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		public IActionResult RemoveItemFromCart(int id)
		{
			SetUserData();
			SimpleShoppingCart.RemoveItem(id);
			return RedirectToAction("ViewCart", "Users", SimpleShoppingCart.ShoppingCart);
		}

		public IActionResult UpdateCartItemQuantity(int id, int qty)
		{
			return View("ViewCart");
		}

		public async Task<IActionResult> Checkout()
		{
			SetUserData();
			double tmpTotalCost = SimpleShoppingCart.ShoppingCart.Sum(i => (i.Quantity * i.Price));
			int tmpTotalItems = SimpleShoppingCart.ShoppingCart.Sum(i => i.Quantity);
			var user = _context.Users.FirstOrDefault<User>(u => u.UserID == HttpContext.Session.GetInt32("userid"));
			var taxrate = await GetTaxRate(user.Zipcode);

			double TaxRateParsed;
			double.TryParse(taxrate, out TaxRateParsed);

			var temporaryCart = new ShoppingCart
			{
				Cart = SimpleShoppingCart.ShoppingCart,
				TaxRate = TaxRateParsed,
				TaxTotal = (tmpTotalCost * TaxRateParsed),
				SubTotal = tmpTotalCost,
				GrandTotal = tmpTotalCost + (tmpTotalCost * TaxRateParsed),
				TotalItems = tmpTotalItems
			};

			var temporaryCheckout = new Checkout
			{
				Cart = temporaryCart,
				User = user
			};

			return View(temporaryCheckout);
		}

		public async Task<IActionResult> OrderSummary(Checkout order)
		{
			SetUserData();
			
			//Okay, cheating a bit here by re-generating the order's details instead of passing the same model from Checkout to Summary.
			double tmpTotalCost = SimpleShoppingCart.ShoppingCart.Sum(i => (i.Quantity * i.Price));
			int tmpTotalItems = SimpleShoppingCart.ShoppingCart.Sum(i => i.Quantity);
			var user = _context.Users.FirstOrDefault<User>(u => u.UserID == HttpContext.Session.GetInt32("userid"));
			var taxrate = await GetTaxRate(user.Zipcode);

			double TaxRateParsed;
			double.TryParse(taxrate, out TaxRateParsed);
			CartItem[] Cartcopy = new CartItem[SimpleShoppingCart.ShoppingCart.Count];
			SimpleShoppingCart.ShoppingCart.CopyTo(Cartcopy);

			var temporaryCart = new ShoppingCart
			{
				//Cart = SimpleShoppingCart.ShoppingCart,
				Cart = Cartcopy.ToList(),
				TaxRate = TaxRateParsed,
				TaxTotal = (tmpTotalCost * TaxRateParsed),
				SubTotal = tmpTotalCost,
				GrandTotal = tmpTotalCost + (tmpTotalCost * TaxRateParsed),
				TotalItems = tmpTotalItems
			};

			var temporaryCheckout = new Checkout
			{
				Cart = temporaryCart,
				User = user
			};

			//One behavior item to take care of AFTER creating out return product:
			//	Clear the global shopping cart's inventory.
			SimpleShoppingCart.RemoveAll(); //Commented out for now, as this is killing the only copy of the static shopping cart.

			return View(temporaryCheckout);
		}

		private async Task<string> GetTaxRate(int zip)
		{
			//http://assignment4-api.azurewebsites.net/api/tax/2
			//https://docs.microsoft.com/en-us/dotnet/framework/network-programming/how-to-send-data-using-the-webrequest-class

			string urlAddress = "http://assignment4-api.azurewebsites.net/api/tax/" + zip;

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
			WebResponse response = await request.GetResponseAsync();

			Stream receiveStream = response.GetResponseStream();
			StreamReader readStream = new StreamReader(receiveStream);
			var data = readStream.ReadToEnd();

			return data;
		}

		private void SetUserData()
		{
			if (HttpContext.Session.GetString("validated") == "true")
			{
				ViewData["IsValidated"] = HttpContext.Session.GetString("validated");
				ViewData["Username"] = HttpContext.Session.GetString("username");
				ViewData["UserID"] = HttpContext.Session.GetInt32("userid");
				ViewData["Role"] = HttpContext.Session.GetString("role");
			}
		}

		public IActionResult Logout()
		{
			HttpContext.Session.Remove("validated");
			HttpContext.Session.Remove("username");
			HttpContext.Session.Remove("userid");
			HttpContext.Session.Remove("role");
			HttpContext.Session.Clear();
			SimpleShoppingCart.EmptyCart();
			return RedirectToAction("Index", "Games");
		}

		private bool ValidateUser(User user)
		{
			var ValidationUser = _context.Users.SingleOrDefault<User>(u => u.Username == user.Username);
			if (ValidationUser != null)
				return ValidationUser.Password == user.Password;
			else
				return false;

		}
	}
}
