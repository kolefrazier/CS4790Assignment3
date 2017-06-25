/*
 * https://stackoverflow.com/questions/27666857/entity-framework-code-first-foreign-key-issue
 * https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
 * http://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
 * http://www.entityframeworktutorial.net/code-first/code-first-conventions.aspx
 * http://www.entityframeworktutorial.net/entity-relationships.aspx
 * https://stackoverflow.com/questions/15628110/one-to-many-relationship-seeding-in-code-first
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS4790Assignment3.Models;
using Microsoft.EntityFrameworkCore;

namespace CS4790Assignment3.Data
{
	public class GameContext : DbContext
	{
		public GameContext(DbContextOptions<GameContext> options) : base(options)
		{

		}

		public DbSet<Game> Games { get; set; }
		public DbSet<Publisher> Publishers { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Screenshot> Screenshots { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<CartItem> CartItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Publisher>().ToTable("Publisher");
			modelBuilder.Entity<Game>().ToTable("Game");
			modelBuilder.Entity<Review>().ToTable("Review");
			modelBuilder.Entity<Screenshot>().ToTable("Screenshot");
			modelBuilder.Entity<User>().ToTable("User");
			modelBuilder.Entity<CartItem>().ToTable("CartItem");
		}
	}
}
