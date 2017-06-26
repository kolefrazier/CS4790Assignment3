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

			//Publishers
			var publishers = new Publisher[]
			{
				new Publisher { PublisherName = "No Third Games Software", IsTripleA = true, IsIndie = false},
				new Publisher { PublisherName = "NSA-Backdoor Studios", IsTripleA = true, IsIndie = false},
				new Publisher { PublisherName = "For Software", IsTripleA = true, IsIndie = false},
				new Publisher { PublisherName = "Tom Hanks", IsTripleA = false, IsIndie = true},
				new Publisher { PublisherName = "Symphony Software", IsTripleA = true, IsIndie = false}
			};

			foreach (Publisher p in publishers)
			{
				context.Publishers.Add(p);
			}
			context.SaveChanges();

			//Games
			var games = new Game[] 
			{
				new Game { Name = "The Binding of Isaac: Rebirth", Genre = "Roguelike", Price = 15.0, IsOnlineMultiplayer = false, AlreadyOwned = true, Publisher = publishers.FirstOrDefault(p => p.PublisherID == 1) },
				new Game { Name = "Team Fortress 2", Genre = "First Person Shooter", Price = 0, IsOnlineMultiplayer = true, AlreadyOwned = true, Publisher = publishers.FirstOrDefault(p => p.PublisherID == 1) },
				new Game { Name = "Arma III", Genre = "First Person Shooter", Price = 30.0, IsOnlineMultiplayer = true, AlreadyOwned = true, Publisher = publishers.FirstOrDefault(p => p.PublisherID == 1) },
				new Game { Name = "Ori and the Blind Forest", Genre = "Platformer", Price = 20.0, IsOnlineMultiplayer = false, AlreadyOwned = true, Publisher = publishers.FirstOrDefault(p => p.PublisherID == 2) },
				new Game { Name = "The Escapists", Genre = "Roguelike", Price = 10.0, IsOnlineMultiplayer = false, AlreadyOwned = true, Publisher = publishers.FirstOrDefault(p => p.PublisherID == 2) },
				new Game { Name = "Garry's Mod", Genre = "First Person Shooter", Price = 5.0, IsOnlineMultiplayer = true, AlreadyOwned = true, Publisher = publishers.FirstOrDefault(p => p.PublisherID == 2) },
				new Game { Name = "FTL", Genre = "Roguelike", Price = 12.0, IsOnlineMultiplayer = false, AlreadyOwned = false, Publisher = publishers.FirstOrDefault(p => p.PublisherID == 3) },
				new Game { Name = "Half-Life 2", Genre = "First Person Shooter", Price = 30.0, IsOnlineMultiplayer = false, AlreadyOwned = false, Publisher = publishers.FirstOrDefault(p => p.PublisherID == 3) },
				new Game { Name = "GTAV", Genre = "Action", Price = 30.0, IsOnlineMultiplayer = true, AlreadyOwned = false, Publisher = publishers.FirstOrDefault(p => p.PublisherID == 3) },
				new Game { Name = "Hyper Light Drifer", Genre = "Action", Price = 30.0, IsOnlineMultiplayer = false, AlreadyOwned = false, Publisher = publishers.FirstOrDefault(p => p.PublisherID == 4) },
				new Game { Name = "Amnesia: The Dark Descent", Genre = "Horror", Price = 20.0, IsOnlineMultiplayer = false, AlreadyOwned = false, Publisher = publishers.FirstOrDefault(p => p.PublisherID == 4) },
				new Game { Name = "Dark Souls: Prepare to Die", Genre = "Adventure", Price = 20.0, IsOnlineMultiplayer = true, AlreadyOwned = false, Publisher = publishers.FirstOrDefault(p => p.PublisherID == 4) },
				new Game { Name = "Race the Sun", Genre = "Action", Price = 5.0, IsOnlineMultiplayer = false, AlreadyOwned = false, Publisher = publishers.FirstOrDefault(p => p.PublisherID == 5) },
				new Game { Name = "Tales of Zestiria", Genre = "RPG", Price = 60.0, IsOnlineMultiplayer = false, AlreadyOwned = false, Publisher = publishers.FirstOrDefault(p => p.PublisherID == 5) },
				new Game { Name = "Witcher 3", Genre = "RPG", Price = 60.0, IsOnlineMultiplayer = false, AlreadyOwned = true, Publisher = publishers.FirstOrDefault(p => p.PublisherID == 5) }
			};

			foreach (Game g in games)
			{
				context.Games.Add(g);
			}
			context.SaveChanges();

			//Reviews
			var reviews = new Review[]
			{
				new Review { SubmissionDate = DateTime.Parse("2017-01-12"), DoesRecommend = true, Author = "Chuck", ReviewContent = "Difficult but fantastic roguelike!", Game = games.FirstOrDefault(g => g.GameID == 1)},
				new Review { SubmissionDate = DateTime.Parse("2016-02-21"), DoesRecommend = true, Author = "Charles", ReviewContent = "Fluid controls, beautiful graphics and OST!", Game = games.FirstOrDefault(g => g.GameID == 2)},
				new Review { SubmissionDate = DateTime.Parse("2014-03-25"), DoesRecommend = true, Author = "Abby", ReviewContent = "I died a lot, and I enjoyed it.", Game = games.FirstOrDefault(g => g.GameID == 3) },
				new Review { SubmissionDate = DateTime.Parse("2011-04-09"), DoesRecommend = false, Author = "Abigail", ReviewContent = "Great game and fantastic story. But no sequal in sight, story inconclusive.", Game = games.FirstOrDefault(g => g.GameID == 4)},
				new Review { SubmissionDate = DateTime.Parse("2013-05-04"), DoesRecommend = false, Author = "Alex", ReviewContent = "Way too scary!", Game = games.FirstOrDefault(g => g.GameID == 5)},
				new Review { SubmissionDate = DateTime.Parse("2016-06-12"), DoesRecommend = true, Author = "Arnold", ReviewContent = "Easy but fantastic!", Game = games.FirstOrDefault(g => g.GameID == 1)},
				new Review { SubmissionDate = DateTime.Parse("2017-07-23"), DoesRecommend = true, Author = "Beth", ReviewContent = "Fluid controls, beautiful graphics and OST!", Game = games.FirstOrDefault(g => g.GameID == 6)},
				new Review { SubmissionDate = DateTime.Parse("2012-08-25"), DoesRecommend = true, Author = "Bart", ReviewContent = "I died a lot, and I enjoyed it.", Game = games.FirstOrDefault(g => g.GameID == 7) },
				new Review { SubmissionDate = DateTime.Parse("2010-09-09"), DoesRecommend = false, Author = "John", ReviewContent = "Great game.", Game = games.FirstOrDefault(g => g.GameID == 8)},
				new Review { SubmissionDate = DateTime.Parse("2009-10-04"), DoesRecommend = false, Author = "Jacob", ReviewContent = "Way too scary!", Game = games.FirstOrDefault(g => g.GameID == 9)},
				new Review { SubmissionDate = DateTime.Parse("2008-11-12"), DoesRecommend = true, Author = "Jessica", ReviewContent = "Difficult but fantastic roguelike!", Game = games.FirstOrDefault(g => g.GameID == 10)},
				new Review { SubmissionDate = DateTime.Parse("2007-12-23"), DoesRecommend = true, Author = "Jenna", ReviewContent = "Fluid controls, beautiful graphics and OST!", Game = games.FirstOrDefault(g => g.GameID == 11)},
				new Review { SubmissionDate = DateTime.Parse("2006-11-25"), DoesRecommend = true, Author = "Megan", ReviewContent = "I died a lot, and I enjoyed it.", Game = games.FirstOrDefault(g => g.GameID == 12) },
				new Review { SubmissionDate = DateTime.Parse("2005-10-09"), DoesRecommend = false, Author = "Mark", ReviewContent = "Great game and fantastic story. Story inconclusive.", Game = games.FirstOrDefault(g => g.GameID == 13)},
				new Review { SubmissionDate = DateTime.Parse("2012-09-04"), DoesRecommend = false, Author = "Caitlyn", ReviewContent = "Way too scary!", Game = games.FirstOrDefault(g => g.GameID == 14)},
				new Review { SubmissionDate = DateTime.Parse("2013-08-12"), DoesRecommend = true, Author = "Cynthia", ReviewContent = "Difficult but fantastic roguelike!", Game = games.FirstOrDefault(g => g.GameID == 15)},
				new Review { SubmissionDate = DateTime.Parse("2014-07-23"), DoesRecommend = true, Author = "Jordan", ReviewContent = "Fluid controls, beautiful graphics and OST!", Game = games.FirstOrDefault(g => g.GameID == 1)},
				new Review { SubmissionDate = DateTime.Parse("2015-06-25"), DoesRecommend = true, Author = "Jeff", ReviewContent = "I died a lot, and I enjoyed it.", Game = games.FirstOrDefault(g => g.GameID == 2) },
				new Review { SubmissionDate = DateTime.Parse("2009-05-09"), DoesRecommend = false, Author = "Rachel", ReviewContent = "Great game and fantastic story. But no sequal in sight.", Game = games.FirstOrDefault(g => g.GameID == 3)},
				new Review { SubmissionDate = DateTime.Parse("2010-04-04"), DoesRecommend = false, Author = "Ronald", ReviewContent = "Way too scary!", Game = games.FirstOrDefault(g => g.GameID == 4)}
			};

			foreach (Review r in reviews)
			{
				context.Reviews.Add(r);
			}
			context.SaveChanges();

			//Screenshots
			var screenshots = new Screenshot[]
			{
				new Screenshot { CaptureTimestamp = DateTime.Parse("2017-02-02"), LocalPath = "#", Category = ScreenshotCategory.Achievement, SourceGame = "The Binding of Isaac: Rebirth" },
				new Screenshot { CaptureTimestamp = DateTime.Parse("2016-12-28"), LocalPath = "#", Category = ScreenshotCategory.Deathcam, SourceGame = "Team Fortress 2"},
				new Screenshot { CaptureTimestamp = DateTime.Parse("2016-12-29"), LocalPath = "#", Category = ScreenshotCategory.Deathcam, SourceGame = "Team Fortress 2"},
				new Screenshot { CaptureTimestamp = DateTime.Parse("2016-11-13"), LocalPath = "#", Category = ScreenshotCategory.Glitch, SourceGame = "Everspace"}
			};
			
			foreach (Screenshot s in screenshots)
			{
				context.Screenshots.Add(s);
			}
			context.SaveChanges();

			var users = new User[]
			{
				new User{ Username = "Admin", Password = "Password123", EmailAddress = "admin@website.com", Role = "Administrator" },
				new User{ Username = "Normal", Password = "123Password", EmailAddress = "john@doe.com", Role = "User"}
			};

			foreach (User u in users)
			{
				context.Users.Add(u);
			}
			context.SaveChanges();
		}
	}
}
