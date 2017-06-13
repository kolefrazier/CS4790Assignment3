using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS4790Assignment3.Models;

namespace CS4790Assignment3.Data
{
	public static class DbInitializer
	{
		public static void Initialize(GameContext context)
		{
			//context.Database.EnsureCreated();

			//Check for existing content before seeding.
			if (context.Games.Any())
			{
				return;
			}

			//Games
			var games = new Game[] 
			{
				new Game { Name = "The Binding of Isaac: Rebirth", CurrentlyPlaying = false, Genre = GameGenre.Roguelike, HoursPlayed = 58, IsCompleted = false, Price = 15.0, IsOnlineMultiplayer = false},
				new Game { Name = "Team Fortress 2", CurrentlyPlaying = true, Genre = GameGenre.FirstPersonShooter, HoursPlayed = 300, IsCompleted = false, Price = 0, IsOnlineMultiplayer = true},
				new Game { Name = "Arma III", CurrentlyPlaying = false, Genre = GameGenre.FirstPersonShooter, HoursPlayed = 20, IsCompleted = false, Price = 30.0, IsOnlineMultiplayer = true},
				new Game { Name = "Ori and the Blind Forest", CurrentlyPlaying = false, Genre = GameGenre.Platformer, HoursPlayed = 22, IsCompleted = true, Price = 20.0, IsOnlineMultiplayer = false},
				new Game { Name = "Everspace", CurrentlyPlaying = false, Genre = GameGenre.FirstPersonShooter, HoursPlayed = 15.6, IsCompleted = false, Price = 20.0, IsOnlineMultiplayer = false},
				new Game { Name = "The Escapists", CurrentlyPlaying = true, Genre = GameGenre.Roguelike, HoursPlayed = 2, IsCompleted = false, Price = 10.0, IsOnlineMultiplayer = false},
				new Game { Name = "Garry's Mod", CurrentlyPlaying = false, Genre = GameGenre.FirstPersonShooter, HoursPlayed = 45, IsCompleted = false, Price = 5.0, IsOnlineMultiplayer = true},
				new Game { Name = "FTL", CurrentlyPlaying = false, Genre = GameGenre.Roguelike, HoursPlayed = 20, IsCompleted = false, Price = 12.0, IsOnlineMultiplayer = false},
				new Game { Name = "Half-Life 2", CurrentlyPlaying = false, Genre = GameGenre.FirstPersonShooter, HoursPlayed = 20, IsCompleted = false, Price = 30.0, IsOnlineMultiplayer = false},
				new Game { Name = "GTAV", CurrentlyPlaying = true, Genre = GameGenre.Action, HoursPlayed = 20, IsCompleted = false, Price = 30.0, IsOnlineMultiplayer = true},
				new Game { Name = "Hyper Light Drifer", CurrentlyPlaying = false, Genre = GameGenre.Action, HoursPlayed = 20, IsCompleted = false, Price = 30.0, IsOnlineMultiplayer = false},
				new Game { Name = "Amnesia: The Dark Descent", CurrentlyPlaying = false, Genre = GameGenre.Horror, HoursPlayed = 8, IsCompleted = false, Price = 20.0, IsOnlineMultiplayer = false},
				new Game { Name = "Dark Souls: Prepare to Die", CurrentlyPlaying = true, Genre = GameGenre.Adventure, HoursPlayed = 50, IsCompleted = true, Price = 20.0, IsOnlineMultiplayer = true},
				new Game { Name = "Race the Sun", CurrentlyPlaying = false, Genre = GameGenre.Action, HoursPlayed = 4, IsCompleted = false, Price = 5.0, IsOnlineMultiplayer = false},
				new Game { Name = "Tales of Zestiria", CurrentlyPlaying = false, Genre = GameGenre.RPG, HoursPlayed = 25, IsCompleted = false, Price = 60.0, IsOnlineMultiplayer = false}
			};
			foreach (Game g in games)
			{
				context.Games.Add(g);
			}
			context.SaveChanges();

			//TODO: Add seed stuff for Review and Screenshot classes.

			//Publishers
			var Publisher = new Publisher[]
			{
				new Publisher { Name = "Valve Software", IsTripleA = true, IsIndie = false },
				new Publisher { Name = "Microsoft Studios", IsTripleA = true, IsIndie = false},
				new Publisher { Name = "From Software", IsTripleA = true, IsIndie = false},
				new Publisher { Name = "Edward McMullin", IsTripleA = false, IsIndie = true},
				new Publisher { Name = "Rockstar", IsTripleA = true, IsIndie = false}
			};
			foreach (Publisher p in Publisher)
			{
				context.Publishers.Add(p);
			}
			context.SaveChanges();

			//Reviews
			var Review = new Review[]
			{
				new Review { SubmissionDate = DateTime.Parse("2017-04-12"), GameName = "The Binding of Isaac: Rebirth", DoesRecommend = true, ReviewContent = "Difficult but fantastic roguelike!"},
				new Review { SubmissionDate = DateTime.Parse("2016-06-23"), GameName = "Ori and the Blind Forest", DoesRecommend = true, ReviewContent = "Fluid controls, beautiful graphics and OST!"},
				new Review { SubmissionDate = DateTime.Parse("2014-02-25"), GameName = "Dark Souls: Prepare to Die", DoesRecommend = true, ReviewContent = "I died a lot, and I enjoyed it." },
				new Review { SubmissionDate = DateTime.Parse("2011-09-09"), GameName = "Half-Life 2", DoesRecommend = false, ReviewContent = "Great game and fantastic story. But no sequal in sight, story inconclusive."},
				new Review { SubmissionDate = DateTime.Parse("2013-03-04"), GameName = "Amnesia: The Dark Descent", DoesRecommend = false, ReviewContent = "Way too scary!"}
			};
			foreach (Review r in Review)
			{
				context.Reviews.Add(r);
			}
			context.SaveChanges();

			//Screenshots
			var Screenshot = new Screenshot[]
			{
				new Screenshot { CaptureTimestamp = DateTime.Parse("2017-02-02"), LocalPath = "#", Category = ScreenshotCategory.Achievement, SourceGame = "The Binding of Isaac: Rebirth" },
				new Screenshot { CaptureTimestamp = DateTime.Parse("2016-12-28"), LocalPath = "#", Category = ScreenshotCategory.Deathcam, SourceGame = "Team Fortress 2"},
				new Screenshot { CaptureTimestamp = DateTime.Parse("2016-12-29"), LocalPath = "#", Category = ScreenshotCategory.Deathcam, SourceGame = "Team Fortress 2"},
				new Screenshot { CaptureTimestamp = DateTime.Parse("2016-11-13"), LocalPath = "#", Category = ScreenshotCategory.Glitch, SourceGame = "Everspace"}
			};
			foreach (Screenshot s in Screenshot)
			{
				context.Screenshots.Add(s);
			}
			context.SaveChanges();
		}
	}
}
