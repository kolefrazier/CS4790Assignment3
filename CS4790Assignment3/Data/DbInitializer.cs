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
			context.Database.EnsureCreated();

			//Check for existing content before seeding.
			if (context.Games.Any())
			{
				return;
			}

			//TODO: Fill in game preseed data.
			var games = new Game[] { };
			foreach (Game g in games)
			{
				context.Games.Add(g);
			}
			context.SaveChanges();

			//TODO: Add seed stuff for Publisher, Review and Screenshot classes.
		}
    }
}
