using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CS4790Assignment3.Data;
using CS4790Assignment3.Models;
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

		//--- From Login page? ---
		//1 - Get user from DB
		//get userid, username, userpassword from usertable where input username = usertable.username
		//2- Set Session data
		//HttpContext.Session.SetString(SessionKeyName, UsernameFromDB);
		//HttpContext.SessionSetInt32(SessionKeyUserID, UserIDFromDB);
		//Set ViewData["IsSignedIn"] = true;

		//--- After Login Call---
		//If signed in, return signed in data. Otherwise, set user viewmodel to null for the View to format.


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

		public IActionResult Logout()
		{
			HttpContext.Session.Remove("validated");
			HttpContext.Session.Remove("username");
			HttpContext.Session.Remove("userid");
			HttpContext.Session.Remove("role");
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
