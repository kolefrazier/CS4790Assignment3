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
			if (ModelState.IsValid)
			{
				if (ValidateUser(user))
				{
					//Re-get the user after validation
					var ValidationUser = _context.Users.SingleOrDefault<User>(u => u.Username == user.Username);

					//User is valid, set session data.
					//Far form proper for user authentication. 
					//	But it "works" for this assignment with what we've been shwon in class.
					HttpContext.Session.SetString("validated", "true");
					HttpContext.Session.SetString("username", ValidationUser.Username);
					HttpContext.Session.SetInt32("userid", ValidationUser.UserID);
					HttpContext.Session.SetString("role", ValidationUser.Role);
					return RedirectToAction("Index", "Games");
				} else
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
		public async Task<IActionResult> Create([Bind("UserID,Username,Password,EmailAddress,Role")] User user)
		{
			user.Role = "User"; //Default to user. Admins will manually update the DB to add other Administrators. (Or Version 2.0 feature?)
			if (ModelState.IsValid)
			{
				if(_context.Users.Any<User>(u => u.Username == user.Username) || _context.Users.Any<User>(u => u.EmailAddress == user.EmailAddress))
				{
					//If username or email are already in use.
					return View(user);
				} else
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
			return View();
		}

		// POST: Users/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddItemToCart(GameDetails Item)
		{
			CartItem NewEntry = new CartItem
			{
				GameID = Item.Game.GameID,
				Quantity = Item.Quantity,
				Name = Item.Game.Name,
				Price = Item.Game.Price
			};

			SimpleShoppingCart.AddToCart(NewEntry);
			return View("ViewCart", SimpleShoppingCart.ShoppingCart);
			//return RedirectToAction("ViewCart");

			//----WUBWUBWUB----

			////Validation
			//var ValidationUser = _context.Users.SingleOrDefault<User>(u => u.UserID == HttpContext.Session.GetInt32("userid"));
			//if (Item.CartItem.Quantity < 1 || Item.Game.GameID < 0)
			//{
			//	return View();
			//}

			//CartItem NewItem = new CartItem
			//{
			//	Quantity = Item.CartItem.Quantity,
			//	GameID = Item.Game.GameID,
			//	UserID = ValidationUser.UserID
			//};

			//SimpleShoppingCart.AddToCart(NewItem);
			//return RedirectToAction("Index", "Games");
			////return SubmitCartItem(tmp);
		}

		///// <summary>
		///// [DEPRECATED]
		///// </summary>
		///// <param name="Item"></param>
		///// <returns></returns>
		//public async Task<IActionResult> SubmitCartItem(CartItem Item)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		if (Item.Quantity < 1)
		//		{
		//			return RedirectToAction("Details", "Games", Item.GameID);
		//		}
		//		else
		//		{
		//			_context.Add(Item);
		//			await _context.SaveChangesAsync();
		//			return RedirectToAction("ViewCart");
		//		}
		//	}
		//	return RedirectToAction("Details", "Games", Item.GameID);
		//}

		public IActionResult Logout()
		{
			HttpContext.Session.Remove("validated");
			HttpContext.Session.Remove("username");
			HttpContext.Session.Remove("userid");
			HttpContext.Session.Remove("role");
			HttpContext.Session.Clear();
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
