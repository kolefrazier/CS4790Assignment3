using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CS4790Assignment3.Data;
using CS4790Assignment3.Models;

namespace CS4790Assignment3.Controllers
{
	public class GamesController : Controller
	{
		private readonly GameContext _context;

		public GamesController(GameContext context)
		{
			_context = context;    
		}

		// GET: Games
		public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? page)
		{
			//return View(await _context.Games.ToListAsync());
			ViewData["CurrentSort"] = sortOrder;
			ViewData["NameSort"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
			ViewData["HoursPlayed"] = sortOrder == "Hours" ? "hours_desc" : "Hours";
			ViewData["currentFilter"] = searchString;

			if (searchString != null)
			{
				page = 1;
			} else
			{
				searchString = currentFilter;
			}

			var games = from g in _context.Games select g;

			if (!String.IsNullOrEmpty(searchString))
			{
				games = games.Where(g => g.GameName.Contains(searchString));
			}

			ViewData["DefaultFilterVisibility"] = "visible";
			switch (sortOrder)
			{
				case "name_desc":
					games = games.OrderByDescending(g => g.GameName);
					break;
				case "Hours":
					games = games.OrderBy(g => g.HoursPlayed);
					break;
				case "hours_desc":
					games = games.OrderByDescending(g => g.HoursPlayed);
					break;
				default:
					ViewData["DefaultFilterVisibility"] = "hidden";
					games = games.OrderBy(g => g.GameName);
					break;
			}

			int pageSize = 5;
			return View(await PaginatedList<Game>.CreateAsync(games.AsNoTracking(), page ?? 1, pageSize));

		}

		// GET: Games/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var game = await _context.Games
				.SingleOrDefaultAsync(m => m.GameID == id);
			if (game == null)
			{
				return NotFound();
			}

			return View(game);
		}

		// GET: Games/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Games/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("GameID,Name,Genre,Price,HoursPlayed,IsCompleted,CurrentlyPlaying,IsOnlineMultiplayer")] Game game)
		{
			if (ModelState.IsValid)
			{
				_context.Add(game);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(game);
		}

		// GET: Games/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var game = await _context.Games.SingleOrDefaultAsync(m => m.GameID == id);
			if (game == null)
			{
				return NotFound();
			}
			return View(game);
		}

		// POST: Games/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("GameID,Name,Genre,Price,HoursPlayed,IsCompleted,CurrentlyPlaying,IsOnlineMultiplayer")] Game game)
		{
			if (id != game.GameID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(game);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!GameExists(game.GameID))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction("Index");
			}
			return View(game);
		}

		// GET: Games/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var game = await _context.Games
				.SingleOrDefaultAsync(m => m.GameID == id);
			if (game == null)
			{
				return NotFound();
			}

			return View(game);
		}

		// POST: Games/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var game = await _context.Games.SingleOrDefaultAsync(m => m.GameID == id);
			_context.Games.Remove(game);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		private bool GameExists(int id)
		{
			return _context.Games.Any(e => e.GameID == id);
		}
	}
}
