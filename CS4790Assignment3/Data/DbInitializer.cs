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
				new Game { GameName = "The Binding of Isaac: Rebirth", CurrentlyPlaying = false, Genre = GameGenre.Roguelike, HoursPlayed = 58, IsCompleted = false, Price = 15.0, IsOnlineMultiplayer = false},
				new Game { GameName = "Team Fortress 2", CurrentlyPlaying = true, Genre = GameGenre.FirstPersonShooter, HoursPlayed = 300, IsCompleted = false, Price = 0, IsOnlineMultiplayer = true},
				new Game { GameName = "Arma III", CurrentlyPlaying = false, Genre = GameGenre.FirstPersonShooter, HoursPlayed = 20, IsCompleted = false, Price = 30.0, IsOnlineMultiplayer = true},
				new Game { GameName = "Ori and the Blind Forest", CurrentlyPlaying = false, Genre = GameGenre.Platformer, HoursPlayed = 22, IsCompleted = true, Price = 20.0, IsOnlineMultiplayer = false},
				new Game { GameName = "Everspace", CurrentlyPlaying = false, Genre = GameGenre.FirstPersonShooter, HoursPlayed = 15.6, IsCompleted = false, Price = 20.0, IsOnlineMultiplayer = false},
				new Game { GameName = "The Escapists", CurrentlyPlaying = true, Genre = GameGenre.Roguelike, HoursPlayed = 2, IsCompleted = false, Price = 10.0, IsOnlineMultiplayer = false},
				new Game { GameName = "Garry's Mod", CurrentlyPlaying = false, Genre = GameGenre.FirstPersonShooter, HoursPlayed = 45, IsCompleted = false, Price = 5.0, IsOnlineMultiplayer = true},
				new Game { GameName = "FTL", CurrentlyPlaying = false, Genre = GameGenre.Roguelike, HoursPlayed = 20, IsCompleted = false, Price = 12.0, IsOnlineMultiplayer = false},
				new Game { GameName = "Half-Life 2", CurrentlyPlaying = false, Genre = GameGenre.FirstPersonShooter, HoursPlayed = 20, IsCompleted = false, Price = 30.0, IsOnlineMultiplayer = false},
				new Game { GameName = "GTAV", CurrentlyPlaying = true, Genre = GameGenre.Action, HoursPlayed = 20, IsCompleted = false, Price = 30.0, IsOnlineMultiplayer = true},
				new Game { GameName = "Hyper Light Drifer", CurrentlyPlaying = false, Genre = GameGenre.Action, HoursPlayed = 20, IsCompleted = false, Price = 30.0, IsOnlineMultiplayer = false},
				new Game { GameName = "Amnesia: The Dark Descent", CurrentlyPlaying = false, Genre = GameGenre.Horror, HoursPlayed = 8, IsCompleted = false, Price = 20.0, IsOnlineMultiplayer = false},
				new Game { GameName = "Dark Souls: Prepare to Die", CurrentlyPlaying = true, Genre = GameGenre.Adventure, HoursPlayed = 50, IsCompleted = true, Price = 20.0, IsOnlineMultiplayer = true},
				new Game { GameName = "Race the Sun", CurrentlyPlaying = false, Genre = GameGenre.Action, HoursPlayed = 4, IsCompleted = false, Price = 5.0, IsOnlineMultiplayer = false},
				new Game { GameName = "Tales of Zestiria", CurrentlyPlaying = false, Genre = GameGenre.RPG, HoursPlayed = 25, IsCompleted = false, Price = 60.0, IsOnlineMultiplayer = false}
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
				new Publisher { PublisherName = "No Third Games Software", IsTripleA = true, IsIndie = false },
				new Publisher { PublisherName = "NSA-Backdoor Studios", IsTripleA = true, IsIndie = false},
				new Publisher { PublisherName = "For Software", IsTripleA = true, IsIndie = false},
				new Publisher { PublisherName = "Tom Hanks", IsTripleA = false, IsIndie = true},
				new Publisher { PublisherName = "Symphony Software", IsTripleA = true, IsIndie = false}
			};
			foreach (Publisher p in Publisher)
			{
				context.Publishers.Add(p);
			}
			context.SaveChanges();
			

			//Reviews
			var Review = new Review[]
			{
				new Review { SubmissionDate = DateTime.Parse("2017-01-12"), DoesRecommend = true, ReviewContent = "Difficult but fantastic roguelike!"},
				new Review { SubmissionDate = DateTime.Parse("2016-02-21"), DoesRecommend = true, ReviewContent = "Fluid controls, beautiful graphics and OST!"},
				new Review { SubmissionDate = DateTime.Parse("2014-03-25"), DoesRecommend = true, ReviewContent = "I died a lot, and I enjoyed it." },
				new Review { SubmissionDate = DateTime.Parse("2011-04-09"), DoesRecommend = false, ReviewContent = "Great game and fantastic story. But no sequal in sight, story inconclusive."},
				new Review { SubmissionDate = DateTime.Parse("2013-05-04"), DoesRecommend = false, ReviewContent = "Way too scary!"},
				new Review { SubmissionDate = DateTime.Parse("2016-06-12"), DoesRecommend = true, ReviewContent = "Easy but fantastic!"},
				new Review { SubmissionDate = DateTime.Parse("2017-07-23"), DoesRecommend = true, ReviewContent = "Fluid controls, beautiful graphics and OST!"},
				new Review { SubmissionDate = DateTime.Parse("2012-08-25"), DoesRecommend = true, ReviewContent = "I died a lot, and I enjoyed it." },
				new Review { SubmissionDate = DateTime.Parse("2010-09-09"), DoesRecommend = false, ReviewContent = "Great game."},
				new Review { SubmissionDate = DateTime.Parse("2009-10-04"), DoesRecommend = false, ReviewContent = "Way too scary!"},
				new Review { SubmissionDate = DateTime.Parse("2008-11-12"), DoesRecommend = true, ReviewContent = "Difficult but fantastic roguelike!"},
				new Review { SubmissionDate = DateTime.Parse("2007-12-23"), DoesRecommend = true, ReviewContent = "Fluid controls, beautiful graphics and OST!"},
				new Review { SubmissionDate = DateTime.Parse("2006-11-25"), DoesRecommend = true, ReviewContent = "I died a lot, and I enjoyed it." },
				new Review { SubmissionDate = DateTime.Parse("2005-10-09"), DoesRecommend = false, ReviewContent = "Great game and fantastic story. Story inconclusive."},
				new Review { SubmissionDate = DateTime.Parse("2012-09-04"), DoesRecommend = false, ReviewContent = "Way too scary!"},
				new Review { SubmissionDate = DateTime.Parse("2013-08-12"), DoesRecommend = true, ReviewContent = "Difficult but fantastic roguelike!"},
				new Review { SubmissionDate = DateTime.Parse("2014-07-23"), DoesRecommend = true, ReviewContent = "Fluid controls, beautiful graphics and OST!"},
				new Review { SubmissionDate = DateTime.Parse("2015-06-25"), DoesRecommend = true, ReviewContent = "I died a lot, and I enjoyed it." },
				new Review { SubmissionDate = DateTime.Parse("2009-05-09"), DoesRecommend = false, ReviewContent = "Great game and fantastic story. But no sequal in sight."},
				new Review { SubmissionDate = DateTime.Parse("2010-04-04"), DoesRecommend = false, ReviewContent = "Way too scary!"}
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
